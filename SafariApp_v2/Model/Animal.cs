using System.Collections.Generic;
using System;

namespace SafariApp_v2.Model
{
    internal abstract class Animal : Being
    {
        // Variables
        private int turnsWithoutFood;
        protected int turnsWithoutFoodToDeath;

        // Constructors
        public Animal(Safari safari) : base(safari)
        {
            turnsWithoutFood = 0;
            turnsWithoutFoodToDeath = 3;  // Default to 3 turns before death without food
        }

        // Getters and Setters

        public int GetTurnsWithoutFood() { return turnsWithoutFood; }
        public void SetTurnsWithoutFood(int value) { turnsWithoutFood = value; }

        public int GetTurnsWithoutFoodToDeath() { return turnsWithoutFoodToDeath; }
        public void SetTurnsWithoutFoodToDeath(int value) { turnsWithoutFoodToDeath = value; }

        // ToString
        public override string ToString()
        {
            return $"Animal [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionModule}, " +
                   $"TurnsWithoutFood: {turnsWithoutFood}, TurnsWithoutFoodToDeath: {turnsWithoutFoodToDeath}]";
        }

        // Methods
        /// <summary>
        /// Handles the animal's behavior during its turn, including reproduction, finding food, and movement.
        /// </summary>
        /// <param name="currentRow">The current row of the animal.</param>
        /// <param name="currentCol">The current column of the animal.</param>
        /// <param name="safari">The current instance of Safari.</param>
        public override void PlayTurn(int currentRow, int currentCol, Safari safari)
        {
            // If the animal needs to reproduce, it attempts to do so.
            if (needsToReproduce)
            {
                Reproduction(currentRow, currentCol, safari);
            }

            turnsAlive++;

            // Determine the type of food the animal is looking for
            Type foodType = this is Gazelle ? typeof(Plant) : (this is Lion ? typeof(Gazelle) : null);
            List<(int, int)> foodPositions = GetAdjacentPositionsOfType(foodType, currentRow, currentCol, safari);

            // Select a random position from the list of food positions
            (int, int)? targetPosition = SelectRandomOrSinglePosition(foodPositions, safari);

            // Move to the food if found or handle hunger/death
            if (targetPosition.HasValue)
            {
                (int foodRow, int foodCol) = targetPosition.Value;

                // Call Death on the Being eaten
                Being food = safari.GetBeing(foodRow, foodCol);
                if (food != null)
                {
                    food.Death(foodRow, foodCol, safari);
                }

                // Move to the food's position and reset hunger
                MoveToPosition(currentRow, currentCol, foodRow, foodCol, safari);
                SetTurnsWithoutFood(0); // Reset hunger after eating
            }
            else
            {
                // If no food is found, the animal may starve to death if it hasn't eaten in enough turns
                if (GetTurnsWithoutFood() == turnsWithoutFoodToDeath)
                {
                    Death(currentRow, currentCol, safari); // The animal dies due to starvation
                }
                else
                {
                    IncrementTurnsWithoutFood(); // Increment the hunger counter
                    Move(currentRow, currentCol, safari); // Move to a new position
                }
            }

            Reproduction(currentRow, currentCol, safari);
        }

        /// <summary>
        /// Searches for empty positions in adjacent cells. If an empty position is found, the animal moves there.
        /// </summary>
        /// <param name="currentRow">The current row of the animal.</param>
        /// <param name="currentCol">The current column of the animal.</param>
        /// <param name="safari">The current instance of Safari.</param>
        private void Move(int currentRow, int currentCol, Safari safari)
        {
            // Find adjacent empty positions
            List<(int, int)> emptyPositions = GetAdjacentEmptyPositions(currentRow, currentCol, safari);

            // Select a random position from the list of empty positions
            (int, int)? targetPosition = SelectRandomOrSinglePosition(emptyPositions, safari);

            // If an empty position is found, move there
            if (targetPosition.HasValue)
            {
                (int newRow, int newCol) = targetPosition.Value;
                MoveToPosition(currentRow, currentCol, newRow, newCol, safari);
            }
        }

        /// <summary>
        /// Moves the animal to the specified position and clears the previous position in the area.
        /// </summary>
        /// <param name="currentRow">The current row of the animal.</param>
        /// <param name="currentCol">The current column of the animal.</param>
        /// <param name="newRow">The row of the new position.</param>
        /// <param name="newCol">The column of the new position.</param>
        /// <param name="safari">The current instance of Safari.</param>
        private void MoveToPosition(int currentRow, int currentCol, int newRow, int newCol, Safari safari)
        {
            // Set the animal in the new position
            safari.SetBeing(newRow, newCol, this);
            // Clear the old position
            safari.ClearPosition(currentRow, currentCol);
            // Attempt reproduction in the new position
            Reproduction(newRow, newCol, safari);
        }

        /// <summary>
        /// Increments the turns without food counter for the animal.
        /// </summary>
        private void IncrementTurnsWithoutFood()
        {
            // Increase the turns without food counter by 1
            SetTurnsWithoutFood(GetTurnsWithoutFood() + 1);
        }
    }
}