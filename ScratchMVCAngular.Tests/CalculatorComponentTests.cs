﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScratchMVCAngular.Logic; 

namespace ScratchMVCAngular.Tests
{
    [TestClass]
    public class CalculatorComponentTests
    {
        [TestMethod]
        public void VerifyMean()
        {
            var calc = new Operations();
            int[] inputInts = new int[] { 1, 3, 4, 2 }; 
            var expectedMean = calc.CalculateAverage(inputInts);

            double testMean = 2.5;
            Assert.AreEqual(expectedMean, testMean);

            if (expectedMean == testMean)
            {
                Console.WriteLine("The VerifyMean test has passed!");
            }
        }
    }
}