namespace KnightWar
{
    public class Army
    {
        public List<Fighter> ArmyFighters = new List<Fighter>();
       
        public bool CheckHealthArmy()
        {
            return ArmyFighters.Count > 0;
        }

        public void DeleteDeadUnit()
        {
            int countUnit = 0;
  
            for (int i = ArmyFighters.Count - 1; i >= 0; i--)
            {
                if (ArmyFighters[i].Health <= 0)
                {
                    ArmyFighters.RemoveAt(i);
                    countUnit++;
                }
            }
            Console.WriteLine($"Погибло {countUnit} бойцов");
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

        public void ResetUnitMove()
        {
            for (var i = 0; ArmyFighters.Count > i; i++)
            {
                ArmyFighters[i].ResetUnitMove();
            }
        }
    }
}
