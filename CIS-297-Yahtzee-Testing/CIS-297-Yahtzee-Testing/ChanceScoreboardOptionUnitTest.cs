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
            int expectedResult = 1;
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
            int expectedResult = 3;
            int result;

            int[] diceValues = new int[5] { 1, 1, 1, 4, 3 };
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
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 4, 5, 3 };
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
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 2, 3, 5, 2, 1 };
            ChanceScorecardOption chanceScorecardOption = new ChanceScorecardOption();


            //Act
            result = chanceScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
