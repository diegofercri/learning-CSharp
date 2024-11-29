using SafariApp.model;

internal class Animal : Being
{
    // Variables
    private bool isMoved;
    private int turnsWithoutFood;
    protected int turnsWithoutFoodToDeath;

    // Constructors
    public Animal(Safari safari) : base(safari)
    {
        isMoved = false;
        turnsWithoutFood = 0;
        turnsWithoutFoodToDeath = 3;
    }
    public Animal(Safari safari, bool isChild=true) : base(safari)
    {
        if (isChild)
        {
            isMoved = true;
        }
        turnsWithoutFood = 0;
        turnsWithoutFoodToDeath = 3;
    }

    // Getters and Setters
    public bool GetIsMoved() { return isMoved; }
    public void SetIsMoved(bool value) { isMoved = value; }

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
    /// Finds and returns the positions of adjacent objects of a specified type in the area.
    /// </summary>
    /// <param name="type">The type of the objects to search for (e.g., Plant, Gazelle).</param>
    /// <param name="currentRow">The current row position of the animal.</param>
    /// <param name="currentCol">The current column position of the animal.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    /// <returns>A list of tuples containing the positions (row, column) of adjacent objects of the specified type.</returns>
    public List<(int, int)> GetAdjacentPositionsOfType(Type type, int currentRow, int currentCol, Being[,] area)
    {
        List<(int, int)> positions = new List<(int, int)>();
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
    /// Searches for food in adjacent positions. If found, moves to the food location, removes the food,
    /// and resets the hunger. If no food is found, increments the hunger.
    /// </summary>
    /// <param name="currentRow">The current row of the animal.</param>
    /// <param name="currentCol">The current column of the animal.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    public void PlayTurn(int currentRow, int currentCol, Being[,] area)
    {
        Type foodType = this is Gazelle ? typeof(Plant) : (this is Lion ? typeof(Gazelle) : null);

        if (needsToReproduce)
        {
            Reproduction(currentRow, currentCol, area);
        }

        // Find adjacent positions containing the desired type of food
        List<(int, int)> foodPositions = GetAdjacentPositionsOfType(foodType, currentRow, currentCol, area);

        if (foodPositions.Count == 1)
        {
            // Move directly to the only available food position
            (int foodRow, int foodCol) = foodPositions[0];
            MoveToPosition(currentRow, currentCol, foodRow, foodCol, area);
            SetTurnsWithoutFood(0); // Reset hunger
        }
        else if (foodPositions.Count > 1)
        {
            // Select a random food position when there are multiple options
            Random random = safari.GetRandom();
            int randomIndex = random.Next(foodPositions.Count);
            (int foodRow, int foodCol) = foodPositions[randomIndex];
            MoveToPosition(currentRow, currentCol, foodRow, foodCol, area);
            SetTurnsWithoutFood(0); // Reset hunger
        }
        else
        {
            // No food found: death or increment hunger
            if (GetTurnsWithoutFood() == turnsWithoutFoodToDeath)
            {
                // TODO
                Death();
            }
            else
            {
                IncrementTurnsWithoutFood();
                Move(currentRow, currentCol, area);
            }
        }
    }

    /// <summary>
    /// Searches for empty positions in adjacent positions. If found, moves to the empty location and clear the
    /// previous position.
    /// </summary>
    /// <param name="currentRow">The current row of the animal.</param>
    /// <param name="currentCol">The current column of the animal.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    public void Move(int currentRow, int currentCol, Being[,] area)
    {
        // Find adjacent empty positions
        List<(int, int)> emptyPositions = GetAdjacentEmptyPositions(currentRow, currentCol, area);

        if (emptyPositions.Count == 1)
        {
            // Move directly to the only available position
            (int emptyRow, int emptyCol) = emptyPositions[0];
            MoveToPosition(currentRow, currentCol, emptyRow, emptyCol, area);
        }
        else if (emptyPositions.Count > 1)
        {
            // Select a random empty position when there are multiple options
            Random random = safari.GetRandom();
            int randomIndex = random.Next(emptyPositions.Count);
            (int emptyRow, int emptyCol) = emptyPositions[randomIndex];
            MoveToPosition(currentRow, currentCol, emptyRow, emptyCol, area);
            SetTurnsWithoutFood(0); // Reset hunger
        }
    }

    /// <summary>
    /// Moves the animal to the specified position and clears the previous position in the area.
    /// </summary>
    /// <param name="currentRow">The current row of the animal.</param>
    /// <param name="currentCol">The current column of the animal.</param>
    /// <param name="newRow">The row of the new position.</param>
    /// <param name="newCol">The column of the new position.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    private void MoveToPosition(int currentRow, int currentCol, int newRow, int newCol, Being[,] area)
    {
        area[newRow, newCol] = this; // Place the animal in the new position
        area[currentRow, currentCol] = null; // Clear the old position
        isMoved = true;
        // TODO
        Reproduction(newRow, newCol, area);
    }

    /// <summary>
    /// Increments the turns without food for the animal.
    /// </summary>
    public void IncrementTurnsWithoutFood()
    {
        SetTurnsWithoutFood(GetTurnsWithoutFood() + 1);
    }
}