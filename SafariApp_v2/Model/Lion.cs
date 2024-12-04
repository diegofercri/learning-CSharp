using System;

namespace SafariApp_v2.Model
{
    internal class Lion : Animal
    {
        // Constructor
        public Lion(Safari safari) : base(safari)
        {
            reproductionModule = 6;  // The lion reproduces every 6 turns.
        }

        // ToString
        public string ToString(int row, int col)
        {
            return $"Lion [Position: ({row}, {col}), SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, " +
                   $"ReproductionTurns: {reproductionModule}, TurnsWithoutFood: {GetTurnsWithoutFood()}, " +
                   $"TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
        }

        //Methods
        protected override Being CreateNewBeing(int row, int col, Safari safari)
        {
            Console.WriteLine($"A new Gazelle has been placed at [{row}, {col}].");
            return new Lion(safari);
        }
    }
}