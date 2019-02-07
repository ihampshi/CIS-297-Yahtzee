using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class YahtzeeScoreboardOptionUnitTest
    {
        [TestMethod]
        public void YahtzeeTestMethod1()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            YahtzeeScorecardOption yahtzeeScorecardOption = new YahtzeeScorecardOption();

            //Act
            result = yahtzeeScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void YahtzeeTestMethod2()
        {

            //Arrange
            int expectedResult = 50;
            int result;

            int[] diceValues = new int[5] { 2, 2, 2, 2, 2 };
            YahtzeeScorecardOption yahtzeeScorecardOption = new YahtzeeScorecardOption();

            //Act
            result = yahtzeeScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void YahtzeeTestMethod3()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 6, 2, 1, 3, 5 };
            YahtzeeScorecardOption yahtzeeScorecardOption = new YahtzeeScorecardOption();

            //Act
            result = yahtzeeScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void YahtzeeTestMethod4()
        {

            //Arrange
            int expectedResult = 50;
            int result;

            int[] diceValues = new int[5] { 3, 3, 3, 3, 3 };
            YahtzeeScorecardOption yahtzeeScorecardOption = new YahtzeeScorecardOption();


            //Act
            result = yahtzeeScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
