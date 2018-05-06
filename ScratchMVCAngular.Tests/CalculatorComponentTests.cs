using System;
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

        [TestMethod]
        public void VerifyMedian()
        {
            var calc = new Operations();
            int[] inputInts = new int[] { 1, 4, 3, 5, 6 };
            var expectedMedian = calc.CalculateMedian(inputInts);

            double testMedian = 4;
            Assert.AreEqual(expectedMedian, testMedian);

            if (expectedMedian == testMedian)
            {
                Console.WriteLine("The VerifyMedian test has passed!");
            }
        }

        [TestMethod]
        public void VerifyMultiMode()
        {
            var calc = new Operations();
            int[] inputInts = new int[] { 1, 2, 1, 3, 4, 2, 8, 6 };

            int[] expected = new int[] { 1, 2 }; 
            int[] actual = calc.CalculateMultiMode(inputInts);

            for (int i = 0; i < actual.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
                Console.WriteLine("Mode: {0}, ExpectedMode: {1}, Result: {2}", actual[i], expected[i], "YES");
            }

            Console.WriteLine("The VerifyMultiMode test passed");
        }
    }
}