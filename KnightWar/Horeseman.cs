using System;

namespace KnightWar
{
    class Horseman : Fighter
    {
        public override int MaxSpeed => 5;
        public override int MinSpeed => 5;
        public override FighterType FighterType => FighterType.Horseman;
        public Horseman(int level, int ammunition, int speed) : base(level, ammunition, speed)
        {

        }

        public override bool Attack(Army unit, int fighterIndex)
        {
            var rand = new Random();
            if (base.Attack(unit, fighterIndex))
            {
                base.Attack(unit, rand.Next(unit.ArmyFighters.Count));
            }
            return true;
        }

        public override string WhoAmI()
        {
            return "Horseman";
        }
    }
}
