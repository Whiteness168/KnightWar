using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightWar
{
    class ArmyController
    {
        private int[] _characteristics = new int [3];

        //private enum FighterType
        //{
        //    Unknown,
        //    Archer,
        //    Horseman,
        //    Infantry
        //}

        public void AddFighterInArmy(List<Fighter> Army)
        {
            var input = Console.ReadLine();
            string[] words = input.Split();

            if (words[0] == "add" && words[1] == "****")
            {
                var randValue = new Random();
                int randNumber = randValue.Next(1, 4);
                switch (randNumber) 
                {
                    case 1: Army.Add(new Archer(0, 0, 0));
                        break;
                    case 2: Army.Add(new Infantry(0, 0, 0));
                        break;
                    case 3: Army.Add(new Horseman(0, 0, 0));
                        break;
                }
            }
            else if (words[0] == "add")
            {
                FighterType fighter = (FighterType)Enum.Parse(typeof(FighterType), words[1], ignoreCase: true);

                for (var i = 2; i <= 3; i++)
                {

                    int.TryParse(words[i], out _characteristics[i - 2]);
                    
                }

                switch (fighter)
                {
                    case FighterType.Unknown:
                        break;
                    case FighterType.Archer:
                        Army.Add(new Archer(_characteristics[0], _characteristics[1], _characteristics[2]));
                        break;
                    case FighterType.Horseman:
                        break;
                    case FighterType.Infantry:
                        break;
                    default:
                        break;
                }

                if (fighter == FighterType.Archer)
                {
                }
                if (fighter == FighterType.Infantry)
                {
                    Army.Add(new Infantry(_characteristics[0], _characteristics[1], _characteristics[2]));
                }
                if (fighter == FighterType.Horseman)
                {
                    Army.Add(new Horseman(_characteristics[0], _characteristics[1], _characteristics[2]));
                }
            }
        }
    }
}
