internal class Being
{
    // Variables
    private int spawnTurn;
    private int turnsAlive;
    protected int reproductionTurns;

    // Constructor
    public Being(int turn)
    {
        spawnTurn = turn;
        turnsAlive = 0;
    }

    // Getters and Setters
    public int GetSpawnTurn() { return spawnTurn; }
    public void SetSpawnTurn(int value) { spawnTurn = value; }

    public int GetTurnsAlive() { return turnsAlive; }
    public void SetTurnsAlive(int value) { turnsAlive = value; }

    public int GetReproductionTurns() { return reproductionTurns; }
    public void SetReproductionTurns(int value) { reproductionTurns = value; }

    // ToString
    public override string ToString()
    {
        return $"Being [SpawnTurn: {spawnTurn}, TurnsAlive: {turnsAlive}, ReproductionTurns: {reproductionTurns}]";
    }

    // Methods
    public void Reproduction() { /* TODO */ }
    public void Death() { /* TODO */ }
}