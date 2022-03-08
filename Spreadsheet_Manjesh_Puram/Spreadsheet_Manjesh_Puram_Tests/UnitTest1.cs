namespace CptS321
{
    using NUnit.Framework;

    public class Tests
    {

        private CptS321.Spreadsheet testSpreadsheet = new Spreadsheet(2, 2);

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCellValue()
        {
            this.testSpreadsheet = new Spreadsheet(2, 2);
            this.testSpreadsheet.GetCell(1,1).CellText = "This is a test";

            Assert.AreEqual(this.testSpreadsheet.GetCell(1, 1).CellText, "This is a test");
        }

        [Test]
        public void TestRowCount()
        {
            Assert.AreEqual(this.testSpreadsheet.RowCount, 2);
        }

        [Test]
        public void TestColumnCount()
        {
            Assert.AreEqual(this.testSpreadsheet.ColumnCount, 2);
        }

    }
}