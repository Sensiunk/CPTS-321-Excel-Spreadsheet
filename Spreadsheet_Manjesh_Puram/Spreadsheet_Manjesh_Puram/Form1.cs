// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Spreadsheet_Manjesh_Puram
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// This is the class for the form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Spreadsheet instance.
        /// </summary>
        private CptS321.Spreadsheet mainSpreadsheet;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            this.Text = "Spreadsheet Cpts 321"; // Change the top header to contain "Spreadsheet Cpts 321"

            this.mainSpreadsheet = new CptS321.Spreadsheet(50, 26); // Make a spreadsheet of size 50 x 26

            this.mainSpreadsheet.CellPropertyChanged += this.RefreshPage; // Subscribe the whole spreadsheet to the RefreshPage

            this.DemoButton.Text = "Perform Demo"; // Change the name of the button
        }

        /// <summary>
        /// Form load function that takes assembles the grid view.
        /// </summary>
        /// <param name="sender"> Sender object. </param>
        /// <param name="e"> EventArgs e. </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // For loop that takes a number and converts the ascii to a letter an places it in the column
            for (int i = 65; i <= 90; i++)
            {
                string letter = ((char)i).ToString();

                this.SpreadsheetGridView.Columns.Add("newColumnName" + i, letter);
            }

            // Clear and allocate space for 50 rows.
            this.SpreadsheetGridView.Rows.Clear();
            this.SpreadsheetGridView.Rows.Add(50);

            // Load all the number in the rows
            for (int i = 1; i <= 50; i++)
            {
                this.SpreadsheetGridView.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }

        /// <summary>
        /// RefreshPage function to react when the CellRefresh is fired.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> PropertyChangedEventArgs e. </param>
        private void RefreshPage(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CellRefresh")
            {
                CptS321.SpreadsheetCell refreshCell = (CptS321.SpreadsheetCell)sender;

                // If the refreshCell isn't null then we go into the condition and set the values
                if (refreshCell != null)
                {
                    int cellRow = refreshCell.RowIndex;
                    int cellColumn = refreshCell.ColumnIndex;

                    // Refreshes the item in that certain spot in the Spreadsheet Grid View
                    this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Value = refreshCell.CellValue;
                }
            }
        }

        /// <summary>
        /// Function to get the demo button to work.
        /// </summary>
        /// <param name="sender"> Object sender to get the sender to work. </param>
        /// <param name="e"> EventArgs e. </param>
        private void DemoButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // For loop that finds cells to place the word "Random Placement!" in
            for (int counter = 0; counter < 50; counter++)
            {
                int randomRow = random.Next(0, 49);
                int randomColumn = random.Next(0, 26);

                this.RandomPlacement(randomRow, randomColumn);
            }

            // For loop that calls the CellBPlacement
            for (int rowNum = 0; rowNum < 50; rowNum++)
            {
                this.CellBPlacement(rowNum);
            }

            // For loop that calls the EqualsCellBPlacement
            for (int rowNum = 0; rowNum < 50; rowNum++)
            {
                this.EqualsCellBPlacement(rowNum);
            }
        }

        /// <summary>
        /// Random Placement function that places the word "Random Placement" in random cells.
        /// </summary>
        /// <param name="row"> Takes in a random row to place in. </param>
        /// <param name="column"> Takes in a random column to place in. </param>
        private void RandomPlacement(int row, int column)
        {
            CptS321.SpreadsheetCell currentCell = this.mainSpreadsheet.GetCell(row, column);
            currentCell.CellText = "Random Placement!";
        }

        /// <summary>
        /// Function to place items in the Cell B's with the number attached to it.
        /// </summary>
        /// <param name="rowNumber"> Random number for the row. </param>
        private void CellBPlacement(int rowNumber)
        {
            CptS321.SpreadsheetCell currentCell = this.mainSpreadsheet.GetCell(rowNumber, 1);
            currentCell.CellText = "This is cell B" + (rowNumber + 1);
        }

        /// <summary>
        /// Function to place the items in the Cell B into the Cell A with the automatic firing happening.
        /// </summary>
        /// <param name="rowNumber"> Random number for the row. </param>
        private void EqualsCellBPlacement(int rowNumber)
        {
            CptS321.SpreadsheetCell currentCell = this.mainSpreadsheet.GetCell(rowNumber, 0);
            currentCell.CellText = "=B" + (rowNumber + 1);
        }
    }
}
