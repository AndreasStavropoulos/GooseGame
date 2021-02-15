using System.Collections.Generic;
using NUnit.Framework;
using TheGooseGame;
using TheGooseGame.Square;

namespace TheGooseGameTests
{
    public class GameboardTests
    {
        private Gameboard gameboard;
        private IList<IPlayer> players;
        private IPlayer player;

        [SetUp]
        public void Setup()
        {
            PlayerRepo _repo = new PlayerRepo();
            players = _repo.ListOfPlayers(1);
            var dice = new Dice();
            gameboard = new Gameboard(players, dice);
        }

        [Test]
        public void Moveplayer_WhenLandingOnSpecialSquare_PlayerIsMovedToCorrectPosition()
        {
            // Arrange
            ISquare square = new Bridge(-1);
            int diceAmount = -1;
            player = players[0];

            // Act
            gameboard.MovePlayer(player, diceAmount, square);

            // Assert
            Assert.AreEqual(12, player.Position);
        }
    }
}