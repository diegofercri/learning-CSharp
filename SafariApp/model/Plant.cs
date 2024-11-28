internal class Plant : Being
{
    // Constructor
    public Plant(int turn) : base(turn)
    {
        reproductionTurns = 2;
    }

    // ToString
    public override string ToString()
    {
        return $"Plant [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionTurns}]";
    }
}