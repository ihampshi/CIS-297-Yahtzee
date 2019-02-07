using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class FourOfAKindScoreboardOptionUnitTest
    {
        [TestMethod]
        public void FourOfAKindTestMethod1()
        {

            //Arrange
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            FourOfAKindScorecardOption fourOfAKindScorecardOption = new FourOfAKindScorecardOption();


            //Act
            result = fourOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FourOfAKindTestMethod2()
        {

            //Arrange
            int expectedResult = 3;
            int result;

            int[] diceValues = new int[5] { 1, 1, 1, 4, 3 };
            FourOfAKindScorecardOption fourOfAKindScorecardOption = new FourOfAKindScorecardOption();


            //Act
            result = fourOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FourOfAKindTestMethod3()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 4, 5, 3 };
            FourOfAKindScorecardOption fourOfAKindScorecardOption = new FourOfAKindScorecardOption();


            //Act
            result = fourOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FourOfAKindTestMethod4()
        {

            //Arrange
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 2, 3, 5, 2, 1 };
            FourOfAKindScorecardOption fourOfAKindScorecardOption = new FourOfAKindScorecardOption();


            //Act
            result = fourOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
