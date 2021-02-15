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
            player = new Player(1);
        }

        [Test]
        public void MovePlayer_WhenCalled_MovesTheDiceAmount()
        {
            player.Position = 0;
            int diceAmount = 8;

            //Act

            gameboard.MovePlayer(player, diceAmount);

            var result = player.Position;

            //Assert
            Assert.AreEqual(result, 9);
        }


        [Test]

        public void MovePlayer_WhenOnGoose_MovesAgainTheDiceamount()
        {
            player.Position = 0;
            int diceAmount = 5;

            //Act

            gameboard.MovePlayer(player, diceAmount);

            var result = player.Position;

            //Assert
            Assert.AreEqual(result, 10);
        }

        [Test]
        public void MovePlayer_IsOver63_GoesBack()
        {
            player.Position = 60;
            int diceAmount = 4;
            int expectedResult = 62;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;
            Assert.AreEqual(expectedResult, actualResult);

        }
        [Test]
        public void MovePlayer_IsInReverseAndStepsOnGoose_GoesBack()
        {
            player.Position = 61;
            int diceAmount = 6;
            int expectedResult = 53;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void MovePlayer_IsInReverseAndStepsOnGoose_GoesBackTwoTimes()
        {
            player.Position = 62;
            int diceAmount = 5;
            int expectedResult = 49;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]

        public void MovePlayer_WhenOnBridge_MoveTo12()
        {
            player.Position = 3;

            int diceAmount = 3;
            int expectedResult = 12;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;

            Assert.AreEqual(expectedResult, actualResult);
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

        public void MovePlayer_WhenInDeath_MoveToZero()
        {
            player.Position = 54;

            int diceAmount = 4;
            int expectedResult = 0;

            gameboard.MovePlayer(player, diceAmount);

            int actualResult = player.Position;

            Assert.AreEqual(expectedResult, actualResult);
        }


        [Test]
        public void GameLoop_WhenFirstTurn_CanWork()
        {
            
            var expectedResult = 26;


            gameboard.GameLoop();

            var actualResult = 7;

            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}