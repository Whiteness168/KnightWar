using System;

namespace KnightWar
{
    internal class Army
    {
        public List<Fighter> ArmyFighters = new List<Fighter>();

        private List<Fighter> _fighters = new List<Fighter>();
        public IReadOnlyList<Fighter> Fighters => _fighters;
        //public IReadOnlyList<Fighter> Fighters { get { return _fighters; } }

        public void AddFighter(FighterType fighterType)
        {
            if (fighterType == FighterType.Archer)
            {
                _fighters.Add(new Archer(1, 1, 1));
            }
        }

        public bool CheckHealthArmy()
        {
            return ArmyFighters.Count > 0;
        }

        public void DeleteDeadUnit()
        {
            int CountUnit = 0;
            for (int i = ArmyFighters.Count - 1; i <= ArmyFighters.Count && i >= 0; i--)
            {
                if (ArmyFighters[i].Health <= 0)
                {
                    ArmyFighters.RemoveAt(i);
                    CountUnit++;
                }

            }
            Console.WriteLine($"Погибло {CountUnit} бойцов");

        }

        public bool EveryoneMovedCheck()
        {
            bool moveStatus = true;
            for (int i = 0; i < ArmyFighters.Count; i++)
            {
                if (ArmyFighters[i].Move == false)
                {
                    moveStatus = false;
                    break;
                }
            }

            return moveStatus;
        }

        public double GetPartArmy(double percent)
        {
            return Math.Ceiling(ArmyFighters.Count * percent);
        }

        public List<int> HowPartArmyDidNotMove()
        {
            var indexNumberList = new List<int>();
            for (int i = 0; i < ArmyFighters.Count; i++)
            {
                if (ArmyFighters[i].Move == false)
                {
                    indexNumberList.Add(i);
                }
            }
            return indexNumberList;
        }

        public List<int> GetSortListFasterFighter(List<int> indexNumberList) 
        {
            for (int i = 0; i < indexNumberList.Count; i++)
            {
                for (int j = 1; j < indexNumberList.Count; j++)
                {
                    if (ArmyFighters[indexNumberList[i]].Speed < ArmyFighters[indexNumberList[j]].Speed)
                    {
                        int number = indexNumberList[i];
                        indexNumberList[i] = indexNumberList[j];
                        indexNumberList[j] = number;
                    }
                }
            }
            return indexNumberList;
        }

        public void MoveZeroing()
        {
            for (var i = 0; ArmyFighters.Count > i; i++)
            {
                ArmyFighters[i].MoveZeroing();
            }
        }
    }
}
