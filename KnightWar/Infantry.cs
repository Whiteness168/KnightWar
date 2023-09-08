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

        public override bool Attack(Army unit, int fighterIndex)
        {
            var type = unit.ArmyFighters[fighterIndex].WhoAmI();
            if (FighterType.Archer == (FighterType)Enum.Parse(typeof(FighterType), type, ignoreCase: true))
            {
                Damage = 10;
                return base.Attack(unit, fighterIndex);
            }
            else 
            { 
                return base.Attack(unit, fighterIndex);
            }
        }
    }
}
