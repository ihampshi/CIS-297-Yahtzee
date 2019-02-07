using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class ChanceScoreboardOptionUnitTest
    {
        [TestMethod]
        public void ChanceTestMethod1()
        {

            //Arrange
            int expectedResult = 15;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            ChanceScorecardOption chanceScorecardOption = new ChanceScorecardOption();


            //Act
            result = chanceScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ChanceTestMethod2()
        {

            //Arrange
            int expectedResult = 16;
            int result;

            int[] diceValues = new int[5] { 3, 3, 6, 2, 2 };
            ChanceScorecardOption chanceScorecardOption = new ChanceScorecardOption();


            //Act
            result = chanceScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ChanceTestMethod3()
        {

            //Arrange
            int expectedResult = 9;
            int result;

            int[] diceValues = new int[5] { 4, 2, 1, 1, 1 };
            ChanceScorecardOption chanceScorecardOption = new ChanceScorecardOption();


            //Act
            result = chanceScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ChanceTestMethod4()
        {

            //Arrange
            int expectedResult = 12;
            int result;

            int[] diceValues = new int[5] { 3, 2, 4, 1, 2 };
            ChanceScorecardOption chanceScorecardOption = new ChanceScorecardOption();


            //Act
            result = chanceScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
