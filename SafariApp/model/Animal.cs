internal class Animal : Being
{
    // Variables
    private int turnsWithoutFood;
    protected int turnsWithoutFoodToDeath;

    // Constructor
    public Animal(int turn) : base(turn)
    {
        turnsWithoutFood = 0;
        turnsWithoutFoodToDeath = 3;
    }

    // Getters and Setters
    public int GetTurnsWithoutFood() { return turnsWithoutFood; }
    public void SetTurnsWithoutFood(int value) { turnsWithoutFood = value; }

    public int GetTurnsWithoutFoodToDeath() { return turnsWithoutFoodToDeath; }
    public void SetTurnsWithoutFoodToDeath(int value) { turnsWithoutFoodToDeath = value; }

    // ToString
    public override string ToString()
    {
        return $"Animal [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionTurns}, " +
               $"TurnsWithoutFood: {turnsWithoutFood}, TurnsWithoutFoodToDeath: {turnsWithoutFoodToDeath}]";
    }
}