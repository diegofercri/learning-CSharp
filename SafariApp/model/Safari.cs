namespace SafariApp.model
{

    internal class Safari
    {
        // Variables
        public int Turn = 0;
        public int Rows;
        public int Cols;
        internal List<LivingBeing> Beings;


        // Constructor
        public Safari(int rows, int cols)
        {
            if (x <= 0 || y <= 0)
            // Detects negative inputs
            {
                throw new ArgumentException("Rows and columns must be positive integers.");
            }

            Turn = 0;
            Rows = rows;
            Cols = cols;
            Beings = new List<LivingBeing>();
        }

        // Getters and Setters
        public int getTurn()
        {
            return Turn;
        }


        // Methods
        public void Play() {
            //TODO
        }

        public void Pause() {
            //TODO
        }

        public void Reset() {
            //TODO
        }

        public void AutoPlay() {
            //TODO
        }

        public void End() {
            //TODO
        }
    }
}