// <copyright file="ExpressionTreeTestCases.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
    using System.Globalization;
    using NUnit.Framework;

    /// <summary>
    /// Tests class to test to features in the expression tree.
    /// </summary>
    public class ExpressionTreeTestCases
    {
        /// <summary>
        /// Setup if needed for our test cases.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test case to test the functionality to see if our addition works.
        /// </summary>
        [Test]
        public void TestAdditionExpression()
        {
            ExpressionTree testTree = new ExpressionTree("1+2+3+4");
            Assert.AreEqual(testTree.Evaluate(), 10);
        }

        /// <summary>
        /// Test case to test the functionality to see if our addition works.
        /// </summary>
        [Test]
        public void TestAdditionWithSpaceExpression()
        {
            ExpressionTree testTree = new ExpressionTree("1 + 2 + 3 + 4");
            Assert.AreEqual(testTree.Evaluate(), 10);
        }

        /// <summary>
        /// Test case to test the functionality to see if our subtraction works.
        /// </summary>
        [Test]
        public void TestSubtractionExpression()
        {
            ExpressionTree testTree = new ExpressionTree("10-5-4");
            Assert.AreEqual(testTree.Evaluate(), 1);
        }

        /// <summary>
        /// Test case to test the functionality to see if our subtraction works.
        /// </summary>
        [Test]
        public void TestSubtractionWithSpacesExpression()
        {
            ExpressionTree testTree = new ExpressionTree("10 - 5 - 4");
            Assert.AreEqual(testTree.Evaluate(), 1);
        }

        /// <summary>
        /// Test case to test the functionality to see if our subtraction works.
        /// </summary>
        [Test]
        public void TestSubtractionToNegativeExpression()
        {
            ExpressionTree testTree = new ExpressionTree("10-5-10");
            Assert.AreEqual(testTree.Evaluate(), -5);
        }

        /// <summary>
        /// Test case to test the functionality to see if our multiplication works.
        /// </summary>
        [Test]
        public void TestMultiplicationExpression()
        {
            ExpressionTree testTree = new ExpressionTree("2*3*4");
            Assert.AreEqual(testTree.Evaluate(), 24);
        }

        /// <summary>
        /// Test case to test the functionality to see if our division works.
        /// </summary>
        [Test]
        public void TestDivisionExpression()
        {
            ExpressionTree testTree = new ExpressionTree("27/9/3");
            Assert.AreEqual(testTree.Evaluate(), 1);
        }

        /// <summary>
        /// Test case to test the functionality to see if our division works.
        /// </summary>
        [Test]
        public void TestDivisionPositiveByZeroExpression()
        {
            ExpressionTree testTree = new ExpressionTree("27/0");
            Assert.AreEqual(testTree.Evaluate(), double.PositiveInfinity);
        }

        /// <summary>
        /// Test case to test the functionality to see if sending a blank expression returns a 0.0.
        /// </summary>
        [Test]
        public void TestEmptyExpression()
        {
            ExpressionTree testTree = new ExpressionTree(string.Empty);
            Assert.AreEqual(testTree.Evaluate(), 0);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when we do addition of two max values.
        /// </summary>
        [Test]
        public void TestAdditionInfinityExpression()
        {
            string maxValue = double.MaxValue.ToString("F", CultureInfo.InvariantCulture);
            ExpressionTree testTree = new ExpressionTree($"{maxValue}+{maxValue}");
            Assert.AreEqual(testTree.Evaluate(), double.PositiveInfinity);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when we do addition of two max values.
        /// </summary>
        [Test]
        public void TestAdditionNegativeInfinityExpression()
        {
            string minValue = double.MinValue.ToString("F", CultureInfo.InvariantCulture);
            ExpressionTree testTree = new ExpressionTree($"{minValue}+{minValue}");
            Assert.AreEqual(testTree.Evaluate(), double.NegativeInfinity);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when we do subtraction of two max values.
        /// </summary>
        [Test]
        public void TestSubtractionNegativeInfinityExpression()
        {
            string minValue = double.MinValue.ToString("F", CultureInfo.InvariantCulture);
            ExpressionTree testTree = new ExpressionTree($"{minValue}-{minValue}");
            Assert.AreEqual(testTree.Evaluate(), double.NegativeInfinity);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when we do multiplication of two max values.
        /// </summary>
        [Test]
        public void TestMultiplicationInfinityExpression()
        {
            string maxValue = double.MaxValue.ToString("F", CultureInfo.InvariantCulture);
            ExpressionTree testTree = new ExpressionTree($"{maxValue}*{maxValue}");
            Assert.AreEqual(testTree.Evaluate(), double.PositiveInfinity);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when there is precedence involved.
        /// </summary>
        public void TestWithPrecedence()
        {
            Assert.AreEqual(0, 0);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when there is parentheses involved.
        /// </summary>
        public void TestWithParentheses()
        {
            Assert.AreEqual(0, 0);
        }

        /// <summary>
        /// Test case to test the functionality to see if it knows what to do when there is the same precedence involved.
        /// </summary>
        public void TestEqualPrecedence()
        {
            Assert.AreEqual(0, 0);
        }
    }
}