using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

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
        protected const int MaxSpeed = 5;
        protected const int MinSpeed = 1;

        public Fighter()
        {
            
        }

        public Fighter(int level, int ammunition, int speed)
        {
            var randValue = new Random();
            var maxSpeed = MaxSpeed;
            var minSpeed = MinSpeed;
            var type = WhoAmI();
            if (FighterType.Horseman == (FighterType)Enum.Parse(typeof(FighterType), type, ignoreCase: true))
            {
                maxSpeed = 8;
                minSpeed = 4;
            }
            level = level > MaxLevel ? MaxLevel : level;
            Ammunition = ammunition > MaxAmmunition ? MaxAmmunition : ammunition;
            Speed = speed > maxSpeed ? maxSpeed : speed;
            Level = level < MinLevel ? randValue.Next(MinLevel, MaxLevel) : level;
            Ammunition = ammunition < MinAmmunition ? randValue.Next(MinAmmunition, MaxAmmunition) : ammunition;
            Speed = speed < minSpeed ? randValue.Next(minSpeed, maxSpeed) : speed;
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
