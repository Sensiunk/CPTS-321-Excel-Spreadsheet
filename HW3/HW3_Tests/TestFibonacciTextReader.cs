// <copyright file="TestFibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3_Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Implementation of Test Cases to check for the validity of methods.
    /// </summary>
    public class TestFibonacciTextReader
    {
        /// <summary>
        /// Initialize Setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        /// <param name="testFibNumber"> Takes in the number of testFibNumber. </param>
        /// <returns> We should return the value of the nth Fibonacci number. </returns>
        [TestCase(3, ExpectedResult = 2)]
        public int TestNormalCase(int testFibNumber)
        {
            return 0;
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        /// <param name="testFibNumber"> Takes in the number of testFibNumber. </param>
        /// <returns> We should return the value of the nth Fibonacci number. </returns>
        [TestCase(0, ExpectedResult = 0)]
        public int TestNormalCaseForZero(int testFibNumber)
        {
            return 0;
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        /// <param name="testFibNumber"> Takes in the number of testFibNumber. </param>
        /// <returns> We should return the value of the nth Fibonacci number. </returns>
        [TestCase(1, ExpectedResult = 1)]
        public int TestNormalCaseForOne(int testFibNumber)
        {
            return 0;
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        [Test]
        public void TestExceptionCase()
        {
            int testFibNumber = -1;
            return;
        }
    }
}