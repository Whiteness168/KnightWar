using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KnightWar
{
    class Horseman : Fighter
    {
        public override FighterType FighterType => FighterType.Horseman;
        public Horseman(int level, int ammunition, int speed) : base(level, ammunition, speed)
        {
            var randValue = new Random();
            if (level > 5) { level = 5; }
            if (ammunition > 5) { ammunition = 5; }
            if (speed > 8 ) { speed = 8; }
            if (speed < 4 ) { speed = 4; }
            Level = level <= 0 ? Level = randValue.Next(1, 5) : Level = level;
            Ammunition = ammunition <= 0 ? Ammunition = randValue.Next(1, 5) : Ammunition = ammunition;
            Speed = speed <= 0 ? Speed = randValue.Next(4, 8) : Speed = speed;
            Health = 10 + (Level * Ammunition);
            Move = 0;
        }

        public override string WhoAmI()
        {
            return "Horseman";
        }
    }
}
