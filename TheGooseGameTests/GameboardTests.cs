using NUnit.Framework;
using System.Collections.Generic;
using TheGooseGame;
using TheGooseGame.Intefaces;

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
            var newPosition = 9;

            //Act

            gameboard.MovePlayer(player,diceAmount);

            var result = player.Position;

            //Assert
            Assert.AreEqual(result, newPosition);
        }

        [Test]
        public void MovePlayer_WhenInMaze_PlayerPositionGoesToValue39()
        {
            int expected = 39;
            gameboard.MovePlayer(player, 42);
           
            var result = player.Position;

            Assert.AreEqual(expected, result);
        }
    }
}
