// <copyright file="Program.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace HW3_Tests
{
    using NUnit.Framework;

    /// <summary>
    /// Implementation of Test Cases to check for the validaty of methods.
    /// </summary>
    public class Tests
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
        /// <param name="testFibNum"> Takes in the number of testFibNum. </param>
        /// <returns> We should return the value of the nth Fibonacci number. </returns>
        [TestCase(3, ExpectedResult = 2)]
        public int TestNormalCase(int testFibNum)
        {
            return 0;
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        /// <param name="testFibNum"> Takes in the number of testFibNum. </param>
        /// <returns> We should return the value of the nth Fibonacci number. </returns>
        [TestCase(0, ExpectedResult = 0)]
        public int TestNormalCaseForZero(int testFibNum)
        {
            return 0;
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        /// <param name="testFibNum"> Takes in the number of testFibNum. </param>
        /// <returns> We should return the value of the nth Fibonacci number. </returns>
        [TestCase(1, ExpectedResult = 1)]
        public int TestNormalCaseForOne(int testFibNum)
        {
            return 0;
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        /// <param name="testFibNum"> Takes in the number of testFibNum. </param>
        [Test]
        public void TestExceptionCase()
        {
            int testFibNum = -1;
            return;
        }
    }
}