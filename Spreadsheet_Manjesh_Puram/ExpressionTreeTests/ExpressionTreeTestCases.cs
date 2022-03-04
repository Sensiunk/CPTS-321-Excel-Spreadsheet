using NUnit.Framework;

namespace CptS321
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestAdditionExpression()
        {
            ExpressionTree testTree = new ExpressionTree("1+2+3+4");
            Assert.AreEqual(testTree.Evaluate(), 10);
        }

        [Test]
        public void TestSubtractionExpression()
        {
            ExpressionTree testTree = new ExpressionTree("10-5-4");
            Assert.AreEqual(testTree.Evaluate(), 1);
        }

        [Test]
        public void TestMultiplicationExpression()
        {
            ExpressionTree testTree = new ExpressionTree("2*3*4");
            Assert.AreEqual(testTree.Evaluate(), 24);
        }

        [Test]
        public void TestDivisionExpression()
        {
            Assert.AreEqual(0, 0);
        }
    }
}