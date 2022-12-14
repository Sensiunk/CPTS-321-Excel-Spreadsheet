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
    using System.IO;
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

            this.SpreadsheetGridView.CellBeginEdit += this.SpreadsheetGridView_CellBeginEdit; // Subscribe the GridView to the CellBeginEdit
            this.SpreadsheetGridView.CellEndEdit += this.SpreadsheetGridView_CellEndEdit; // Subscribe the GridView to the CellEndEdit

            this.DemoButton.Text = "Perform Demo - DON'T PRESS"; // Change the name of the button

            // Set the default of the undo button.
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Text = "Undo Not Available";

            // Set the default of the redo button.
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Text = "Redo Not Available";

            // Set the default of the loadFromXMLFile button.
            this.loadFromXMLToolStripMenuItem.Enabled = true;
            this.loadFromXMLToolStripMenuItem.Text = "Load from XML File";

            // Set the default of the saveToXMLFile button.
            this.saveToXMLToolStripMenuItem.Enabled = true;
            this.saveToXMLToolStripMenuItem.Text = "Save to XML File";
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
            else if (e.PropertyName == "CellColorChanged")
            {
                CptS321.SpreadsheetCell refreshCell = (CptS321.SpreadsheetCell)sender;

                // If the refreshCell isn't null then we go into the condition and set the values
                if (refreshCell != null)
                {
                    int cellRow = refreshCell.RowIndex;
                    int cellColumn = refreshCell.ColumnIndex;

                    // Refreshes the item in that certain spot in the Spreadsheet Grid View
                    this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Style.BackColor = Color.FromArgb((int)refreshCell.BGColor);
                }
            }
            else if (e.PropertyName == "Cell")
            {
                CptS321.SpreadsheetCell refreshCell = (CptS321.SpreadsheetCell)sender;

                // If the refreshCell isn't null then we go into the condition and set the values
                if (refreshCell != null)
                {
                    int cellRow = refreshCell.RowIndex;
                    int cellColumn = refreshCell.ColumnIndex;

                    // Refreshes the item in that certain spot in the Spreadsheet Grid View
                    this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Value = refreshCell.CellValue;

                    // Refreshes the item in that certain spot in the Spreadsheet Grid View
                    this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Style.BackColor = Color.FromArgb((int)refreshCell.BGColor);
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

        /// <summary>
        /// Function that gets subcribed to so that when we get into the cell end edit we know what to do.
        /// </summary>
        /// <param name="sender"> object sender. </param>
        /// <param name="e"> DataGridViewCellCancelEventsArgs e. </param>
        private void SpreadsheetGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Grabing the cellrow and cellcolumn from the event args.
            int cellRow = e.RowIndex;
            int cellColumn = e.ColumnIndex;

            // Grab the cell that contains this details.
            CptS321.SpreadsheetCell currentCell = this.mainSpreadsheet.GetCell(cellRow, cellColumn);

            // If the cell is not null then we all good!
            if (currentCell != null)
            {
                // Set the value of the cell to our spreadsheets cell text.
                this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Value = currentCell.CellText;
            }
        }

        /// <summary>
        /// Function that gets subcribed to so that when we get into the cell end edit we know what to do.
        /// </summary>
        /// <param name="sender"> object sender. </param>
        /// <param name="e"> DataGridViewCellEventsArgs e. </param>
        private void SpreadsheetGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Grabing the cellrow and cellcolumn from the event args.
            int cellRow = e.RowIndex;
            int cellColumn = e.ColumnIndex;

            // Grab the cell that contains this details.
            CptS321.SpreadsheetCell currentCell = this.mainSpreadsheet.GetCell(cellRow, cellColumn);

            // Gets a copy of the cell and sets it to copy cell.
            CptS321.SpreadsheetCell copyCell = this.mainSpreadsheet.GetCell(cellRow, cellColumn).DuplicateCurrentCell();

            // Add the cell with the message that the text changed.
            this.mainSpreadsheet.AddUndo(copyCell, "Change in Text");

            // Enable the undo button and set what could be changed in the text field.
            this.undoToolStripMenuItem.Enabled = true;
            this.undoToolStripMenuItem.Text = "Undo " + this.mainSpreadsheet.UndoStackMessage();

            // If the cell is not null then we all good!
            if (currentCell != null)
            {
                // Attempt to grab the string.
                try
                {
                    currentCell.CellText = this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Value.ToString();
                }

                // If we aren't successful then set the text to blank.
                catch
                {
                    currentCell.CellText = string.Empty;
                }

                // Set the value of the cell to our spreadsheets cell value.
                this.SpreadsheetGridView.Rows[cellRow].Cells[cellColumn].Value = currentCell.CellValue;
            }
        }

        /// <summary>
        /// Menu strip button that holds the ability to change colors of the cell.
        /// </summary>
        /// <param name="sender"> object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void ChangeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.SpreadsheetGridView.SelectedCells.Count >= 1)
            {
                ColorDialog myDialog = new ColorDialog();

                // Keeps the user from selecting a custom color.
                myDialog.AllowFullOpen = false;

                // Allows the user to get help. (The default is false.)
                myDialog.ShowHelp = true;

                // Sets the initial color select to the current text color.
                myDialog.Color = this.SpreadsheetGridView.SelectedCells[0].Style.BackColor;

                // Update the text box color if the user clicks OK
                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    // Push the number of cells that were highlighted to be changed.
                    this.mainSpreadsheet.ColorCounterForUndo.Push(this.SpreadsheetGridView.SelectedCells.Count);

                    // Iterates up until the amount of cells selected.
                    for (int index = 0; index < this.SpreadsheetGridView.SelectedCells.Count; index++)
                    {
                        // Grabs the cells rows and columns and sets them to a variable we can use.
                        int cellRow = this.SpreadsheetGridView.SelectedCells[index].RowIndex;
                        int cellColumn = this.SpreadsheetGridView.SelectedCells[index].ColumnIndex;

                        // Gets a copy of the cell and sets it to copy cell.
                        CptS321.SpreadsheetCell copyCell = this.mainSpreadsheet.GetCell(cellRow, cellColumn).DuplicateCurrentCell();

                        // Add the cell with the message that the color changed.
                        this.mainSpreadsheet.AddUndo(copyCell, "Change in Color");

                        // Enable the undo button and set what could be changed in the text field.
                        this.undoToolStripMenuItem.Enabled = true;
                        this.undoToolStripMenuItem.Text = "Undo " + this.mainSpreadsheet.UndoStackMessage();

                        // Use the values we got and pull up the cell at that location.
                        CptS321.SpreadsheetCell currentCell = this.mainSpreadsheet.GetCell(cellRow, cellColumn);

                        // Set the values which will trigger the event.
                        currentCell.BGColor = (uint)((myDialog.Color.A << 24) | (myDialog.Color.R << 16) |
                                (myDialog.Color.G << 8) | (myDialog.Color.B << 0));
                    }
                }
            }
        }

        /// <summary>
        /// I can't really get rid of this or the program will complain.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void CellToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// I can't really get rid of this or the program will complain.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Method to allow the undo button to work.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if next option in the undo line is the color.
            if (this.undoToolStripMenuItem.Text == "Undo Change in Color")
            {
                // If the next change is color then we push the number of iterations off of the stack.
                int numberOfTimes = this.mainSpreadsheet.ColorCounterForUndo.Pop();

                // Since we popped off the undo stack we need to let the redo stack know as well.
                this.mainSpreadsheet.ColorCounterForRedo.Push(numberOfTimes);

                // Change the color X amount of times depending on when it was first created.
                for (int counter = 1; counter <= numberOfTimes; counter++)
                {
                    // Call our helper each time.
                    this.UndoSupplement();
                }
            }
            else
            {
                // Call our helper function.
                this.UndoSupplement();
            }
        }

        /// <summary>
        /// Function that serves the purpose of helping the undo button.
        /// </summary>
        private void UndoSupplement()
        {
            // Get the cell that is about to be undo'd
            CptS321.UndoRedoCollection undoCell = this.mainSpreadsheet.FeedBackValueForUndo();

            // If the cell is not null then we can add it to the redostack
            if (undoCell != null)
            {
                this.mainSpreadsheet.AddRedo(undoCell.RetiredCell, undoCell.ButtonMessage);
                this.redoToolStripMenuItem.Enabled = true;
                this.redoToolStripMenuItem.Text = "Redo " + this.mainSpreadsheet.RedoStackMessage();
            }

            // Since we added to the redo we know that we can undo that.
            this.undoToolStripMenuItem.Enabled = true;
            this.undoToolStripMenuItem.Text = "Undo " + this.mainSpreadsheet.UndoStackMessage();

            // Check if the stack is empty
            if (this.mainSpreadsheet.UndoStackCount() == 0)
            {
                // If it is indeed empty then disable the button and tell the user its not available.
                this.undoToolStripMenuItem.Enabled = false;
                this.undoToolStripMenuItem.Text = "Undo Not Available";
            }
            else
            {
                // The stack isn't empty so we can enable it.
                this.undoToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Method to allow the redo button to work.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if next option in the redo line is the color.
            if (this.redoToolStripMenuItem.Text == "Redo Change in Color")
            {
                // If the next change is color then we push the number of iterations off of the stack.
                int numberOfTimes = this.mainSpreadsheet.ColorCounterForRedo.Pop();

                // Since we popped off the undo stack we need to let the redo stack know as well.
                this.mainSpreadsheet.ColorCounterForUndo.Push(numberOfTimes);

                // Change the color X amount of times depending on when it was first created.
                for (int counter = 1; counter <= numberOfTimes; counter++)
                {
                    // Call our helper each time.
                    this.RedoSupplement();
                }
            }
            else
            {
                // Call our helper function.
                this.RedoSupplement();
            }
        }

        private void RedoSupplement()
        {
            // Get the cell that is about to be redo'd
            CptS321.UndoRedoCollection undoCell = this.mainSpreadsheet.FeedBackValueForRedo();

            // If the cell is not null then we can add it to the undostack
            if (undoCell != null)
            {
                this.mainSpreadsheet.AddUndo(undoCell.RetiredCell, undoCell.ButtonMessage);
                this.undoToolStripMenuItem.Enabled = true;
                this.undoToolStripMenuItem.Text = "Undo " + this.mainSpreadsheet.UndoStackMessage();
            }

            // Since we added to the undo we know that we can redo that.
            this.redoToolStripMenuItem.Enabled = true;
            this.redoToolStripMenuItem.Text = "Redo " + this.mainSpreadsheet.RedoStackMessage();

            // Check if the stack is empty
            if (this.mainSpreadsheet.RedoStackCount() == 0)
            {
                // If it is indeed empty then disable the button and tell the user its not available.
                this.redoToolStripMenuItem.Enabled = false;
                this.redoToolStripMenuItem.Text = "Redo Not Available";
            }
            else
            {
                // The stack isn't empty so we can enable it.
                this.redoToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Extra function to allow me to close the program properly and return code 0.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void ExitProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        /// <summary>
        /// Function to handle the loading from an XML file to import into our spreadsheet.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void LoadFromXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Locks in the presets we want.
            openFileDialog.Title = "Identify which XML file you would like to use.";
            openFileDialog.InitialDirectory = @"c:\";
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            // Checks if we were able to open
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                Console.WriteLine(fileName);

                // Makes the spreadsheet by clearing all entries.
                while (this.mainSpreadsheet.UndoStackCount() != 0)
                {
                    this.UndoSupplement();
                }

                // Sets the redo to disabled so we can't click on it by accident.
                this.redoToolStripMenuItem.Enabled = false;
                this.redoToolStripMenuItem.Text = "Redo Not Available";

                Stream fileStream = openFileDialog.OpenFile();

                // Runs the loading with the file we got.
                this.mainSpreadsheet.LoadXMLFileIntoCells(fileStream);
            }
        }

        /// <summary>
        /// Function to handle the saving to an XML file for export of our spreadsheet.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> EventArgs e. </param>
        private void SaveToXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream fileStream;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Defaults the location and the accepted files.
            saveFileDialog.Title = "Identify which XML file you would like to use.";
            saveFileDialog.InitialDirectory = @"c:\";
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";

            // Checks if we were able open
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = saveFileDialog.OpenFile()) != null)
                {
                    // TESTING PURPOSES
                    string fileName = saveFileDialog.FileName;
                    Console.WriteLine(fileName);

                    // Runs the saving with the file we got.
                    this.mainSpreadsheet.SaveCellsIntoXMLFile(fileStream);

                    // Close the file.
                    fileStream.Close();
                }
            }
        }
    }
}
