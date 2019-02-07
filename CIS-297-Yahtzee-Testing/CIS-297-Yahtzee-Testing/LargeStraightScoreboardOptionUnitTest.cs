using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class LargeStraightScoreboardOptionUnitTest
    {
        [TestMethod]
        public void LargeStraightTestMethod1()
        {

            //Arrange
            int expectedResult = 40;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            LargeStraightScorecardOption largeStraightScorecardOption = new LargeStraightScorecardOption();


            //Act
            result = largeStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LargeStraightTestMethod2()
        {

            //Arrange
            int expectedResult = 40;
            int result;

            int[] diceValues = new int[5] { 2, 3, 4, 5, 6 };
            LargeStraightScorecardOption largeStraightScorecardOption = new LargeStraightScorecardOption();


            //Act
            result = largeStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LargeStraightTestMethod3()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 1, 2, 1, 1, 1 };
            LargeStraightScorecardOption largeStraightScorecardOption = new LargeStraightScorecardOption();


            //Act
            result = largeStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void LargeStraightTestMethod4()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 6, 6, 5, 5, 4 };
            LargeStraightScorecardOption largeStraightScorecardOption = new LargeStraightScorecardOption();


            //Act
            result = largeStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
