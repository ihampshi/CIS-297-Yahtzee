﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahtzee_Application;

namespace CIS_297_Yahtzee_Testing
{
    [TestClass]
    public class ThreeOfAKindScoreboardOptionUnitTest
    {
        [TestMethod]
        public void ThreeOfAKindTestMethod1()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 1, 2, 3, 4, 5 };
            ThreeOfAKindScorecardOption threeOfAKindScorecardOption = new ThreeOfAKindScorecardOption();


            //Act
            result = threeOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThreeOfAKindTestMethod2()
        {

            //Arrange
            int expectedResult = 10;
            int result;

            int[] diceValues = new int[5] { 1, 1, 1, 4, 3 };
            ThreeOfAKindScorecardOption threeOfAKindScorecardOption = new ThreeOfAKindScorecardOption();


            //Act
            result = threeOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThreeOfAKindTestMethod3()
        {

            //Arrange
            int expectedResult = 14;
            int result;

            int[] diceValues = new int[5] { 3, 2, 5, 2, 2 };
            ThreeOfAKindScorecardOption threeOfAKindScorecardOption = new ThreeOfAKindScorecardOption();


            //Act
            result = threeOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void ThreeOfAKindTestMethod4()
        {

            //Arrange
            int expectedResult = 0;
            int result;

            int[] diceValues = new int[5] { 4, 4, 3, 2, 3 };
            ThreeOfAKindScorecardOption threeOfAKindScorecardOption = new ThreeOfAKindScorecardOption();


            //Act
            result = threeOfAKindScorecardOption.getScore(diceValues);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}
