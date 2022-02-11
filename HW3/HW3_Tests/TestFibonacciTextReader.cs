// <copyright file="TestFibonacciTextReader.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HW3.FibonacciTextReader.Tests
{
    using System;
    using System.IO;
    using System.Text;
    using NUnit.Framework;
    using SemanticComparison;

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
        [Test]
        public void TestNormalCase()
        {
            int testFibNumber = 3;

            StringBuilder correctResult = new StringBuilder();
            StringBuilder fibonacciResult = new StringBuilder();

            correctResult.Append("0" + Environment.NewLine);
            correctResult.Append("1" + Environment.NewLine);
            correctResult.Append("1" + Environment.NewLine);

            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // calculate the sequence of fibonacci numbers
            // up to the maximumLines
            for (int i = 1; i <= testFibNumber; i++)
            {
                // append the fibonacci number to the result
                fibonacciResult.Append(fibNumberGenerator.ReadLine() + Environment.NewLine);
            }
            var expectedResult = new Likeness<StringBuilder, StringBuilder>(correctResult);
            Assert.AreEqual(expectedResult, fibonacciResult);
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        [Test]
        public void TestNormalCaseForZero()
        {
            int testFibNumber = 0;

            StringBuilder correctResult = new StringBuilder();
            StringBuilder fibonacciResult = new StringBuilder();

            correctResult.Append("0" + Environment.NewLine);

            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // calculate the sequence of fibonacci numbers
            // up to the maximumLines
            for (int i = 0; i <= testFibNumber; i++)
            {
                // append the fibonacci number to the result
                fibonacciResult.Append(fibNumberGenerator.ReadLine() + Environment.NewLine);
            }
            var expectedResult = new Likeness<StringBuilder, StringBuilder>(correctResult);
            Assert.AreEqual(expectedResult, fibonacciResult);
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

            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            Assert.Throws<ArgumentOutOfRangeException>(() => fibNumberGenerator.ReadLine());
        }
    }
}