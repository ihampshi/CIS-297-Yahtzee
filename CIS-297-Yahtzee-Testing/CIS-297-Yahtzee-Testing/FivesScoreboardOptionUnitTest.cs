using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class FivesScoreboardOptionUnitTest
    {
        [TestMethod]
        public void FivesTestMethod1()
        {

            //Arrange
            int expectedResult = 5;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            FivesScorecardOption fivesScorecardOption = new FivesScorecardOption();


            //Act
            result = fivesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FivesTestMethod2()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 4, 3, 1 };
            FivesScorecardOption fivesScorecardOption = new FivesScorecardOption();


            //Act
            result = fivesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FivesTestMethod3()
        {

            //Arrange
            int expectedResult = 5;
            int result;

            int[] diceValues = new int[5] {6, 6, 5, 4, 1 };
            FivesScorecardOption fivesScorecardOption = new FivesScorecardOption();


            //Act
            result = fivesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FivesTestMethod4()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 1, 4, 2 };
            FivesScorecardOption fivesScorecardOption = new FivesScorecardOption();


            //Act
            result = fivesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
