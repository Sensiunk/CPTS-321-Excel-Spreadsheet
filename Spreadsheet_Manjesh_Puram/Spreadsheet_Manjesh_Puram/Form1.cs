// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
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
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 65; i <= 90; i++)
            {
                string letter = ((char)i).ToString();

                this.SpreadsheetGridView.Columns.Add("newColumnName" + i, letter);
            }

            this.SpreadsheetGridView.Rows.Clear();
            this.SpreadsheetGridView.Rows.Add(50);

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

        }
    }
}
