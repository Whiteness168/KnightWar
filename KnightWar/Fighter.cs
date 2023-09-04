using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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
        public int Move { get; protected set; }

        public abstract FighterType FighterType { get; }

        public const int MaxLevel = 5;

        public Fighter()
        {
            
        }

        public Fighter(int level, int ammunition, int speed)
        {
            var randValue = new Random();
            if (level > MaxLevel) { level = MaxLevel; }
            if (ammunition > 5) { ammunition = 5; }
            if (speed > 5) { speed = 5; }
            Level = level <= 0 ? Level = randValue.Next(1, 5) : Level = level;
            Ammunition = ammunition <= 0 ? Ammunition = randValue.Next(1, 5) : Ammunition = ammunition;
            Speed = speed <= 0 ? Speed = randValue.Next(1, 5) : Speed = speed;
            Health = 10 + (Level * Ammunition);
            Move = 0;
        }

        public void Attack(Fighter unit)
        {
            var rand = new Random();
            var damage = 5 + ((this.Level / 2) * this.Ammunition);
            if (rand.NextDouble() < (0.2 - (this.Level * 2 / 100)))
            {
                damage = 0;
                Console.WriteLine("Loose))");
                Console.WriteLine();
            }
            else
            {
                unit.Health -= damage;
                this.Move++;
                Console.WriteLine($"Нанесено {damage} урона");
                Console.WriteLine();
            }
            unit.Print();
        }

        public void Print()
        {
            Console.WriteLine($"Level: {this.Level} Ammunition: {this.Ammunition} Speed: {this.Speed} Health: {this.Health}");
        }

        public void MoveZeroing()
        {
            Move = 0;
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
