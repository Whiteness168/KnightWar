namespace KnightWar
{
    public class Horseman : Fighter
    {
        public override int MaxSpeed => 8;
        public override int MinSpeed => 4;
        public override FighterType FighterType => FighterType.Horseman;

        public Horseman(int level, int ammunition, int speed) : base(level, ammunition, speed)
        {
        }

        public override bool Attack(Army army, int fighterIndex)
        {
            var rand = new Random();

            if (base.Attack(army, fighterIndex))
            {
                for(int i = 0; i < army.ArmyFighters.Count; i++)
                {
                    if (army.ArmyFighters[i].Health > 0)
                    {
                        base.Attack(army, i);
                        break;
                    }
                }
            }
            return true;
        }
    }
}
