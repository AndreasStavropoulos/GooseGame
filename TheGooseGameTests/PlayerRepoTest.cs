using NUnit.Framework;
using System.Collections.Generic;
using TheGooseGame;
using TheGooseGame.Interfaces;

namespace TheGooseGameTests
{
    public class PlayerRepoTest
    {
        private PlayerRepo playerListFactory;

        [SetUp]
        public void Setup()
        {
            playerListFactory = new PlayerRepo();
        }

        [Test]
        public void ListOfPlayers_WhenReturn_GivesAListOfCorrectNumberOfPlayers()
        {
            //Arrange
            IList<IPlayer> players = new List<IPlayer> { new Player(1), new Player(2) };
            var expected = players;
            
            //Act

            var result = playerListFactory.ListOfPlayers(2);

            //Assert
            Assert.AreEqual(expected.Count, result.Count);
        }
    }
}