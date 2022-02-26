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
        private CptS321.Spreadsheet testSpreadsheet = new Spreadsheet(2, 2);

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

    }
}