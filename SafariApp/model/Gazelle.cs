internal class Gazelle : Animal
{
    // Constructor
    public Gazelle(int turn) : base(turn)
    {
        reproductionTurns = 4;
    }

    // ToString
    public override string ToString()
    {
        return $"Gazelle [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionTurns}, " +
               $"TurnsWithoutFood: {GetTurnsWithoutFood()}, TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
    }
}