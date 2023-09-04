using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightWar
{
    class Infantry : Fighter
    {

        public Infantry(int level, int ammunition, int speed) : base(level, ammunition, speed)
        {

        }
    
        public override FighterType FighterType => FighterType.Infantry;

        public override string WhoAmI()
        {
            return "Infantry";
        }
    }
}
