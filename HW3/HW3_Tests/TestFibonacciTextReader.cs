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
            int testFibNumber = 3; // The nth number we are testing for.

            // Our two string builders to be used to compare.
            StringBuilder correctResult = new StringBuilder();
            StringBuilder fibonacciResult = new StringBuilder();

            // Adding in our known correct numbers into the correct result to be checked.
            correctResult.Append("1: " + "0" + Environment.NewLine);
            correctResult.Append("2: " + "1" + Environment.NewLine);
            correctResult.Append("3: " + "1" + Environment.NewLine);

            // Make an instance of our FibonacciTextReader class to use the functions.
            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // Run the ReadToEnd function and append that to the string builder
            fibonacciResult.Append(fibNumberGenerator.ReadToEnd());

            // Make a variable that checks the similarity of the correct result vs the fibonacci string.
            var expectedResult = new Likeness<StringBuilder, StringBuilder>(correctResult);

            // Returns a valid if they happen to be the same.
            Assert.AreEqual(expectedResult, fibonacciResult);
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        [Test]
        public void TestNormalCaseForFirstNum()
        {
            int testFibNumber = 1; // The nth number we are testing for.

            // Our two string builders to be used to compare.
            StringBuilder correctResult = new StringBuilder();
            StringBuilder fibonacciResult = new StringBuilder();

            // Adding in our known correct numbers into the correct result to be checked.
            correctResult.Append("1: " + "0" + Environment.NewLine);

            // Make an instance of our FibonacciTextReader class to use the functions.
            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // Run the ReadToEnd function and append that to the string builder
            fibonacciResult.Append(fibNumberGenerator.ReadToEnd());

            // Make a variable that checks the similarity of the correct result vs the fibonacci string.
            var expectedResult = new Likeness<StringBuilder, StringBuilder>(correctResult);

            // Returns a valid if they happen to be the same.
            Assert.AreEqual(expectedResult, fibonacciResult);
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        [Test]
        public void TestNormalCaseForSecondNum()
        {
            int testFibNumber = 2; // The nth number we are testing for.

            // Our two string builders to be used to compare.
            StringBuilder correctResult = new StringBuilder();
            StringBuilder fibonacciResult = new StringBuilder();

            // Adding in our known correct numbers into the correct result to be checked.
            correctResult.Append("1: " + "0" + Environment.NewLine);
            correctResult.Append("2: " + "1" + Environment.NewLine);

            // Make an instance of our FibonacciTextReader class to use the functions.
            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // Run the ReadToEnd function and append that to the string builder
            fibonacciResult.Append(fibNumberGenerator.ReadToEnd());

            // Make a variable that checks the similarity of the correct result vs the fibonacci string.
            var expectedResult = new Likeness<StringBuilder, StringBuilder>(correctResult);

            // Returns a valid if they happen to be the same.
            Assert.AreEqual(expectedResult, fibonacciResult);
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        [Test]
        public void TestExceptionCaseNegativeOne()
        {
            int testFibNumber = -1; // Attempting to find the -1th Fibonacci number

            // Make an instance of our FibonacciTextReader class to use the functions.
            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // This will throw an out of bounds error in the case that the number that is inputed happens to be less than 1
            Assert.Throws<ArgumentOutOfRangeException>(() => fibNumberGenerator.ReadToEnd());
        }

        /// <summary>
        /// Testing to see if the number that comes in is able to compute to the right number.
        /// </summary>
        [Test]
        public void TestExceptionCasePushMaxLimit()
        {
            int testFibNumber = 3; // The nth number we are testing for.

            // Our two string builders to be used to compare.
            StringBuilder correctResult = new StringBuilder();
            StringBuilder fibonacciResult = new StringBuilder();

            // Adding in our known correct numbers into the correct result to be checked.
            correctResult.Append("0" + Environment.NewLine);
            correctResult.Append("1" + Environment.NewLine);
            correctResult.Append("1" + Environment.NewLine);
            correctResult.Append(Environment.NewLine);

            // Make an instance of our FibonacciTextReader class to use the functions.
            FibonacciTextReader fibNumberGenerator = new FibonacciTextReader(testFibNumber);

            // For loop that goes through and tests the foundation function which is the read line and iterates until the max number
            for (int lineCounter = 1; lineCounter <= testFibNumber + 1; lineCounter++)
            {
                // Keep on appending until we reach the end. In this case, it will only return nulls
                fibonacciResult.Append(fibNumberGenerator.ReadLine() + Environment.NewLine);
            }

            // Make a variable that checks the similarity of the correct result vs the fibonacci string.
            var expectedResult = new Likeness<StringBuilder, StringBuilder>(correctResult);

            // Returns a valid if they happen to be the same.
            Assert.AreEqual(expectedResult, fibonacciResult);
        }
    }
}