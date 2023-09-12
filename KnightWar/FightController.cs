using System;

namespace KnightWar
{
    class FightController
    {
        private bool _controlWent;
        private bool WhoIsFirst()
        {
            var rand = new Random();
            if (rand.NextDouble() < 0.5)
            {
                Console.WriteLine("Начинает первая армия");
                Console.WriteLine();
                return _controlWent = true;

            }
            else
            {
                Console.WriteLine("Начинает вторая армия");
                Console.WriteLine();
                return _controlWent = false;
            }
        }

        private void Battle(Army attackingArmy, Army AttackedArmy, List<int> serialNumberList, double partArmy)
        {
            var rand = new Random();
            for (int i = 0; i < serialNumberList.Count; i++)
            {
                if (i <= partArmy)
                {
                    attackingArmy.ArmyFighters[serialNumberList[i]].Attack(AttackedArmy, rand.Next(AttackedArmy.ArmyFighters.Count));
                }
            }
        }

        public void StartFight(Army armyFirst, Army armySecond)
        {
            do
            {
                if (WhoIsFirst())
                {
                    Battle(armyFirst, armySecond,
                        armyFirst.GetSortListFasterFighter(armyFirst.HowPartArmyDidNotMove()), armyFirst.GetPartArmy(0.05));
                    armySecond.DeleteDeadUnit();
                    _controlWent = false;
                }
                else
                {
                    Battle(armySecond, armyFirst,
                         armySecond.GetSortListFasterFighter(armySecond.HowPartArmyDidNotMove()), armySecond.GetPartArmy(0.06));
                    armyFirst.DeleteDeadUnit();
                    _controlWent = true;
                }

                Thread.Sleep(700);

                if (_controlWent)
                {
                    Battle(armyFirst, armySecond,
                        armyFirst.GetSortListFasterFighter(armyFirst.HowPartArmyDidNotMove()), armyFirst.GetPartArmy(0.05));
                    armySecond.DeleteDeadUnit();
                    _controlWent = false;
                }
                else
                {
                    Battle(armySecond, armyFirst,
                         armySecond.GetSortListFasterFighter(armySecond.HowPartArmyDidNotMove()), armySecond.GetPartArmy(0.06));
                    armyFirst.DeleteDeadUnit();
                    _controlWent = true;
                }

                Thread.Sleep(700);

            } while (!armyFirst.EveryoneMovedCheck() && !armySecond.EveryoneMovedCheck());

            armyFirst.MoveZeroing();
            armySecond.MoveZeroing();
        }

        public void ShowWinner(List<Fighter> ArmyFirst)
        {
            if (ArmyFirst.Count == 0) { Console.WriteLine("Победила первая армия"); }
            else { Console.WriteLine("Победила вторая армия"); }

        }
    }
}
