using System;
using System.Collections.Generic;

namespace SafariApp_v2.Model
{
    internal class Safari
    {
        // Variables
        private int numPlants;
        private int numGazelles;
        private int numLions;
        
        private int numPlantsAlive;
        private int numGazellesAlive;
        private int numLionsAlive;

        private int turn; // The current turn of the safari.

        private Being[,] beings; // Matrix representing the safari area with all beings (animals, plants, empty spaces).
        private List<(Being being, int row, int col)> activeBeings; // List storing active beings with their positions.

        private Random random; // Instance of Random for generating random numbers.

        // Constructor
        ///<summary>
        /// Initializes a new instance of the Safari class, placing plants, gazelles, and lions at random positions.
        /// </summary>
        ///<param name="rows">Number of rows in the safari grid.</param>
        ///<param name="cols">Number of columns in the safari grid.</param>
        ///<param name="numPlants">Number of plants to be placed in the safari.</param>
        ///<param name="numGazelles">Number of gazelles to be placed in the safari.</param>
        ///<param name="numLions">Number of lions to be placed in the safari.</param>
        public Safari(int rows, int cols, int numPlants, int numGazelles, int numLions)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentException("Rows and columns must be positive integers.");
            }

            int totalCells = rows * cols;
            if (numPlants + numGazelles + numLions > totalCells)
            {
                throw new ArgumentException("The total number of beings exceeds the available space in the safari.");
            }

            this.numPlants = numPlants;
            this.numGazelles = numGazelles;
            this.numLions = numLions;

            numPlantsAlive = numPlants;
            numGazellesAlive = numGazelles;
            numLionsAlive = numLions;

            turn = 0;
            beings = new Being[rows, cols];
            random = new Random();

            FillBeings(); // Fill the beings array
        }


        // Getters and Setters
        public int GetTurn() { return turn; }
        public Being[,] GetBeings() { return beings; }
        public Random GetRandom() { return random; }
        public int GetNumPlantsAlive() { return numPlantsAlive; }
        public int GetNumGazellesAlive() { return numGazellesAlive; }
        public int GetNumLionsAlive() { return numLionsAlive; }

        // ToString
        public override string ToString()
        {
            return $"Safari [Turn: {turn}, Area: {beings.GetLength(0)}x{beings.GetLength(1)}]"; // String representation of the safari
        }

        // Methods
        ///<summary>
        /// Retrieves the being at the specified position in the safari matrix.
        /// </summary>
        ///<param name="row">Row index of the position to retrieve.</param>
        ///<param name="col">Column index of the position to retrieve.</param>
        ///<returns>The being at the specified position, or null if the position is out of bounds or empty.</returns>
        public Being GetBeing(int row, int col)
        {
            if (row >= 0 && row < beings.GetLength(0) && col >= 0 && col < beings.GetLength(1))
            {
                return beings[row, col]; // Return the being at the specified position
            }
            return null; // Return null if the position is out of bounds or empty
        }

        ///<summary>
        /// Adds a being at the specified position in the safari matrix.
        /// </summary>
        ///<param name="row">Row index where the being should be placed.</param>
        ///<param name="col">Column index where the being should be placed.</param>
        ///<param name="being">The being to place in the matrix. It can't be a null value.</param>
        public void AddBeing(int row, int col, Being being)
        {
            if (row >= 0 && row < beings.GetLength(0) && col >= 0 && col < beings.GetLength(1))
            {
                // Prevent setting null values in the beings array directly
                if (being == null)
                {
                    throw new ArgumentException("You cannot set a 'null' value directly in the beings array. Use 'KillBeing' method instead.");
                }

                beings[row, col] = being; // Place the being in the matrix at the specified position
            }
            else
            {
                Console.WriteLine($"Warning: Attempted to set being out of bounds at [{row}, {col}].");
            }
        }

        ///<summary>
        /// Removes a being at the specified position in the safari matrix.
        /// </summary>
        ///<param name="row">Row index where the being should be removed.</param>
        ///<param name="col">Column index where the being should be removed.</param>
        public void KillBeing(int row, int col)
        {
            // Check if the position is valid
            if (row >= 0 && row < beings.GetLength(0) && col >= 0 && col < beings.GetLength(1))
            {
                Being being = beings[row, col];

                if (being != null)
                {
                    // Additional logic that happen when a being dies
                    Console.WriteLine($"{being.GetType().Name} at [{row}, {col}] has died.");

                    // Removes being from activeBeings when its killed (lambda)
                    activeBeings.RemoveAll(b => b.row == row && b.col == col);

                    // Set the position to null, removing the being from the safari matrix
                    beings[row, col] = null;
                }
                else
                {
                    Console.WriteLine($"No being to kill at position [{row}, {col}].");
                }
            }
            else
            {
                Console.WriteLine($"Invalid position [{row}, {col}] for killing a being.");
            }
        }

        ///<summary>
        /// Clear the specified position in the safari matrix.
        /// </summary>
        ///<param name="row">Row index which should be cleared.</param>
        ///<param name="col">Column index which should be cleared.</param>
        public void ClearPosition(int row, int col)
        {
            // Check if the position is within bounds
            if (row >= 0 && row < beings.GetLength(0) && col >= 0 && col < beings.GetLength(1))
            {
                // Clear the being at the given position (set it to null)
                beings[row, col] = null;
            }
            else
            {
                Console.WriteLine($"Warning: Attempted to clear position [{row}, {col}] out of bounds.");
            }
        }

        ///<summary>
        /// Fills the beings array with plants, gazelles, and lions at random positions.
        /// This method can be reused for initializing or resetting the safari.
        /// </summary>
        private void FillBeings()
        {
            // Create a list of all possible positions
            List<(int, int)> allPositions = new List<(int, int)>();
            for (int r = 0; r < beings.GetLength(0); r++)
            {
                for (int c = 0; c < beings.GetLength(1); c++)
                {
                    allPositions.Add((r, c)); // Add each position in the grid to the list
                }
            }

            // Shuffle the positions to randomize placement
            for (int i = allPositions.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (allPositions[i], allPositions[j]) = (allPositions[j], allPositions[i]);
            }

            // Place the plants
            for (int i = 0; i < numPlants; i++)
            {
                (int row, int col) = allPositions[i];
                beings[row, col] = new Plant(this); // Create and place a Plant
            }

            // Place the gazelles
            for (int i = numPlants; i < numPlants + numGazelles; i++)
            {
                (int row, int col) = allPositions[i];
                beings[row, col] = new Gazelle(this); // Create and place a Gazelle
            }

            // Place the lions
            for (int i = numPlants + numGazelles; i < numPlants + numGazelles + numLions; i++)
            {
                (int row, int col) = allPositions[i];
                beings[row, col] = new Lion(this); // Create and place a Lion
            }
        }

        ///<summary>
        /// Simulates one turn of the safari by iterating through all active beings and executing their actions.
        /// </summary>
        public void PlayTurn()
        {
            // First, update the list of active beings
            UpdateActiveBeings();

            // Now iterate over only the active beings and perform their actions
            foreach (var (being, row, col) in activeBeings)
            {
                if (being is Animal animal)
                {
                    animal.PlayTurn(row, col, this); // Pass the position (row, col) to the PlayTurn method
                }
                else if (being is Plant plant)
                {
                    plant.PlayTurn(row, col, this); // Pass the position (row, col) to the PlayTurn method
                }
            }

            // Update stats on the end of the turn.
            UpdateStatistics();

            // Increment the turn
            turn++;
        }

        ///<summary>
        /// Updates the list of active beings, storing the positions of all living beings.
        /// </summary>
        public void UpdateActiveBeings()
        {
            activeBeings.Clear(); // Clear the list before adding the new active beings

            for (int row = 0; row < beings.GetLength(0); row++)
            {
                for (int col = 0; col < beings.GetLength(1); col++)
                {
                    Being being = beings[row, col];
                    if (being != null) // If there is a being (not null), add it to the list along with its position
                    {
                        activeBeings.Add((being, row, col)); // Add the being along with its position
                    }
                }
            }
        }

        ///<summary>
        /// Resets the safari with predefined settings.
        /// </summary>
        public void Reset()
        {
            // Clear the current beings array (set all positions to null)
            for (int row = 0; row < beings.GetLength(0); row++)
            {
                for (int col = 0; col < beings.GetLength(1); col++)
                {
                    beings[row, col] = null;
                }
            }

            // Now, reinitialize the beings array with the same number of plants, gazelles, and lions
            FillBeings(); // Reuse the FillBeings method to refill the array
            Console.WriteLine("Safari has been reset.");
        }

        ///<summary>
        /// Updates the number of plants, gazelles, and lions currently in the safari.
        /// </summary>
        ///<returns>A tuple containing the counts of plants, gazelles, and lions.</returns>
        public void UpdateStatistics()
        {
            // Restarts stats
            numPlantsAlive = 0;
            numGazellesAlive = 0;
            numLionsAlive = 0;

            // Count beings in activeBeings by type
            foreach (var (being, row, col) in activeBeings)
            {
                if (being is Plant) { numPlantsAlive++; }
                else if (being is Gazelle) { numGazellesAlive++; }
                else if (being is Lion) { numLionsAlive++; }
            }
        }
    }
}