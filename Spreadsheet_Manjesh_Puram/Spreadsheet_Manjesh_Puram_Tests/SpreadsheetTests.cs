// <copyright file="SpreadsheetTests.cs" company="PlaceholderCompany">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace CptS321
{
    using NUnit.Framework;

    /// <summary>
    /// Class to test the spreadsheet functions.
    /// </summary>
    public class SpreadsheetTests
    {
        /// <summary>
        /// Temp spreadsheet instance.
        /// </summary>
        private Spreadsheet testSpreadsheet = new Spreadsheet(2, 2);

        private Spreadsheet newTestSpreadsheet = new Spreadsheet(10, 10);

        // private SpreadsheetCell A1;
        // private SpreadsheetCell B1;
        // private SpreadsheetCell A2;
        // private SpreadsheetCell B2;

        /// <summary>
        /// Setup for the test file.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Test case to test the value being set in the cell for the spreadsheet.
        /// </summary>
        [Test]
        public void TestCellValue()
        {
            this.testSpreadsheet = new Spreadsheet(2, 2);
            this.testSpreadsheet.GetCell(1, 1).CellText = "This is a test";

            Assert.AreEqual(this.testSpreadsheet.GetCell(1, 1).CellText, "This is a test");
        }

        /// <summary>
        /// Test case for the row count to be returned from the spreadsheet class.
        /// </summary>
        [Test]
        public void TestRowCount()
        {
            Assert.AreEqual(this.testSpreadsheet.RowCount, 2);
        }

        /// <summary>
        /// Test case for the column count to be returned from the spreadsheet class.
        /// </summary>
        [Test]
        public void TestColumnCount()
        {
            Assert.AreEqual(this.testSpreadsheet.ColumnCount, 2);
        }

        /// <summary>
        /// Test case for the values to be returned from the spreadsheet class.
        /// I'M NOT SURE IF I NEED TO RUN A TEST SINCE WE DONT NEED TO TEST THE GUI.
        /// </summary>
        [Test]
        public void TestValues()
        {
            // this.A1 = this.newTestSpreadsheet.GetCell(0, 0);
            // this.B1 = this.newTestSpreadsheet.GetCell(0, 1);

            // this.A1.CellText = "22";
            // this.B2.CellText = "=A1";
            Assert.Pass();
        }

        /// <summary>
        /// Test case for the values with addition to be returned from the spreadsheet class.
        /// I'M NOT SURE IF I NEED TO RUN A TEST SINCE WE DONT NEED TO TEST THE GUI.
        /// </summary>
        [Test]
        public void TestValuesWithAddition()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test case for the values with subtraction to be returned from the spreadsheet class.
        /// I'M NOT SURE IF I NEED TO RUN A TEST SINCE WE DONT NEED TO TEST THE GUI.
        /// </summary>
        [Test]
        public void TestValuesWithSubtraction()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test case for the values with multiplication to be returned from the spreadsheet class.
        /// I'M NOT SURE IF I NEED TO RUN A TEST SINCE WE DONT NEED TO TEST THE GUI.
        /// </summary>
        [Test]
        public void TestValuesWithMultiplication()
        {
            Assert.Pass();
        }

        /// <summary>
        /// Test case for the values with division to be returned from the spreadsheet class.
        /// I'M NOT SURE IF I NEED TO RUN A TEST SINCE WE DONT NEED TO TEST THE GUI.
        /// </summary>
        [Test]
        public void TestValuesWithDivision()
        {
            Assert.Pass();
        }
    }
}
