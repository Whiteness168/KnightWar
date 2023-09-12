using System;

namespace KnightWar
{
    class Program
    {
        static void Main(string[] args)
        {

            var armyFirst = new Army();
            var armySecond = new Army();
            var createArmies = new ArmyController();
            var fight = new FightController();

            createArmies.CreateArmies(armyFirst.ArmyFighters, armySecond.ArmyFighters);

            while (armyFirst.CheckHealthArmy() && armySecond.CheckHealthArmy())
            {
                fight.StartFight(armyFirst, armySecond);
            }

             Console.WriteLine();

             fight.ShowWinner(armyFirst.ArmyFighters); 


        }
    }
}