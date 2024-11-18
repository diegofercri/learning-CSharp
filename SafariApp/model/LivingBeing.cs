namespace SafariApp.model
{
    internal class LivingBeing
    {
        // Variables
        public int spawnTurn { get; }
        public int turnsAlive { get; set; }

        // Constructor
        public LivingBeing(Safari safari)
        {
            spawnTurn = safari.getTurn();
            turnsAlive = 0;
        }

        // Getters and Setters
        public int getSpawnTurn() { 
            return spawnTurn;
        }
        public int getTurnsAlive() {
            return turnsAlive;
        }
        public void setTurnsAlive(Safari safari)
        {
            turnsAlive = spawnTurn - safari.getTurn();
        }

        // Methods
        public void reproduction()
        {
            //TODO
        }
        public void death()
        {
            //TODO
        }
    }
}