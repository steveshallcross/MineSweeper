namespace MineSweeper_Console_Library
{
    public class Player
    {
        public int id { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int MaxX { get; }
        public int MaxY { get; }
        public int MovesCount { get; private set; }
        public int Lives { get; set; }
        public bool Won { get; private set; } = false;
        //public bool IsAlive => Lives > 0 = true;
        public string CurrentLivesString { get { return $"{Lives} {(Lives == 1 ? "life" : "lives")} remaining"; } }
        public string CurrentMovesString { get { return $"used {MovesCount} {(MovesCount == 1 ? "move" : "moves")}"; } }

        public Player(int id, int maxX, int maxY)
        {
            this.id = id;
            X = 0;
            Y = 0;
            MaxX = maxX -1; // sub 1 to account for 0 based index
            MaxY = maxY -1; // sub 1 to account for 0 based index
            MovesCount = 0;
            Lives = 3;
        }

        public string PlayerStatus()
        {
            var xPosition = GetXAxisPositionTerminology(X);
            return $"Player {id} is at position {xPosition}{Y}, " + CurrentMovesString + ", and has " + CurrentLivesString + ".";
        }

        // X Axis position terminology uses letters instead of numbers
        private string GetXAxisPositionTerminology(int x)
        {
            int asciicode = 65 + x;
            return ((char) asciicode).ToString();
        }

        private void Move(int x, int y)
        {
            X += x;
            Y += y;
            MovesCount++;

            //Check for invalid moves, generously credit the move back to the player if so.
            if (X < 0)
            {
                X = 0;
                MovesCount--;
            }
            if (X >= MaxX)
                Won = true;
            if (Y < 0)
            {
                Y = 0;
                MovesCount--;
            }
            if (Y > MaxY)
            {
                Y = MaxY;
                MovesCount--;
            }
        }
        public void Move(string reference)
        {
            switch (reference)
            {
                case "up":
                    Move(0, -1);
                    break;
                case "down":
                    Move(0, 1);
                    break;
                case "left":
                    Move(-1, 0);
                    break;
                case "right":
                    Move(1, 0);
                    break;
            }
        }
    }
}
