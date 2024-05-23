using MineSweeper_Console_Library;

namespace MineSweeper_Console_Test
{
    [TestClass]
    public class SetupTest
    {
        [TestMethod]
        public void NumberOfMines()
        {
            var board = new Board(8, 8, 8);
            int mineCount = 0;
            for (int x = 0; x < board.Width; x++)
            {
                for (int y = 0; y < board.Height; y++)
                {
                    if (board.MinePositions[x, y])
                    {
                        mineCount++;
                    }
                }
            }
            Assert.AreEqual(board.MineCount, mineCount);
        }
    }
}