using System;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;

namespace KnightWar
{
    class ArmyController
    {
        private int[] _characteristics = new int[3];

        private void AddUnknownFighter(List<Fighter> fighter, int level, int ammunition, int speed)
        {
            var randValue = new Random();
            int randNumber = randValue.Next(1, 4);
            switch (randNumber)
            {
                case 1:
                    fighter.Add(new Archer(level, ammunition, speed));
                    break;
                case 2:
                    fighter.Add(new Horseman(level, ammunition, speed));
                    break;
                case 3:
                    fighter.Add(new Infantry(level, ammunition, speed));
                    break;
            }
        }

        static string[] InputNewFighter()
        {
            var input = Console.ReadLine();
            var words = input.Split();
            while(words.Length < 5 && words[0] != "stop")
            {
                Console.WriteLine("Введены некорректные данные, попробуйте еще раз!");
                input = Console.ReadLine();
                words = input.Split();
            }
            return words;
        }

        public void AddFighterInArmy(List<Fighter> Army, string[] words)
        {

            
            FighterType fighter;
            var success = true;

            if (words[1] == "*")
            {
                fighter = FighterType.Unknown;

                for (var i = 2; i <= 4; i++)
                {
                    
                    if (words[i] == "*")
                    {
                        _characteristics[i - 2] = 0;
                    }
                    else if (!int.TryParse(words[i], out _characteristics[i - 2]))
                    {
                        Console.WriteLine("Введены некорректные данные, попробуйте еще раз!");
                        success = false;
                        break;
                        
                    }
                }
                if (success)
                {
                    AddUnknownFighter(Army, _characteristics[0], _characteristics[1], _characteristics[2]);
                }


            }
            else if (Enum.TryParse(words[1], true, out fighter))
            {
                for (var i = 2; i <= 4; i++)
                {
                    if (words[i] == "*")
                    {
                        _characteristics[i - 2] = 0;
                    }
                    else if (!int.TryParse(words[i], out _characteristics[i - 2]))
                    {
                        fighter = FighterType.Unknown;
                        break;
                    }

                }
                switch (fighter)
                {
                    case FighterType.Archer:
                        Army.Add(new Archer(_characteristics[0], _characteristics[1], _characteristics[2]));
                        break;
                    case FighterType.Horseman:
                        Army.Add(new Horseman(_characteristics[0], _characteristics[1], _characteristics[2]));
                        break;
                    case FighterType.Infantry:
                        Army.Add(new Infantry(_characteristics[0], _characteristics[1], _characteristics[2]));
                        break;
                    default:
                        Console.WriteLine("Введены некорректные данные, попробуйте еще раз!");
                        break;
                }
            } else
            {
                Console.WriteLine("Введены некорректные данные, попробуйте еще раз!");
            }
        }

        public void CreateArmies(List<Fighter> armyFirst, List<Fighter> armySecond)
        {
            bool control = false;

            Console.WriteLine("Добавьте нового бойца во первую армию, для этого введите add тип бойца: Infantry, Archer или Horseman \n" +
                     " и задайте ему желаемые характеристики уровня, брони и скорости, если хотите какую то характеристику сделать случайной введите *");
            Console.WriteLine("Введите stop, чтобы прекратить наполнение армии и перейти к следующей");

            while (control == false)
            {               
                string[] words = InputNewFighter();
                switch (words[0])
                {
                    case "add":
                        AddFighterInArmy(armyFirst, words);
                        break;
                    case "stop":
                        control = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод, попробуйте еще раз!");
                        break;
                }
            }

            control = false;

            Console.WriteLine("Добавьте нового бойца во вторую армию, для этого введите add тип бойца: Infantry, Archer или Horseman \n" +
                     " и задайте ему желаемые характеристики уровня, брони и скорости, если хотите какую то характеристику сделать случайной введите *");
            Console.WriteLine("Введите stop, чтобы прекратить наполнение армии и перейти к следующей");

            while (control == false)
            {

                string[] words = InputNewFighter();
                switch (words[0])
                {
                    case "add":
                        AddFighterInArmy(armySecond, words);
                        break;
                    case "stop":
                        control = true;
                        break;
                    default:
                        Console.WriteLine("Неверный ввод, попробуйте еще раз!");
                        break;
                }
            } 
        }
    }
}

