namespace KnightWar
{
    public class FightController
    {
        private bool _controlWent;
        private const int _delay = 700;
        private const double _percentFirstAttack = 0.05;
        private const double _percentSecondAttack = 0.06;

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

        private void Battle(Army attackingArmy, Army attackedArmy, List<int> indexList, double partArmy)
        {
            var rand = new Random();
            for (int i = 0; i < indexList.Count; i++)
            {
                if (i <= partArmy)
                {
                    attackingArmy.ArmyFighters[indexList[i]].Attack(attackedArmy, rand.Next(attackedArmy.ArmyFighters.Count));
                }
            }
        }

        public void StartFight(Army armyFirst, Army armySecond)
        {
            do
            {
                WhoIsFirst();
                var moveControl = 0;

                while (moveControl != 2) 
                {
                    if (_controlWent == true)
                    {
                        Battle(armyFirst, armySecond,
                            armyFirst.GetSortListFasterFighter(armyFirst.HowPartArmyDidNotMove()), armyFirst.GetPartArmy(_percentFirstAttack));
                        armySecond.DeleteDeadUnit();
                        _controlWent = false;
                        moveControl += 1;
                    }
                    else if (_controlWent == false)
                    {
                        Battle(armySecond, armyFirst,
                             armySecond.GetSortListFasterFighter(armySecond.HowPartArmyDidNotMove()), armySecond.GetPartArmy(_percentSecondAttack));
                        armyFirst.DeleteDeadUnit();
                        _controlWent = true;
                        moveControl += 1;
                    }
                }
                Thread.Sleep(_delay);
            } while (!armyFirst.EveryoneMovedCheck() && !armySecond.EveryoneMovedCheck());

            armyFirst.ResetUnitMove();
            armySecond.ResetUnitMove();
        }

        public void ShowWinner(List<Fighter> fighters)
        {
            if (fighters.Count == 0)
            {
                Console.WriteLine("\nПобедила первая армия");
            }
            else 
            {
                Console.WriteLine("\nПобедила вторая армия");
            }
        }
    }
}
