using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class TwosScoreboardOptionUnitTest
    {
        [TestMethod]
        public void TwosTestMethod1()
        {

            //Arrange
            int expectedResult = 2;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            TwosScorecardOption twosScorecardOption = new TwosScorecardOption();

            //Act
            result = twosScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TwosTestMethod2()
        {

            //Arrange
            int expectedResult = 4;
            int result;

            int[] diceValues = new int[5] { 3, 2, 1, 5, 2 };
            TwosScorecardOption twosScorecardOption = new TwosScorecardOption();

            //Act
            result = twosScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TwosTestMethod3()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 6, 5, 6, 3, 3 };
            TwosScorecardOption twosScorecardOption = new TwosScorecardOption();

            //Act
            result = twosScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void TwosTestMethod4()
        {

            //Arrange
            int expectedResult = 8;
            int result;

            int[] diceValues = new int[5] { 2, 2, 2, 3, 2 };
            TwosScorecardOption twosScorecardOption = new TwosScorecardOption();


            //Act
            result = twosScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
