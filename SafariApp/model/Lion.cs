internal class Lion : Animal
{
    // Constructor
    public Lion(int turn) : base(turn)
    {
        reproductionTurns = 6;
    }

    // ToString
    public override string ToString()
    {
        return $"Lion [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionTurns}, " +
               $"TurnsWithoutFood: {GetTurnsWithoutFood()}, TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
    }
}