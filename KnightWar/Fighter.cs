using System;

namespace KnightWar
{
    abstract class Fighter
    {

        public int Level { get; protected set; }
        public int Ammunition { get; protected set; }
        public int Speed { get; protected set; }
        public int Health { get; protected set; }
        public bool Move { get; protected set; }

        public int Damage { get; protected set; }

        public abstract FighterType FighterType { get; }

        protected const int MaxLevel = 5;
        protected const int MinLevel = 1;
        protected const int MaxAmmunition = 5;
        protected const int MinAmmunition = 1;
        public virtual int MaxSpeed { get; protected set; }
        public virtual int MinSpeed { get; protected set; }

        public Fighter(int level, int ammunition, int speed)
        {
            var randValue = new Random();
            MaxSpeed = 5;
            MinSpeed = 1;
            level = level > MaxLevel ? MaxLevel : level;
            Ammunition = ammunition > MaxAmmunition ? MaxAmmunition : ammunition;
            Speed = speed > MaxSpeed ? MaxSpeed : speed;
            Level = level < MinLevel ? randValue.Next(MinLevel, MaxLevel) : level;
            Ammunition = ammunition < MinAmmunition ? randValue.Next(MinAmmunition, MaxAmmunition) : ammunition;
            Speed = speed < MinSpeed ? randValue.Next(MinSpeed, MaxSpeed) : speed;
            Health = 10 + (Level * Ammunition);
            Move = false;
            Damage = 5;
        }

        virtual public bool Attack(Army unit, int fighterIndex)
        {
            var rand = new Random();
            var damage = Damage + ((Level / 2) * Ammunition);
            if (rand.NextDouble() < (0.2 - (Level * 2 / 100)))
            {
                damage = 0;
                Print();
                Console.WriteLine("Промахнулся");
                Console.WriteLine();
                return false;
            }
            else
            {
                unit.ArmyFighters[fighterIndex].Print();
                unit.ArmyFighters[fighterIndex].Health -= damage;
                Move = true;
                Console.WriteLine($" Получил {damage} урона от");
                Print();
                Console.WriteLine($"И у него осталось {unit.ArmyFighters[fighterIndex].Health} здоровья\n");
                return true;
            }
        }

        public void Print()
        {
            Console.WriteLine($"{WhoAmI()}\nLevel: {Level} Ammunition: {Ammunition} Speed: {Speed} Health: {Health}");
        }

        public void MoveZeroing()
        {
            Move = false;
        }

        public void CreateUnknownFighter(List<Fighter> fighter, int level, int ammunition, int speed)
        {
            var randValue = new Random();
            int randNumber = randValue.Next(1, 3);
            switch (randNumber) 
            {
                case 1:
                    fighter.Add( new Archer(level, ammunition, speed));
                    break;
                case 2:
                    fighter.Add(new Horseman(level, ammunition, speed));
                    break;
                case 3:
                    fighter.Add(new Infantry(level, ammunition, speed));
                    break;
            }
        }

        public abstract string WhoAmI();
    }
    public enum FighterType
    {
        Unknown, 
        Archer, 
        Horseman, 
        Infantry
    }
}
