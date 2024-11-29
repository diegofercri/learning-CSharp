using SafariApp.model;

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
    public void SetSpawnTurn(int value) { spawnTurn = value; }

    public int GetTurnsAlive() { return turnsAlive; }
    public void SetTurnsAlive(int value) { turnsAlive = value; }

    public int GetReproductionTurns() { return reproductionModule; }
    public void SetReproductionTurns(int value) { reproductionModule = value; }
    public bool GetNeedsToReproduce() { return needsToReproduce; }
    public void SetNeedsToReproduce(bool value) { needsToReproduce = value; }

    // ToString
    public override string ToString()
    {
        return $"Being [SpawnTurn: {spawnTurn}, TurnsAlive: {turnsAlive}, ReproductionTurns: {reproductionModule}]";
    }

    // Methods
    /// <summary>
    /// Finds and returns the positions of adjacent empty positions in the area.
    /// </summary>
    /// <param name="currentRow">The current row position of the animal.</param>
    /// <param name="currentCol">The current column position of the animal.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    /// <returns>A list of tuples containing the positions (row, column) of adjacent empty positions.</returns>
    public List<(int, int)> GetAdjacentEmptyPositions(int currentRow, int currentCol, Being[,] area)
    {
        List<(int, int)> positions = new List<(int, int)>();
        int rows = area.GetLength(0);
        int cols = area.GetLength(1);

        int[] dRow = { -1, 1, 0, 0, -1, -1, 1, 1 };
        int[] dCol = { 0, 0, -1, 1, -1, 1, -1, 1 };

        for (int i = 0; i < dRow.Length; i++)
        {
            int newRow = currentRow + dRow[i];
            int newCol = currentCol + dCol[i];

            if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && area[newRow, newCol] == null)
            {
                positions.Add((newRow, newCol));
            }
        }

        return positions;
    }

    /// <summary>
    /// Attempts to reproduce a new being in an adjacent empty position if the being is eligible.
    /// Eligibility is determined by checking if (turnsAlive % reproductionTurns == 0).
    /// </summary>
    /// <param name="currentRow">The current row of the being.</param>
    /// <param name="currentCol">The current column of the being.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    /// <param name="safari">The current instace of safari.</param>
    public void Reproduction(int currentRow, int currentCol, Being[,] area, Safari safari)
    {
        // Check if the being is eligible to reproduce
        if (GetTurnsAlive() == 0 || GetTurnsAlive() % reproductionModule != 0)
        {
            return; // Not eligible to reproduce
        }

        // Find adjacent empty positions
        List<(int, int)> emptyPositions = GetAdjacentEmptyPositions(currentRow, currentCol, area);

        if (emptyPositions.Count == 1)
        {
            // If only one empty position, reproduce there
            (int emptyRow, int emptyCol) = emptyPositions[0];
            PlaceNewBeing(emptyRow, emptyCol, area, safari);
            needsToReproduce = false; // Reset flag
        }
        else if (emptyPositions.Count > 1)
        {
            // If multiple empty positions, select one randomly
            Random random = safari.GetRandom();
            int randomIndex = random.Next(emptyPositions.Count);
            (int emptyRow, int emptyCol) = emptyPositions[randomIndex];
            PlaceNewBeing(emptyRow, emptyCol, area, safari);
            needsToReproduce = false; // Reset flag
        }
        else
        {
            // If no empty positions, reproduction is not possible
            needsToReproduce = true; // Set flag for the next turn
            Console.WriteLine($"Being at [{currentRow}, {currentCol}] could not reproduce.");
        }
    }

    /// <summary>
    /// Creates a new being and places it in the specified position in the area.
    /// </summary>
    /// <param name="row">The row of the new being's position.</param>
    /// <param name="col">The column of the new being's position.</param>
    /// <param name="area">The 2D array representing the safari area.</param>
    /// <param name="safari">The current instace of safari.</param>
    private void PlaceNewBeing(int row, int col, Being[,] area, Safari safari)
    {
        // Create a new being instance (override CreateNewBeing in subclasses for specific behavior)
        Being newBeing = CreateNewBeing(safari);
        area[row, col] = newBeing; // Place the new being in the specified position
    }

    /// <summary>
    /// Creates a new being instance. This method can be overridden by subclasses to specify the type of the new being.
    /// </summary>
    /// <param name="safari">The current instace of safari.</param>
    /// <returns>A new being instance.</returns>
    protected virtual Being CreateNewBeing(Safari safari)
    {
        return new Being(safari); // Default behavior: create a generic Being
    }

    public void Death() { /* TODO */ }
}