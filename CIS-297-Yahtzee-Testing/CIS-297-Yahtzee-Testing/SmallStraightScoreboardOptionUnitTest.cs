using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class SmallStraightScoreboardOptionUnitTest
    {
        [TestMethod]
        public void SmallStraightTestMethod1()
        {

            //Arrange
            int expectedResult = 30;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            SmallStraightScorecardOption smallStraightScorecardOption = new SmallStraightScorecardOption();


            //Act
            result = smallStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SmallStraightTestMethod2()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 5, 5, 2, 1, 3 };
            SmallStraightScorecardOption smallStraightScorecardOption = new SmallStraightScorecardOption();


            //Act
            result = smallStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SmallStraightTestMethod3()
        {

            //Arrange
            int expectedResult = 30;
            int result;

            int[] diceValues = new int[5] { 3, 2, 4, 1, 6 };
            SmallStraightScorecardOption smallStraightScorecardOption = new SmallStraightScorecardOption();


            //Act
            result = smallStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void SmallStraightTestMethod4()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 2, 2, 3, 3, 3 };
            SmallStraightScorecardOption smallStraightScorecardOption = new SmallStraightScorecardOption();


            //Act
            result = smallStraightScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
