internal class Plant : Being
{
    // Constructor
    public Plant(int turn) : base(turn)
    {
        reproductionModule = 2;
    }

    // ToString
    public override string ToString()
    {
        return $"Plant [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionModule}]";
    }
}