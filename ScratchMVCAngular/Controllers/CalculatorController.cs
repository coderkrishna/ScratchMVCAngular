using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ScratchMVCAngular.Models;
using System;
using System.Linq;

namespace ScratchMVCAngular.Controllers
{
    [Produces("application/json")]
    [Route("api/Calculator")]
    public class CalculatorController : Controller
    {
        // GET: api/Calculator
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("[action]/{id}")]
        public Statistics Calculate(string id)
        {
            string[] inputs = id.Split(',');
            var stats = new Statistics();

            try
            {
                int[] inputInts = Array.ConvertAll(inputs, int.Parse);

                var dblAvg = CalculateAverage(inputInts);
                var dblMed = CalculateMedian(inputInts);
                int[] mode = CalculateMultiMode(inputInts);

                stats.Mean = dblAvg;
                stats.Median = dblMed;
                stats.Mode = mode;
                stats.Status = "200";
                stats.StatusDesc = "OK";
            }
            catch (Exception ex)
            {
                stats.Mean = 0;
                stats.Median = 0;
                stats.Mode = new int[] { 0 };
                stats.Status = "404";
                stats.StatusDesc = "Cannot proceed with calculations: " + ex.Message;
            }

            return stats;
        }

        /// <summary>
        /// The method that will calculate the average of a list of integers
        /// which are contained in the integer array
        /// </summary>
        /// <param name="inputInts">The array of integers</param>
        /// <returns>The mean, or the average of the numbers</returns>
        public double CalculateAverage(int[] inputInts)
        {
            int sum = 0;
            int size = inputInts.Length;

            foreach (int item in inputInts)
            {
                sum += item; 
            }

            return Convert.ToDouble(sum) / size;
        }

        /// <summary>
        /// Method that calculates the median of the list of numbers. 
        /// The median is the middle which is the middle integer in a list
        /// containing an odd number of elements. If the list contains
        /// an even number of elements, the median is the average of the middle
        /// two numbers
        /// </summary>
        /// <param name="inputInts">An integer array that is being analyzed</param>
        /// <returns>The median of the list</returns>
        public double CalculateMedian(int[] inputInts)
        {
            double median;
            int size = inputInts.Length;
            int[] copy = inputInts;

            // With having the median, it is usually recommended
            // that the numbers be sorted in either ascending or
            // descending order
            Array.Sort(copy);

            // Calculating the median as the mean of the two middle numbers.
            // Otherwise, the median will be the middle number in an array that
            // has an odd number of integers.
            if (size % 2 == 0)
            {
                median = Convert.ToDouble((copy[size / 2 - 1] + copy[size / 2])) / 2;
            }
            else
            {
                median = Convert.ToDouble(copy[(size - 1) / 2]);
            }

            return median;
        }

        /// <summary>
        /// The method that calculates either no mode that is denoted by 0, 
        /// returns a single integer for the mode, or would return more than
        /// one value for the mode in case the list contains a few integers that
        /// occur more than once in the list. Mathematically speaking, mode means
        /// most occurring
        /// </summary>
        /// <param name="inputInts">The list of integers</param>
        /// <returns>Either no mode, one mode, or more than 2 modes</returns>
        public int[] CalculateMultiMode(int[] inputInts)
        {
            // myList is the original list of numbers
            List<int> myList = new List<int>(inputInts);
            List<int> modes = new List<int>();

            // This creates the query
            // and the list of numbers that are grouped by the number of times
            // each number appears!
            var query = from numbers in myList // select the numbers
                        group numbers by numbers // group the numbers so that we get the count
                            into groupedNumbers
                        select new { Number = groupedNumbers.Key, Count = groupedNumbers.Count() };

            int max = query.Max(g => g.Count);

            if (max == 1)
            {
                int mode = 0;
                modes.Add(mode);
            }
            else
            {
                modes = query.Where(x => x.Count == max).Select(x => x.Number).ToList();
            }

            return modes.ToArray();
        }
    }
}