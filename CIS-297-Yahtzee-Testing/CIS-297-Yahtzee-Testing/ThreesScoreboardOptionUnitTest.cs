using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class ThreesScoreboardOptionUnitTest
    {
        [TestMethod]
        public void ThreesTestMethod1()
        {

            //Arrange
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            ThreesScorecardOption threesScorecardOption = new ThreesScorecardOption();


            //Act
            result = threesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThreesTestMethod2()
        {

            //Arrange
            int expectedResult = 3;
            int result;

            int[] diceValues = new int[5] { 1, 1, 1, 4, 3 };
            ThreesScorecardOption threesScorecardOption = new ThreesScorecardOption();


            //Act
            result = threesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThreesTestMethod3()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 4, 5, 3 };
            ThreesScorecardOption threesScorecardOption = new ThreesScorecardOption();


            //Act
            result = threesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThreesTestMethod4()
        {

            //Arrange
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 2, 3, 5, 2, 1 };
            ThreesScorecardOption threesScorecardOption = new ThreesScorecardOption();


            //Act
            result = threesScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
