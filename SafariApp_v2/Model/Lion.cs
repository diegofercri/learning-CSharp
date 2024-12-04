﻿namespace SafariApp_v2.Model
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
        protected override Being CreateNewBeing(Safari safari)
        {
            return new Lion(safari);
        }
    }
}