using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KnightWar
{
    class Horseman : Fighter
    {
        public override FighterType FighterType => FighterType.Horseman;
        public Horseman(int level, int ammunition, int speed) : base(level, ammunition, speed)
        {

        }

        public override bool Attack(Army unit, int fighterIndex)
        {
            if (base.Attack(unit, fighterIndex))
            {
                base.Attack(unit, fighterIndex);
            }
            return true;
        }

        public override string WhoAmI()
        {
            return "Horseman";
        }
    }
}
