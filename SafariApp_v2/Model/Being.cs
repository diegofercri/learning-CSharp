using System;
using System.Collections.Generic;

namespace SafariApp_v2.Model
{
    internal class Being
    {
        // Variables
        private int spawnTurn;
        private int turnsAlive;
        protected int reproductionModule;
        protected bool needsToReproduce;

        // Constructor
        public Being(Safari safari)
        {
            spawnTurn = safari.GetTurn();
            turnsAlive = 0;
            needsToReproduce = false;
        }

        // Getters and Setters
        public int GetSpawnTurn() { return spawnTurn; }
        public int GetTurnsAlive() { return turnsAlive; }

        // ToString
        public override string ToString()
        {
            return $"Being [SpawnTurn: {spawnTurn}, TurnsAlive: {turnsAlive}, ReproductionTurns: {reproductionModule}]";
        }

        // Updaters
        /// <summary>
        /// Updates the number of turns the being has been alive based on the current safari turn.
        /// </summary>
        /// <param name="safari">The current instance of the safari.</param>
        public void UpdateTurnsAlive(Safari safari)
        {
            turnsAlive = safari.GetTurn() - spawnTurn;
        }


        // Methods

        #region Helper Methods

        /// <summary>
        /// Finds and returns the positions of adjacent objects of a specified type in the area.
        /// </summary>
        /// <param name="type">The type of the objects to search for (e.g., Plant, Gazelle).</param>
        /// <param name="currentRow">The current row position of the animal.</param>
        /// <param name="currentCol">The current column position of the animal.</param>
        /// <param name="safari">The current instace of safari.</param>
        /// <returns>A list of tuples containing the positions (row, column) of adjacent objects of the specified type.</returns>
        protected List<(int, int)> GetAdjacentPositionsOfType(Type type, int currentRow, int currentCol, Safari safari)
        {
            List<(int, int)> positions = new List<(int, int)>();
            Being[,] area = safari.GetBeings();
            int rows = area.GetLength(0); // Total rows in the area
            int cols = area.GetLength(1); // Total columns in the area

            // Define possible adjacent movements (up, down, left, right, and diagonals)
            int[] dRow = { -1, 1, 0, 0, -1, -1, 1, 1 }; // Vertical and diagonal movements
            int[] dCol = { 0, 0, -1, 1, -1, 1, -1, 1 }; // Horizontal and diagonal movements

            // Iterate through all possible adjacent positions
            for (int i = 0; i < dRow.Length; i++)
            {
                int newRow = currentRow + dRow[i];
                int newCol = currentCol + dCol[i];

                // Check if the new position is within bounds
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    // Check if the object at the new position matches the specified type
                    if (area[newRow, newCol] != null && area[newRow, newCol].GetType() == type)
                    {
                        positions.Add((newRow, newCol)); // Add the position to the result
                    }
                }
            }

            return positions;
        }

        /// <summary>
        /// Finds and returns the positions of adjacent empty positions in the area.
        /// </summary>
        /// <param name="currentRow">The current row position of the animal.</param>
        /// <param name="currentCol">The current column position of the animal.</param>
        /// <param name="safari">The current instace of safari.</param>
        /// <returns>A list of tuples containing the positions (row, column) of adjacent empty positions.</returns>
        protected List<(int, int)> GetAdjacentEmptyPositions(int currentRow, int currentCol, Safari safari)
        {
            List<(int, int)> positions = new List<(int, int)>();

            Being[,] area = safari.GetBeings();
            int rows = area.GetLength(0);
            int cols = area.GetLength(1);

            int[] dRow = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] dCol = { 0, 0, -1, 1, -1, 1, -1, 1 };

            for (int i = 0; i < dRow.Length; i++)
            {
                int newRow = currentRow + dRow[i];
                int newCol = currentCol + dCol[i];

                if (safari.GetBeing(newRow, newCol) == null)
                {
                    positions.Add((newRow, newCol));
                }
            }

            return positions;
        }

        /// <summary>
        /// Selects a position from a list of positions. If only one position exists, it is returned.
        /// If multiple positions exist, a random one is chosen using Safari's Random instance.
        /// </summary>
        /// <param name="positions">A list of positions to choose from.</param>
        /// <param name="safari">The current instance of Safari to access its Random instance.</param>
        /// <returns>A tuple containing the selected position (row, column), or null if no positions are available.</returns>
        protected (int, int)? SelectRandomOrSinglePosition(List<(int, int)> positions, Safari safari)
        {
            if (positions.Count == 1)
            {
                return positions[0];
            }
            else if (positions.Count > 1)
            {
                Random random = safari.GetRandom();
                int randomIndex = random.Next(positions.Count);
                return positions[randomIndex];
            }

            return null; // No valid positions available
        }

        #endregion

        #region Main Methods

        ///<summary>
        /// Handles the general actions of a living being during its turn.
        /// This method must be overridden by derived classes to implement specific behavior.
        /// </summary>
        ///<param name="currentRow">The current row position of the being.</param>
        ///<param name="currentCol">The current column position of the being.</param>
        ///<param name="safari">The current instance of the safari.</param>
        public virtual void PlayTurn(int currentRow, int currentCol, Safari safari)
        {
            UpdateTurnsAlive(safari);
        }

        /// <summary>
        /// Removes the being from the Safari area by clearing its position in the matrix.
        /// </summary>
        /// <param name="currentRow">The current row of the being.</param>
        /// <param name="currentCol">The current column of the being.</param>
        /// <param name="safari">The current instance of Safari.</param>
        public void Death(int currentRow, int currentCol, Safari safari)
        {
            if (safari.GetBeing(currentRow, currentCol) == this)
            {
                safari.KillBeing(currentRow, currentCol); // Clear the position
            }
            else
            {
                Console.WriteLine($"Error: Being at [{currentRow}, {currentCol}] does not match the expected being.");
            }
        }

        /// <summary>
        /// Attempts to reproduce a new being in an adjacent empty position if the being is eligible.
        /// </summary>
        /// <param name="currentRow">The current row of the being.</param>
        /// <param name="currentCol">The current column of the being.</param>
        /// <param name="safari">The current instance of Safari.</param>
        protected void Reproduction(int currentRow, int currentCol, Safari safari)
        {
            // Check if the being is eligible to reproduce
            if (GetTurnsAlive() == 0 || GetTurnsAlive() % reproductionModule != 0)
            {
                return; // Not eligible to reproduce
            }

            List<(int, int)> emptyPositions = GetAdjacentEmptyPositions(currentRow, currentCol, safari); // Find adjacent empty positions
            (int, int)? targetPosition = SelectRandomOrSinglePosition(emptyPositions, safari); // Select adjacent empty positions

            // Reproduce if there is empty positions else waits to reproduce
            if (targetPosition.HasValue)
            {
                (int emptyRow, int emptyCol) = targetPosition.Value;
                PlaceNewBeing(emptyRow, emptyCol, safari);
                needsToReproduce = false; // Reset flag
            }
            else
            {
                needsToReproduce = true; // Set flag for the next turn
                Console.WriteLine($"Being at [{currentRow}, {currentCol}] could not reproduce.");
            }
        }

        /// <summary>
        /// Creates a new being and places it in the specified position in the area.
        /// </summary>
        /// <param name="row">The row of the new being's position.</param>
        /// <param name="col">The column of the new being's position.</param>
        /// <param name="safari">The current instace of safari.</param>
        protected void PlaceNewBeing(int row, int col, Safari safari)
        {
            Being newBeing = CreateNewBeing(safari);
            safari.AddBeing(row, col, newBeing);
            Console.WriteLine($"A new being has been placed at [{row}, {col}].");
        }

        /// <summary>
        /// Creates a new instance of a being. This should be overridden in specific derived classes to create the appropriate type of being.
        /// </summary>
        /// <param name="safari">The current instance of Safari.</param>
        /// <returns>A new being instance.</returns>
        protected virtual Being CreateNewBeing(Safari safari)
        {
            // Default behavior - can be overridden
            return new Being(safari);
        }

        #endregion
    }
}