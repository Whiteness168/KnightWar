using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            if (ArmyFighters.Count > 0) { return true; }
            else { return false; }
        }

        public void DeleteDeadUnit()
        {
            int CountUnit = 0;
            for (int i = ArmyFighters.Count; i > ArmyFighters.Count; i--)
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
            int moveValue = 0;
            for (int i = 0; i < ArmyFighters.Count; i++)
            {
                if (ArmyFighters[i].Move > 0)
                {
                    moveValue++;
                }
            }

            return !(ArmyFighters.Count > moveValue);
            //if (ArmyFighters.Count > moveValue)
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public double GetFivePercentArmy()
        {
            double partArmy = ArmyFighters.Count;
            return partArmy = Math.Ceiling(partArmy * 0.05);
        }

        public double GetSixPercentArmy()
        {
            double partArmy = ArmyFighters.Count;
            return partArmy = Math.Ceiling(partArmy * 0.06);
        }

        public List<int> HowPartArmyDidNotMove()
        {
            var serialNumber = new List<int>();
            for (int i = 0; i < ArmyFighters.Count; i++)
            {
                if (ArmyFighters[i].Move == 0)
                {
                    serialNumber.Add(i);
                }
            }
            return serialNumber;
        }

        public List<int> GetSortListFasterFighter(List<int> serialNumberList)
        {
            for (int i = 0; i < serialNumberList.Count; i++)
            {
                for (int j = 1; j < serialNumberList.Count; j++)
                {
                    if (ArmyFighters[serialNumberList[i]].Speed < ArmyFighters[serialNumberList[j]].Speed)
                    {
                        int number = serialNumberList[i];
                        serialNumberList[i] = serialNumberList[j];
                        serialNumberList[j] = number;
                    }
                }
            }
            return new List<int>(serialNumberList);
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
