using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KnightWar
{
    class FightController
    {
        public bool ControlWent;
        public bool WhoIsFirst()
        {
            var rand = new Random();
            if (rand.NextDouble() < 0.5)
            {
                Console.WriteLine("Начинает первая армия");
                Console.WriteLine();
                return ControlWent = true;

            }
            else
            {
                Console.WriteLine("Начинает вторая армия");
                Console.WriteLine();
                return ControlWent = false;
            }
        }

        public void Battle(List<Fighter> attackingArmy, List<Fighter> AttackedArmy, List<int> serialNumberList, double partArmy)
        {
            for (int i = 0; i < serialNumberList.Count; i++)
            {
                if (i <= partArmy  && AttackedArmy.Count > i)
                {
                    attackingArmy[serialNumberList[i]].Attack(AttackedArmy[i]);
                }
            }
        }

        public void ShowWinner(List<Fighter> ArmyFirst, List<Fighter> ArmySecond)
        {
            if (ArmySecond.Count == 0) { Console.WriteLine("Победила первая армия"); }
            else { Console.WriteLine("Победила вторая армия"); }

        }
    }
}
