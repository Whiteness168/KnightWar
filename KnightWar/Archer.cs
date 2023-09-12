using System;

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
