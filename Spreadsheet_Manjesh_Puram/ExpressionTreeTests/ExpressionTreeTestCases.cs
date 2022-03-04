// <copyright file="ExpressionTreeTestCases.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CptS321
{
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
        /// Test case to test the functionality to see if our multiplcation works.
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
    }
}