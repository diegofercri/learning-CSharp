/* Examen 1 */
using System;

namespace SafariApp_v2.Model
{
    internal class Elephant : Herbivorous
    {
        // Constructor
        public Elephant(int turn) : base(turn)
        {
            reproductionModule = 4;  // The Elephant reproduces every 4 turns.
        }

        // ToString
        public string ToString(int row, int col)
        {
            return $"Elephant [Position: ({row}, {col}), SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, " +
                   $"ReproductionTurns: {reproductionModule}, TurnsWithoutFood: {GetTurnsWithoutFood()}, " +
                   $"TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
        }

        // Methods
        protected override Being CreateNewBeing(int row, int col, int turn)
        {
            Console.WriteLine($"A new Elephant has been placed at [{row}, {col}].");
            return new Elephant(turn);
        }
    }
}