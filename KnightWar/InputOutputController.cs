namespace KnightWar
{
    public class InputOutputController
    {
        private int[] _characteristics = new int[3];
        private FighterType _fighterType;
        private string[] _arrayStr;

        private const int _maxLength = 5;
        private const int _longDelay = 2000;
        private const int _shortDelay = 700;
        private const int _wordFirst = 0;
        private const int _wordSecond = 1;
        private const int _wordThird = 2;

        private string[] InputNewFighter()
        {
            var success = false;
            while (!success)
            {
                var input = Console.ReadLine();
                _arrayStr = input.Split();
                if (_arrayStr.Length != _maxLength  && _arrayStr[_wordFirst] != "stop")
                {
                    Console.WriteLine("Введены некорректные данные, попробуйте еще раз! 0");
                }
                else
                {
                    success = true;
                }
            }
            return _arrayStr;
        }

        private bool InputParse(string[] arrayStr)
        {
            if (arrayStr[_wordFirst] == "stop")
            {
                return true;
            }
            if (arrayStr[_wordFirst] != "add")
            {
                Console.WriteLine("Ошибка! Некорректный ввод, попробуйте еще раз. 1");
                return false;
            }
            if (arrayStr[_wordSecond] == "*")
            {
                _fighterType = FighterType.Unknown;
            }
            else if (!Enum.TryParse(arrayStr[_wordSecond], true, out _fighterType))
            {
                Console.WriteLine("Ошибка! Некорректный ввод, попробуйте еще раз. 2");
                return false;
            }
            for (int i = _wordThird; i < arrayStr.Length; i++)
            {
                if (arrayStr[i] == "*")
                {
                    _characteristics[i - _wordThird] = 0;
                }
                else if (!int.TryParse(arrayStr[i], out _characteristics[i - _wordThird]))
                {
                    Console.WriteLine("Введены некорректные данные, попробуйте еще раз. 3");
                    return false;
                }
            }
            return true;
        }

        public void InputProcessing(Army army)
        {
            var control = false;
            var armyControl = new ArmyController();
            string[] arrayStr;

            while (control == false)
            {
                do
                {
                    arrayStr = InputNewFighter();
                } while (!InputParse(arrayStr));

                switch (arrayStr[0])
                {
                    case "add":
                        armyControl.AddFighterInArmy(army.ArmyFighters, _fighterType, _characteristics);
                        Console.WriteLine("Боец добавлен.");
                        break;
                    case "stop":
                        control = true;
                        break;
                }
            }
            Console.WriteLine("Армия заполнена.");
        }

        public void ShowAllArmies(Army firstArmy, Army secondArmy)
        {
            Console.WriteLine();
            Console.WriteLine("Бойцы первой армии:\n");
            PrintArmy(firstArmy.ArmyFighters);
            Console.WriteLine();
            Thread.Sleep(_longDelay);
            Console.WriteLine("Бойцы второй армии:\n");
            PrintArmy(secondArmy.ArmyFighters);
            Thread.Sleep(_longDelay);
        }

        public void OutputGameInstruction()
        {
            Console.WriteLine("Добавьте нового бойца в первую армию, для этого введите add тип бойца: Infantry, Archer или Horseman \n" +
                     "и задайте ему желаемые характеристики уровня, брони и скорости,\n если хотите какую то характеристику сделать случайной введите *");
            Console.WriteLine("Введите stop, чтобы прекратить наполнение армии и перейти к следующей.");
        }

        public void PresEnter()
        {
            Console.WriteLine("\nНажмите Enter чтобы начать бой.");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
            {
            }
        }

        static void PrintArmy(List<Fighter> fighters)
        {
            int amountFighters = 0;

            for (var i = 0; i < fighters.Count; i++)
            {
                fighters[i].Print();
                amountFighters += 1;
                Thread.Sleep(_shortDelay);
            }
            Console.WriteLine($"\nЧисленность армии: {amountFighters}");
        }
    }
}
