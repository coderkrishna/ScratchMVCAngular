using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScratchMVCAngular.Controllers; 

namespace ScratchMVCAngular.Tests
{
    [TestClass]
    public class CalculatorComponentTests
    {
        [TestMethod]
        public void VerifyMean()
        {
            var calc = new CalculatorController();
            int[] inputInts = new int[] { 1, 3, 4, 2 }; 
            var expectedMean = calc.CalculateAverage(inputInts); 
        }
    }
}