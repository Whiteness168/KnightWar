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

        public void Battle(Army attackingArmy, Army AttackedArmy, List<int> serialNumberList, double partArmy)
        {
            var rand = new Random();
            for (int i = 0; i < serialNumberList.Count; i++)
            {
                if (i <= partArmy)
                {
                    attackingArmy.ArmyFighters[serialNumberList[i]].Attack(AttackedArmy, rand.Next(0, AttackedArmy.ArmyFighters.Count));
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
