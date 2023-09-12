using System;

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
            if (FighterType.Archer == unit.ArmyFighters[fighterIndex].FighterType)
            {
                Damage = 10;
                return base.Attack(unit, fighterIndex);
            }
            else 
            {
                Damage = 5;
                return base.Attack(unit, fighterIndex);
            }
        }
    }
}
