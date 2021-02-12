using NUnit.Framework;
using TheGooseGame;

namespace TheGooseGameTests
{
    public class GameboardTests
    {
        private Gameboard gameboard;
        private Player player;

        [SetUp]
        public void Setup()
        {
            gameboard = new Gameboard();
            player = new Player();
        }

        [Test]
        public void MovePlayer_WhenCalled_MovesTheDiceAmount()
        {
            int diceAmount = 9;

            //Act

            gameboard.MovePlayer(player, diceAmount);

            var result = player.Position;

            //Assert
            Assert.AreEqual(result, 63);
        }

        [Test]
        public void MovePlayer__IsPlayerInMaze_GoToCorrectSquare()
        {
            player.Position = 40;
            int diceAmount = 2;
            int expectedResult = 39;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MovePlayer_IsOver63_GoBackwords()
        {
            player.Position = 60;
            int diceAmount = 4;
            int expectedResult = 62;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;
            Assert.AreEqual(expectedResult, actualResult);

        }

        [Test]

        public void MovePlayer_WhenInReverseAndHitsAGoose_KeepsGoingBackwards()
        {
            player.IsOnGoose = true;
            player.IsInReverse = true;
            player.Position = 59;
            int diceAmount = 5;
            int expectedResult = 54;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;


            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}