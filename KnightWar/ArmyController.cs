namespace KnightWar
{
    public class ArmyController
    {
        private void AddUnknownFighter(List<Fighter> fighters, int level, int ammunition, int speed)
        {
            var randValue = new Random();
            int randNumber = randValue.Next(1, 4);

            switch (randNumber)
            {
                case 1:
                    fighters.Add(new Archer(level, ammunition, speed));
                    break;
                case 2:
                    fighters.Add(new Horseman(level, ammunition, speed));
                    break;
                case 3:
                    fighters.Add(new Infantry(level, ammunition, speed));
                    break;
            }
        }

        public void AddFighterInArmy(List<Fighter> fighters, FighterType fighterType, int[] characteristics)
        {
            switch (fighterType)
            {
                case FighterType.Archer:
                    fighters.Add(new Archer(characteristics[0], characteristics[1], characteristics[2]));
                    break;
                case FighterType.Horseman:
                    fighters.Add(new Horseman(characteristics[0], characteristics[1], characteristics[2]));
                    break;
                case FighterType.Infantry:
                    fighters.Add(new Infantry(characteristics[0], characteristics[1], characteristics[2]));
                    break;
                case FighterType.Unknown:
                    AddUnknownFighter(fighters, characteristics[0], characteristics[1], characteristics[2]);
                    break;
            }
        }
    }
}

