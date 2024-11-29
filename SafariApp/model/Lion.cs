internal class Lion : Animal
{
    // Constructor
    public Lion(int turn) : base(turn)
    {
        reproductionModule = 6;
    }

    // ToString
    public override string ToString()
    {
        return $"Lion [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionModule}, " +
               $"TurnsWithoutFood: {GetTurnsWithoutFood()}, TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
    }
}