using System;

namespace SafariApp_v2.Model
{
    internal class Gazelle : Animal
    {
        // Constructor
        public Gazelle(Safari safari) : base(safari)
        {
            reproductionModule = 4;  // The gazelle reproduces every 4 turns.
        }

        // ToString
        public string ToString(int row, int col)
        {
            return $"Gazelle [Position: ({row}, {col}), SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, " +
                   $"ReproductionTurns: {reproductionModule}, TurnsWithoutFood: {GetTurnsWithoutFood()}, " +
                   $"TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
        }

        // Methods
        protected override Being CreateNewBeing(int row, int col, Safari safari)
        {
            Console.WriteLine($"A new Gazelle has been placed at [{row}, {col}].");
            return new Gazelle(safari);
        }
    }
}