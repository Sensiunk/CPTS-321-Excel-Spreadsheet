// <copyright file="TestDistinctIntegersCalculator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW2.DistinctIntegersCalculator.Tests
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    /// <summary>
    /// Implementation of Test Cases to check for the validity of methods.
    /// </summary>
    public class TestDistinctIntegersCalculator
    {
        /// <summary>
        /// Initialize Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        // TEST CASES FOR THE HASH SET

        /// <summary>
        /// Test case to test if the normal case is working for the hash set implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// The value should return the number of distinct numbers using a hash set.
        /// </returns>
        [TestCase(new[] { 5, 3, 1, 2, 4 }, ExpectedResult = 5)]
        public int TestNormalCaseHashSet(int[] inputHashNums)
        {
            List<int> testList = new List<int>(5); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingHashSet(testList); // Return the value that was generated using the UniqueNumbersUsingHashSet
        }

        /// <summary>
        /// Test case to test if the edge case max value is working for the hash set implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// This value should return the number of distinct numbers using a hash set.
        /// </returns>
        [TestCase(new[] { 20000, 20000, 20000 }, ExpectedResult = 1)]
        public int TestEdgeCaseHashSetMax(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingHashSet(testList); // Return the value that was generated using the UniqueNumbersUsingHashSet
        }

        /// <summary>
        /// Test case to test if the edge case min value is working for the hash set implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// This value should return the number of distinct numbers using a hash set.
        /// </returns>
        [TestCase(new[] { 0, 0, 0 }, ExpectedResult = 1)]
        public int TestEdgeCaseHashSetMin(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingHashSet(testList); // Return the value that was generated using the UniqueNumbersUsingHashSet
        }

        /// <summary>
        /// Test case to test if the exception case max values is working for the hash set implementation.
        /// </summary>
        [Test]
        public void TestExceptionCaseHashSetMax()
        {
            int[] inputHashNums = new[] { 0, 1, 20001 }; // Values to test with number out of bounds

            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => DistinctIntegersCalculator.UniqueNumbersUsingHashSet(testList)); // Exception case to test if the numbers being passed does not conform to the criteia
        }

        /// <summary>
        /// Test case to test if the exception case min values is working for the hash set implementation.
        /// </summary>
        [Test]
        public void TestExceptionCaseHashSetMin()
        {
            int[] inputHashNums = new[] { -1, 0, 1 }; // Values to test with number out of bounds

            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => DistinctIntegersCalculator.UniqueNumbersUsingHashSet(testList)); // Exception case to test if the numbers being passed does not conform to the criteia
        }

        // TEST CASES FOR LAST INDEX

        /// <summary>
        /// Test case to test if the normal case is working for the LastIndex implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// The value should return the number of distinct numbers using a LastIndex.
        /// </returns>
        [TestCase(new[] { 5, 3, 1, 2, 4 }, ExpectedResult = 5)]
        public int TestNormalCaseLastIndex(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(testList); // Return the value that was generated using the UniqueNumbersUsingLastIndex
        }

        /// <summary>
        /// Test case to test if the edge case max value is working for the LastIndex implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// This value should return the number of distinct numbers using a LastIndex.
        /// </returns>
        [TestCase(new[] { 20000, 20000, 20000 }, ExpectedResult = 1)]
        public int TestEdgeCaseLastIndexMax(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(testList); // Return the value that was generated using the UniqueNumbersUsingLastIndex
        }

        /// <summary>
        /// Test case to test if the edge case min value is working for the LastIndex implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// This value should return the number of distinct numbers using a LastIndex.
        /// </returns>
        [TestCase(new[] { 0, 0, 0 }, ExpectedResult = 1)]
        public int TestEdgeCaseLastIndexpMin(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(testList); // Return the value that was generated using the UniqueNumbersUsingLastIndex
        }

        /// <summary>
        /// Test case to test if the exception case max values is working for the LastIndex implementation.
        /// </summary>
        [Test]
        public void TestExceptionCaseLastIndexMax()
        {
            int[] inputHashNums = new[] { 0, 1, 20001 }; // Values to test with number out of bounds

            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(testList)); // Exception case to test if the numbers being passed does not conform to the criteia
        }

        /// <summary>
        /// Test case to test if the exception case min values is working for the LastIndex implementation.
        /// </summary>
        [Test]
        public void TestExceptionCaseLastIndexMin()
        {
            int[] inputHashNums = new[] { -1, 0, 1 }; // Values to test with number out of bounds

            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(testList)); // Exception case to test if the numbers being passed does not conform to the criteia
        }

        // TEST CASES FOR THE SORTED FOR LOOP

        /// <summary>
        /// Test case to test if the normal case is working for the SortedForLoop implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// The value should return the number of distinct numbers using a SortedForLoop.
        /// </returns>
        [TestCase(new[] { 0, 1, 2, 3, 4 }, ExpectedResult = 5)]
        public int TestNormalCaseSortedForLoop(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(testList); // Return the value that was generated using the UniqueNumbersUsingSortedForLoops
        }

        /// <summary>
        /// Test case to test if the edge case max values is working for the SortedForLoop implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// This value should return the number of distinct numbers using a SortedForLoop.
        /// </returns>
        [TestCase(new[] { 20000, 20000, 20000 }, ExpectedResult = 1)]
        public int TestEdgeCaseSortedForLoopMax(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(testList); // Return the value that was generated using the UniqueNumbersUsingSortedForLoops
        }

        /// <summary>
        /// Test case to test if the edge case min values is working for the SortedForLoop implementation.
        /// </summary>
        /// <param name="inputHashNums"> Takes input of a array with user generated numbers. </param>
        /// <returns>
        /// This value should return the number of distinct numbers using a SortedForLoop.
        /// </returns>
        [TestCase(new[] { 0, 0, 0 }, ExpectedResult = 1)]
        public int TestEdgeCaseSortedForLoopMin(int[] inputHashNums)
        {
            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            return DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(testList); // Return the value that was generated using the UniqueNumbersUsingSortedForLoops
        }

        /// <summary>
        /// Test case to test if the exception case max values is working for the SortedForLoop implementation.
        /// </summary>
        [Test]
        public void TestExceptionCaseSortedForLoopMax()
        {
            int[] inputHashNums = new[] { 0, 1, 20001 }; // Values to test with number out of bounds

            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(testList)); // Exception case to test if the numbers being passed does not conform to the criteia
        }

        /// <summary>
        /// Test case to test if the exception case min values is working for the SortedForLoop implementation.
        /// </summary>
        [Test]
        public void TestExceptionCaseSortedForLoopMin()
        {
            int[] inputHashNums = new[] { -1, 0, 1 }; // Values to test with number out of bounds

            List<int> testList = new List<int>(); // Create new list for testing purposes

            // Iterate through the array and set the inputForListNumbers to each value in order
            foreach (var inputForListNumbers in inputHashNums)
            {
                testList.Add(inputForListNumbers); // Adds each number in the array passed in and adds it to the list
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(testList)); // Exception case to test if the numbers being passed does not conform to the criteia
        }
    }
}