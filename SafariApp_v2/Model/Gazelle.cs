using System;

namespace SafariApp_v2.Model
{
    internal class Gazelle : Herbivorous
    {
        // Constructor
        public Gazelle(int turn) : base(turn)
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
        protected override Being CreateNewBeing(int row, int col, int turn)
        {
            Console.WriteLine($"A new Gazelle has been placed at [{row}, {col}].");
            return new Gazelle(turn);
        }
    }
}