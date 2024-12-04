namespace SafariApp_v2.Model
{
    internal class Plant : Being
    {
        // Constructor
        public Plant(Safari safari) : base(safari)
        {
            reproductionModule = 2;  // The plant reproduces every 2 turns.
        }

        // ToString
        public override string ToString()
        {
            return $"Plant [SpawnTurn: {GetSpawnTurn()}, TurnsAlive: {GetTurnsAlive()}, ReproductionTurns: {reproductionModule}]";
        }

        // Methods
        /// <summary>
        /// Handles the plant's behavior during its turn.
        /// The current position coordinates are not relevant to the base method call.
        /// </summary>
        /// <param name="currentRow">Fixed value, not used in this context.</param>
        /// <param name="currentCol">Fixed value, not used in this context.</param>
        /// <param name="safari">The current instance of Safari.</param>
        public override void PlayTurn(int currentRow, int currentCol, Safari safari)
        {
            // If the plant needs to reproduce, try to reproduce.
            if (needsToReproduce)
            {
                Reproduction(currentRow, currentCol, safari);
            }

            // Call the base PlayTurn method, passing fixed values since position is not relevant.
            base.PlayTurn(0, 0, safari); // The position values are not used in the base method.
        }

        /// <summary>
        /// Creates a new instance of a plant.
        /// </summary>
        /// <param name="safari">The current instance of Safari.</param>
        /// <returns>A new Plant.</returns>
        protected override Being CreateNewBeing(Safari safari)
        {
            return new Plant(safari); // Create a new Plant.
        }
    }
}