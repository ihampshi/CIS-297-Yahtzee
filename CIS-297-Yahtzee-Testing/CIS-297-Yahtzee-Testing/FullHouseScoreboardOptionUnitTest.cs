using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class FullHouseScoreboardOptionUnitTest
    {
        [TestMethod]
        public void FullHouseTestMethod1()
        {

            //Arrange
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            FullHouseScorecardOption fullHouseScorecardOption = new FullHouseScorecardOption();


            //Act
            result = fullHouseScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FullHouseTestMethod2()
        {

            //Arrange
            int expectedResult = 3;
            int result;

            int[] diceValues = new int[5] { 1, 1, 1, 4, 3 };
            FullHouseScorecardOption fullHouseScorecardOption = new FullHouseScorecardOption();


            //Act
            result = fullHouseScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FullHouseTestMethod3()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 4, 5, 3 };
            FullHouseScorecardOption fullHouseScorecardOption = new FullHouseScorecardOption();


            //Act
            result = fullHouseScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void FullHouseTestMethod4()
        {

            //Arrange
            int expectedResult = 1;
            int result;

            int[] diceValues = new int[5] { 2, 3, 5, 2, 1 };
            FullHouseScorecardOption fullHouseScorecardOption = new FullHouseScorecardOption();


            //Act
            result = fullHouseScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
