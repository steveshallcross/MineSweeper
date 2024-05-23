using MineSweeper_Console_Library;

namespace MineSweeper_Console_Test
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void TestBoardInitialization()
        {
            var board = new Board(10, 10, 10);
            Assert.AreEqual(10, board.Width);
            Assert.AreEqual(10, board.Height);
            Assert.AreEqual(10, board.MineCount);
            Assert.IsNotNull(board.MinePositions);
        }

        [TestMethod]
        public void TestMineHit()
        {
            var board = new Board(10, 10, 10);
            bool hit = false;
            for (int i = 0; i < board.Width; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    if (board.MineHit(i, j))
                    {
                        hit = true;
                        break;
                    }
                }
                if (hit) break;
            }
            Assert.IsTrue(hit);
        }

        [TestMethod]
        public void TestGenerateBoard()
        {
            var board = new Board(10, 10, 10);
            int mineCount = 0;
            for (int i = 0; i < board.Width; i++)
            {
                for (int j = 0; j < board.Height; j++)
                {
                    if (board.MineHit(i, j))
                    {
                        mineCount++;
                    }
                }
            }
            Assert.AreEqual(board.MineCount, mineCount);
        }
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
