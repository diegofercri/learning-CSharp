namespace SafariApp.model
{
    internal class Safari
    {
        // Variables
        private int turn;
        private Being[,] beings;

        // Constructor
        public Safari(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentException("Rows and columns must be positive integers.");
            }
            turn = 0;
            beings = new Being[rows, cols];
        }

        // Getters and Setters
        public int GetTurn() { return turn; }
        public void SetTurn(int value) { turn = value; }

        public Being[,] GetBeings() { return beings; }
        public void SetBeings(Being[,] value) { beings = value; }

        // ToString
        public override string ToString()
        {
            return $"Safari [Turn: {turn}, Area: {beings.GetLength(0)}x{beings.GetLength(1)}]";
        }

        // Methods
        public void Play() { /* TODO */ }
        public void Pause() { /* TODO */ }
        public void Reset() { /* TODO */ }
        public void AutoPlay() { /* TODO */ }
        public void End() { /* TODO */ }
    }
}
