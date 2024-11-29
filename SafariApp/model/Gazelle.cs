internal class Gazelle : Animal
{
    // Constructor
    public Gazelle(int turn) : base(turn)
    {
        reproductionModule = 4;
    }

    // ToString
    public override string ToString()
    {
        return $"Gazelle [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionModule}, " +
               $"TurnsWithoutFood: {GetTurnsWithoutFood()}, TurnsWithoutFoodToDeath: {GetTurnsWithoutFoodToDeath()}]";
    }
}