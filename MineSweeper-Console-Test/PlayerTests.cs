using MineSweeper_Console_Library;

namespace MineSweeper_Console_Test
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void TestPlayerInitialization()
        {
            var player = new Player(1, 10, 10);
            Assert.AreEqual(1, player.id);
            Assert.AreEqual(0, player.X);
            Assert.AreEqual(0, player.Y);
            Assert.AreEqual(9, player.MaxX);
            Assert.AreEqual(9, player.MaxY);
            Assert.AreEqual(0, player.MovesCount);
            Assert.AreEqual(3, player.Lives);
            Assert.IsFalse(player.Won);
        }

        [TestMethod]
        public void TestPlayerMove()
        {
            var player = new Player(1, 10, 10);
            player.Move("right");
            Assert.AreEqual(1, player.X);
            Assert.AreEqual(0, player.Y);
            Assert.AreEqual(1, player.MovesCount);
        }

        [TestMethod]
        public void TestPlayerWin()
        {
            var player = new Player(1, 3, 2);
            player.Move("right");
            player.Move("right");
            Assert.IsTrue(player.Won);
        }

        [TestMethod]
        public void TestPlayerCurrentPosition()
        {
            var player = new Player(1, 10, 10);
            Assert.AreEqual(0, player.X);
            Assert.AreEqual(0, player.Y);
            player.Move("right");
            player.Move("down");
            Assert.AreEqual(1, player.X);
            Assert.AreEqual(1, player.Y);
        }
        [TestMethod]
        public void TestPlayerStatusMsg()
        {
            var player = new Player(1, 10, 10);
            player.Move("right");
            var expectedMessage = "Player 1 is at position B0, used 1 move, and has 3 lives remaining.";
            Assert.AreEqual(expectedMessage, player.PlayerStatus());
        }
    }
}