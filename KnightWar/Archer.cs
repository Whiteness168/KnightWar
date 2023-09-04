using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KnightWar
{
    class Archer : Fighter
    {
        public override FighterType FighterType => FighterType.Archer;
        public Archer(int level, int ammunition, int speed) : base(level, ammunition, speed)
        {

        }

        public override string WhoAmI()
        {
            return "Archer";
        }
    }
}
