namespace KnightWar
{
    class Program
    {
        static void Main(string[] args)
        {
            var armyFirst = new Army();
            var armySecond = new Army();
            var fight = new FightController();
            var inputControl = new InputOutputController();

            inputControl.OutputGameInstruction();
            
            inputControl.InputProcessing(armyFirst);
            inputControl.InputProcessing(armySecond);

            inputControl.ShowAllArmies(armyFirst, armySecond);

            inputControl.PresEnter();

            while (armyFirst.CheckHealthArmy() && armySecond.CheckHealthArmy())
            {
                fight.StartFight(armyFirst, armySecond);
            }

            fight.ShowWinner(armyFirst.ArmyFighters);
        }
    }
}