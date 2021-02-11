using NUnit.Framework;
using System.Collections.Generic;
using TheGooseGame;

namespace TheGooseGameTests
{
    public class Tests
    {
        private Dice dice;

        [SetUp]
        public void Setup()
        {
            dice = new Dice();
        }

        [Test]
        public void Throws_WhenReturn_GivesAListOfTwoInt()
        {
            //Arrange
            List<int> list = new List<int> { 1, 2 };


            //Act
            List<int> result = dice.Throw();

            //Assert
            Assert.AreEqual(list.Count, result.Count);
        }

        [Test]
        public void Throws_WhenReturn_GivesAListOfTwoIntWithSumBetween2And12()
        {
            bool result = false;
            var tempList = dice.Throw();
            int tempResult = tempList[0] + tempList[1];
            if (tempResult>1 && tempResult<13)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }
    }
}