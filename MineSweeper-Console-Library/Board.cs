using System.ComponentModel.DataAnnotations;

namespace MineSweeper_Console_Library
{
    // TODO: Add validation to ensure that the number of mines is less than the total number of cells on the board
    public class Board
    {
        //[Range(2,26, ErrorMessage = "Width must be between 2 and 26")]
        public int Width { get; private set; }

        //[Range(2, 26, ErrorMessage = "Height must be between 2 and 26")]
        public int Height { get; private set; }

        //[Range(1, 10, ErrorMessage = "Width must be between 1 and 10")]
        public int MineCount { get; private set; }
        //public int[,] BoardArray { get; private set; }
        public bool[,] MinePositions { get; set; }

        public Board(int width = 8, int height = 8, int mines = 8)
        {
            if (width < 2 || width > 26 )
            {
                throw new System.ArgumentOutOfRangeException("Width must be between 2 and 26");
            }
            if (height < 2 || height > 26)
            {
                throw new System.ArgumentOutOfRangeException("Height must be between 2 and 26");
            }
            if (mines < 1 || mines > 10)
            {
                throw new System.ArgumentOutOfRangeException("Mines must be between 1 and 10");
            }

            Width = width;
            Height = height;
            MineCount = mines;
            //BoardArray = new int[width, height];
            MinePositions = new bool[width, height];
            GenerateBoard();
        }

        public void GenerateBoard()
        {
            // Generate mines
            for (int i = 0; i < MineCount; i++)
            {
                int x = new Random().Next(Width);
                int y = new Random().Next(Height);

                //Ensure we always have the correct number of mines
                //Check if mine already exists at this position
                if (MinePositions[x, y] == false)
                    MinePositions[x, y] = true;
                else
                    i--;
            }
        }
        public bool MineHit(int x, int y)
        {
            return MinePositions[x, y];
        }

        //Included for testing purposes
        public void PrintBoard()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (MinePositions[x, y])
                    {
                        Console.Write("M");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
