using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Security;

namespace KnightWar
{
    class Program
    {
        static void Main(string[] args)
        {

            var armyFirst = new Army();
            var armySecond = new Army();
            var fight = new FightController();
            var CreateFighter = new ArmyController();
            char control;

            do
            {
                Console.WriteLine("Добавьте нового бойца в первую армию, для этого введите add тип бойца: Infantry, Archer или Horseman \n" +
                    " и задайте ему желаемые характеристики уровня, брони и скорости, если хотите какую то характеристику сделать случайной введите *");
                Console.WriteLine("Если хотите добавить полностью случайного бойца введите add ****");

                CreateFighter.AddFighterInArmy(armyFirst.ArmyFighters);

                Console.WriteLine("Нажмите у чтобы добавить бойца в первую армию");
                Console.WriteLine("Нажмите n чтобы закончить заполнение первой армии и перейти ко второй");
                control = char.Parse(Console.ReadLine());
            } while (control == 'y');

            do
            {
                Console.WriteLine("Добавьте нового бойца во вторую армию, для этого введите add тип бойца: Infantry, Archer или Horseman \n" +
                    " и задайте ему желаемые характеристики уровня, брони и скорости, если хотите какую то характеристику сделать случайной введите *");
                Console.WriteLine("Если хотите добавить полностью случайного бойца введите add ****");

                CreateFighter.AddFighterInArmy(armySecond.ArmyFighters);

                Console.WriteLine("Нажмите у чтобы добавить бойца в первую армию");
                Console.WriteLine("Нажмите n чтобы закончить заполнение второй армии и перейти к битве");
                control = char.Parse(Console.ReadLine());
            } while (control == 'y');

            do
            {

                fight.WhoIsFirst();
                Thread.Sleep(700);

                do
                {
                    if (fight.ControlWent)
                    {
                        fight.Battle(armyFirst.ArmyFighters, armySecond.ArmyFighters,
                            armyFirst.GetSortListFasterFighter(armyFirst.HowPartArmyDidNotMove()), armyFirst.GetFivePercentArmy());
                        armySecond.DeleteDeadUnit();
                        fight.ControlWent = false;
                    }
                    else
                    {
                        fight.Battle(armySecond.ArmyFighters, armyFirst.ArmyFighters,
                             armySecond.GetSortListFasterFighter(armySecond.HowPartArmyDidNotMove()), armySecond.GetSixPercentArmy());
                        armyFirst.DeleteDeadUnit();
                        fight.ControlWent = true;
                    }

                    Thread.Sleep(700);

                    if (fight.ControlWent)
                    {
                        fight.Battle(armyFirst.ArmyFighters, armySecond.ArmyFighters,
                            armyFirst.GetSortListFasterFighter(armyFirst.HowPartArmyDidNotMove()), armyFirst.GetFivePercentArmy());
                        armySecond.DeleteDeadUnit();
                        fight.ControlWent = false;
                    }
                    else
                    {
                        fight.Battle(armySecond.ArmyFighters, armyFirst.ArmyFighters,
                             armySecond.GetSortListFasterFighter(armySecond.HowPartArmyDidNotMove()), armySecond.GetSixPercentArmy());
                        armyFirst.DeleteDeadUnit();
                        fight.ControlWent = true;
                    }

                    Thread.Sleep(700);

                } while (!armyFirst.EveryoneMovedCheck() && !armySecond.EveryoneMovedCheck());

                armyFirst.MoveZeroing();
                armySecond.MoveZeroing();

            } while (armyFirst.CheckHealthArmy() && armySecond.CheckHealthArmy());
            Console.WriteLine();
            fight.ShowWinner(armyFirst.ArmyFighters, armySecond.ArmyFighters); 


        }
    }
}