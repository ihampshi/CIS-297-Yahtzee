using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class FoursScoreboardOptionUnitTest
    {
        [TestMethod]
        public void FoursTestMethod1()
        {

            //Arrange
            int expectedResult = 4;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            FoursScorecardOption foursScorecardOption = new FoursScorecardOption();


            //Act
            result = foursScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FoursTestMethod2()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 1, 3, 1 };
            FoursScorecardOption foursScorecardOption = new FoursScorecardOption();


            //Act
            result = foursScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FoursTestMethod3()
        {

            //Arrange
            int expectedResult = 8;
            int result;

            int[] diceValues = new int[5] { 6, 4, 5, 4, 1 };
            FoursScorecardOption foursScorecardOption = new FoursScorecardOption();


            //Act
            result = foursScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FoursTestMethod4()
        {

            //Arrange
            int expectedResult = 4;
            int result;

            int[] diceValues = new int[5] { 2, 2, 1, 4, 2 };
            FoursScorecardOption foursScorecardOption = new FoursScorecardOption();


            //Act
            result = foursScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
