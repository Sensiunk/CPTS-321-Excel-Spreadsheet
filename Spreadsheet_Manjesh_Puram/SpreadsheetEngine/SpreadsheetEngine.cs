// <copyright file="SpreadsheetEngine.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Abstract class of the Spreadsheet cell.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        /// <summary>
        /// Index of the row.
        /// </summary>
        private int rowIndex;

        /// <summary>
        /// Index of the column.
        /// </summary>
        private int columnIndex;

        /// <summary>
        /// Text in the cell.
        /// </summary>
        private string cellText;

        /// <summary>
        /// Value in the cell.
        /// </summary>
        private string cellValue;

        /// <summary>
        /// Name of the cell.
        /// </summary>
        private string cellName;

        /// <summary>
        /// Create an expression tree for each cell.
        /// </summary>
        private ExpressionTree expTree;

        /// <summary>
        /// Represents the color of the cell.
        /// Defaulted to white.
        /// </summary>
        private uint bgcolor = 0xFFFFFFFF;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="newRowIndex"> Uses the value passed in to set the value of the rowIndex. </param>
        /// <param name="newColumnIndex"> Uses the value passed in to set the value of the columnIndex. </param>
        public SpreadsheetCell(int newRowIndex, int newColumnIndex)
        {
            this.rowIndex = newRowIndex;
            this.columnIndex = newColumnIndex;
            this.cellText = string.Empty;
            this.cellValue = string.Empty;
            this.cellName = Convert.ToChar('A' + newColumnIndex) + (newRowIndex + 1).ToString();
            this.expTree = new ExpressionTree(string.Empty);
        }

        /// <summary>
        /// This is the property changed manager.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets or sets, returns the expression tree when we need access to it.
        /// </summary>
        public ExpressionTree ExpTree
        {
            get
            {
                return this.expTree;
            }

            set
            {
                this.expTree = value;
            }
        }

        /// <summary>
        /// Gets or sets the rowIndex number.
        /// </summary>
        public int RowIndex
        {
            get
            {
                return this.rowIndex;
            }

            set
            {
                this.rowIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the columnIndex number.
        /// </summary>
        public int ColumnIndex
        {
            get
            {
                return this.columnIndex;
            }

            set
            {
                this.columnIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the value of the cellText.
        /// Sets the value if only the value is different.
        /// </summary>
        public string CellText
        {
            get
            {
                return this.cellText;
            }

            set
            {
                if (this.cellText != value)
                {
                    this.cellText = value;

                    this.PropertyChanged(this, new PropertyChangedEventArgs("CellText"));
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the cellValue.
        /// In order to set the value, it must be internal and protected and only gets changed if it is not the same.
        /// </summary>
        public string CellValue
        {
            get
            {
                return this.cellValue;
            }

            protected internal set
            {
                if (this.cellValue != value)
                {
                    this.cellValue = value;

                    this.PropertyChanged(this, new PropertyChangedEventArgs("CellValue"));
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of the bgcolor.
        /// Sets the color if only the color is different.
        /// </summary>
        public uint BGColor
        {
            get
            {
                return this.bgcolor;
            }

            set
            {
                if (this.bgcolor == value)
                {
                    return;
                }

                this.bgcolor = value;

                this.PropertyChanged(this, new PropertyChangedEventArgs("Color"));
            }
        }

        /// <summary>
        /// Gets the value of the cellName.
        /// </summary>
        public string Name
        {
            get
            {
                return this.cellName;
            }
        }

        /// <summary>
        /// Helpful function that serves the purpose of checking if we need to save this cell or not.
        /// </summary>
        /// <returns> Returns true if there is something in this cell that isn't the default. </returns>
        public bool IsFilledIn()
        {
            // This means that there is atleast one change.
            if (this.CellText.Length > 0 || this.BGColor != 0xFFFFFFFF)
            {
                return true;
            }

            // This means that there isn't any change.
            return false;
        }

        /// <summary>
        /// Function that duplicates our cell so that we have a copy of it when we pass it into the stack.
        /// </summary>
        /// <returns> Returns the cell that was copy with the information in this cell. </returns>
        public SpreadsheetCell DuplicateCurrentCell()
        {
            // Making an new instance of the cell which was originally declared as a NewCell
            SpreadsheetCell duplicate = new NewCell(this.RowIndex, this.ColumnIndex)
            {
                CellText = this.CellText,
                RowIndex = this.RowIndex,
                ColumnIndex = this.ColumnIndex,
                BGColor = this.BGColor,
                ExpTree = this.expTree,
            };

            // Returns the cell of the value we had prior to change.
            return duplicate;
        }

        /// <summary>
        /// Property changed event handler.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> PropertyChangedEventArgs e. </param>
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }
    }

    /// <summary>
    /// New Cell class since its an abstract class and instantiating doesn't work smoothly.
    /// </summary>
    public sealed class NewCell : SpreadsheetCell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewCell"/> class.
        /// </summary>
        /// <param name="newRow"> Takes in a newRow value. </param>
        /// <param name="newColumn"> Takes in a newColumn value. </param>
        public NewCell(int newRow, int newColumn)
            : base(newRow, newColumn)
        {
        }
    }

    /// <summary>
    /// Class that holds the cells and methods to support the operation of undoing and redoing.
    /// </summary>
    public class UndoRedoCollection
    {
        private SpreadsheetCell retiredCell;

        private string buttonMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoCollection"/> class.
        /// Function takes in the cell that was changed and whether it was a text or color and whether it was redo or undo since we support both.
        /// </summary>
        /// <param name="actionCell"> The cell that changed. </param>
        /// <param name="changeMessage"> The message about the details of what happened. </param>
        public UndoRedoCollection(SpreadsheetCell actionCell, string changeMessage)
        {
            this.retiredCell = actionCell;
            this.buttonMessage = changeMessage;
        }

        /// <summary>
        /// Gets old cell that we store.
        /// </summary>
        public SpreadsheetCell RetiredCell
        {
            get
            {
                return this.retiredCell;
            }
        }

        /// <summary>
        ///  Gets or sets the buttonMessage when called on.
        /// </summary>
        public string ButtonMessage
        {
            // Return the message we stored.
            get
            {
                return this.buttonMessage;
            }

            // Set the value of the message passed in.
            set
            {
                this.buttonMessage = value;
            }
        }

        /// <summary>
        /// Used to get the rowIndex.
        /// </summary>
        /// <returns> Returns the rowIndex. </returns>
        public int GetRowIndex()
        {
            return this.retiredCell.RowIndex;
        }

        /// <summary>
        /// Used to get the columnIndex.
        /// </summary>
        /// <returns> Returns the columnIndex. </returns>
        public int GetColumnIndex()
        {
            return this.retiredCell.ColumnIndex;
        }

        /// <summary>
        /// Function that is called on with a reference of the cell that is in the stack, then gets the old values assigned to it.
        /// </summary>
        /// <param name="operatingCell"> Reference of the cell that needs to be filled in with the information stored in the retiredCell. </param>
        public void FeedBackValue(ref SpreadsheetCell operatingCell)
        {
            operatingCell.CellText = this.retiredCell.CellText;
            operatingCell.BGColor = this.retiredCell.BGColor;
        }
    }

    /// <summary>
    /// Public class of the Spreadsheet.
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Value that contains the number of columns in the spreadsheet.
        /// </summary>
        private int spreadsheetColumn;

        /// <summary>
        /// Value that contains the number of rows in the spreadsheet.
        /// </summary>
        private int spreadsheetRow;

        /// <summary>
        /// Our 2D array that holds the values that correlate with the spreadsheet grid view.
        /// </summary>
        private SpreadsheetCell[,] twoDArray;

        /// <summary>
        /// Stack that will hold the cells that could be undo'd.
        /// </summary>
        private Stack<UndoRedoCollection> undos;

        /// <summary>
        /// Stack that will hold the cells that could be redo'd.
        /// </summary>
        private Stack<UndoRedoCollection> redos;

        /// <summary>
        /// Stack that holds the amount of boxes that need color changes when doing Undo.
        /// </summary>
        private Stack<int> colorCounterForUndo;

        /// <summary>
        /// Stack that holds the amount of boxes that need color changes when doing Redo.
        /// </summary>
        private Stack<int> colorCounterForRedo;

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="newRow"> Construct with a row input. </param>
        /// <param name="newColumn"> Construct with a column input. </param>
        public Spreadsheet(int newRow, int newColumn)
        {
            this.spreadsheetRow = newRow;
            this.spreadsheetColumn = newColumn;

            this.twoDArray = new SpreadsheetCell[newRow, newColumn];

            // Set the undo and redo stack to contain UndoRedoCollection values.
            this.undos = new Stack<UndoRedoCollection>();
            this.redos = new Stack<UndoRedoCollection>();

            // Set the undo and redo counter for the color to int values.
            this.ColorCounterForUndo = new Stack<int>();
            this.ColorCounterForRedo = new Stack<int>();

            for (int i = 0; i < newRow; i++)
            {
                for (int j = 0; j < newColumn; j++)
                {
                    this.twoDArray[i, j] = new NewCell(i, j);
                    this.twoDArray[i, j].CellText = string.Empty;

                    this.twoDArray[i, j].PropertyChanged += this.RefreshCellValue;
                }
            }
        }

        /// <summary>
        /// Event to fire when we have property change in the cell
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Gets property for the ColumnCount.
        /// </summary>
        public int ColumnCount
        {
            get { return this.spreadsheetColumn; }
        }

        /// <summary>
        /// Gets property for the RowCount.
        /// </summary>
        public int RowCount
        {
            get { return this.spreadsheetRow; }
        }

        /// <summary>
        /// Gets or sets, used to calculate how many times we would need to change the color.
        /// </summary>
        public Stack<int> ColorCounterForRedo { get => this.colorCounterForRedo; set => this.colorCounterForRedo = value; }

        /// <summary>
        /// Gets or sets, used to calculate how many times we would need to change the color.
        /// </summary>
        public Stack<int> ColorCounterForUndo { get => this.colorCounterForUndo; set => this.colorCounterForUndo = value; }

        /// <summary>
        /// Used when we need to know the size of the stack and choose whether we should make it clickable or not.
        /// </summary>
        /// <returns> Returns the size of the stack. </returns>
        public int UndoStackCount()
        {
            return this.undos.Count();
        }

        /// <summary>
        /// Used when we need to know the size of the stack and choose whether we should make it clickable or not.
        /// </summary>
        /// <returns> Returns the size of the stack. </returns>
        public int RedoStackCount()
        {
            return this.redos.Count();
        }

        /// <summary>
        /// Grabs the messages of the change status. If there is a change in the text then undo text is done but if its change in color then undo color is done.
        /// </summary>
        /// <returns> Returns the message that needs to be shown. </returns>
        public string UndoStackMessage()
        {
            // If the stack even has anything in it.
            if (this.UndoStackCount() > 0)
            {
                // Will be either Undo Change in Text or Undo Change in Color.
                return this.undos.Peek().ButtonMessage;
            }
            else
            {
                // Not sure how we would even get here but in the failsafe.
                return string.Empty;
            }
        }

        /// <summary>
        /// Grabs the messages of the change status. If there is a change in the text then redo text is done but if its change in color then redo color is done.
        /// </summary>
        /// <returns> Returns the message that needs to be shown. </returns>
        public string RedoStackMessage()
        {
            // If the stack even has anything in it.
            if (this.RedoStackCount() > 0)
            {
                // Will be either Redo Change in Text or Redo Change in Color.
                return this.redos.Peek().ButtonMessage;
            }
            else
            {
                // Not sure how we would even get here but in the failsafe.
                return string.Empty;
            }
        }

        /// <summary>
        /// Adds the ability to add commands throguh public functions.
        /// </summary>
        /// <param name="undoCell"> Cell that we are passing into the stack. </param>
        /// <param name="changeMessage"> Message to denote whether it was a change in text or color. </param>
        public void AddUndo(SpreadsheetCell undoCell, string changeMessage)
        {
            // Push on the new value.
            this.undos.Push(new UndoRedoCollection(undoCell, changeMessage));
        }

        /// <summary>
        /// Since the information will be stored when we create the undo, this will hold the information of the change message.
        /// </summary>
        /// <param name="undoCell"> Cell that we are passing into the stack. </param>
        /// <param name="changeMessage"> Message to denote whether it was a change in text or color. </param>
        public void AddRedo(SpreadsheetCell undoCell, string changeMessage)
        {
            // Push on the new value.
            this.redos.Push(new UndoRedoCollection(undoCell, changeMessage));
        }

        /// <summary>
        /// GetCell function that returns a SpreadsheetCell so it can retrieve the values from that cell.
        /// </summary>
        /// <param name="inputRow"> InputRow takes the location of that index. </param>
        /// <param name="inputColumn"> InputColumn takes the location of that index. </param>
        /// <returns> Returns the Cell at that location. </returns>
        public SpreadsheetCell GetCell(int inputRow, int inputColumn)
        {
            if (this.twoDArray[inputRow, inputColumn] == null)
            {
                return null;
            }
            else
            {
                return this.twoDArray[inputRow, inputColumn];
            }
        }

        /// <summary>
        /// Function pops the top value of the undo stack and retuns the value to pass it back into the redoStack.
        /// </summary>
        /// <returns> Returns information to be added to the redoStack after. </returns>
        public UndoRedoCollection FeedBackValueForUndo()
        {
            // Check if the undo stack has something in it.
            if (this.UndoStackCount() >= 1)
            {
                // Pop the value from the undo stack.
                UndoRedoCollection undoCell = this.undos.Pop();

                // Grab the row and column from the popped cell.
                int rowIndex = undoCell.GetRowIndex();
                int columnIndex = undoCell.GetColumnIndex();

                // Set the cell to a duplicate with the message.
                UndoRedoCollection redoCell = new UndoRedoCollection(this.twoDArray[rowIndex, columnIndex].DuplicateCurrentCell(), undoCell.ButtonMessage);

                // Change the value at that location.
                undoCell.FeedBackValue(ref this.twoDArray[rowIndex, columnIndex]);

                // Return the value we set.
                return redoCell;
            }

            // If the stack is empty and we somehow manage to get here then return null as a failsafe.
            return null;
        }

        /// <summary>
        /// Function pops the top value of the redo stack and retuns the value to pass it back into the undoStack.
        /// </summary>
        /// <returns> Returns information to be added to the undoStack after. </returns>
        public UndoRedoCollection FeedBackValueForRedo()
        {
            // Check if the redo stack has something in it.
            if (this.RedoStackCount() >= 1)
            {
                // Pop the value from the redo stack.
                UndoRedoCollection redoCell = this.redos.Pop();

                // Grab the row and column from the popped cell.
                int rowIndex = redoCell.GetRowIndex();
                int columnIndex = redoCell.GetColumnIndex();

                // Set the cell to a duplicate with the message.
                UndoRedoCollection undoCell = new UndoRedoCollection(this.twoDArray[rowIndex, columnIndex].DuplicateCurrentCell(), redoCell.ButtonMessage);

                // Change the value at that location.
                redoCell.FeedBackValue(ref this.twoDArray[rowIndex, columnIndex]);

                // Return the value we set.
                return undoCell;
            }

            // If the stack is empty and we somehow manage to get here then return null as a failsafe.
            return null;
        }

        /// <summary>
        /// This allows us to pass in the Cell's name and still have the same result and it allows us to overload the function.
        /// </summary>
        /// <param name="cellName"> Pass in the cell's location as a name. </param>
        /// <returns> Returns the cell in the overloaded method. </returns>
        public SpreadsheetCell GetCell(string cellName)
        {
            if (this.twoDArray[Convert.ToInt32(cellName.Substring(1)) - 1, cellName[0] - 'A'] == null)
            {
                return null;
            }
            else
            {
                return this.twoDArray[Convert.ToInt32(cellName.Substring(1)) - 1, cellName[0] - 'A'];
            }
        }

        /// <summary>
        /// Function sole purpose is to clear the undo and redo stacks.
        /// </summary>
        public void ClearUndoRedo()
        {
            this.undos.Clear();
            this.redos.Clear();
        }

        /// <summary>
        /// Takes the input file and reads through all the lines to parse out the data and make the cells based on that.
        /// </summary>
        /// <param name="stream"> Take in the file selected. </param>
        public void LoadXMLFileIntoCells(Stream stream)
        {
            // Clear the stacks before any changes are made.
            this.ClearUndoRedo();

            // For each slot, update the cell and add it to the refreshcellvalue event.
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    this.twoDArray[i, j] = new NewCell(i, j);
                    this.twoDArray[i, j].CellText = string.Empty;

                    this.twoDArray[i, j].PropertyChanged += this.RefreshCellValue;
                }
            }

            // Opens the reader and sets defaults.
            XmlTextReader reader = new XmlTextReader(stream);

            string cellName = string.Empty;
            string cellText = string.Empty;
            uint cellColor = 0xFFFFFFFF;

            // Read until the end.
            while (reader.Read())
            {
                // If the element is a cell then read it in and grab the name of the cell.
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "cell")
                {
                    if (reader.HasAttributes)
                    {
                        cellName = reader.GetAttribute("name");
                        Console.WriteLine("Cell name = " + cellName);
                    }
                }

                // If the element is a text then read the text in.
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "text")
                {
                    cellText = reader.ReadElementContentAsString();
                    Console.WriteLine("Cell text = " + cellText);
                }

                // If the element is a color then read the color in.
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "bgcolor")
                {
                    cellColor = Convert.ToUInt32(reader.ReadElementContentAsString(), 16);
                    Console.WriteLine("Cell color = " + cellColor);
                }

                // Once we hit the end of the cell we gather all the data and build the cell based on the information.
                if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "cell")
                {
                    // If the name retreived is empty then don't do anything
                    if (cellName != string.Empty)
                    {
                        // Make the cell with the name
                        SpreadsheetCell newCell = this.MakeCellWithXML(cellName);

                        // Set the text if we found a value for it.
                        if (cellText != string.Empty)
                        {
                            newCell.CellText = cellText;
                        }

                        // Set the color if we found a value for it.
                        if (cellColor != 0xFFFFFFFF)
                        {
                            newCell.BGColor = cellColor;
                        }

                        // Transfer the cell we modified into the our spreadsheet
                        this.CopyAssistant(ref this.twoDArray[newCell.RowIndex, newCell.ColumnIndex], newCell);

                        // Let the system know that we changed the cell.
                        this.CellPropertyChanged(this.twoDArray[newCell.RowIndex, newCell.ColumnIndex], new PropertyChangedEventArgs("Cell"));
                    }

                    // Reset to default for next iteration.
                    cellName = string.Empty;
                    cellText = string.Empty;
                    cellColor = 0xFFFFFFFF;
                }
            }
        }

        /// <summary>
        /// Function takes the information within the spreadsheet and stores it into the file.
        /// </summary>
        /// <param name="stream"> Takes the file that we need to write into. </param>
        public void SaveCellsIntoXMLFile(Stream stream)
        {
            XmlTextWriter writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);

            // Format needed or else it will write it all into one line.
            writer.Formatting = Formatting.Indented;

            // Start writing into the document.
            writer.WriteStartDocument();

            writer.WriteComment("Creating an XML file using C#");

            // Serves as to let us know that we are writing into a spreadsheet.
            writer.WriteStartElement("Spreadsheet");

            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColumnCount; j++)
                {
                    // For each value in the spreadsheet we check if has a change and if so then we write.
                    if (this.twoDArray[i, j].IsFilledIn())
                    {
                        writer.WriteStartElement("cell");
                        writer.WriteAttributeString("name", this.twoDArray[i, j].Name);
                        writer.WriteElementString("text", this.twoDArray[i, j].CellText);
                        writer.WriteElementString("bgcolor", this.twoDArray[i, j].BGColor.ToString("X"));
                        writer.WriteEndElement();
                    }
                }
            }

            // Endings to finish off the file.
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }

        /// <summary>
        /// Function to help copy the information from the newXMLCell to the our current cell.
        /// </summary>
        /// <param name="oldCell"> Reference to the oldCell (The one we have right now). </param>
        /// <param name="newCell"> Information from the cell coming from the XML file. </param>
        private void CopyAssistant(ref SpreadsheetCell oldCell, SpreadsheetCell newCell)
        {
            // Takes the incoming text and color and set it to our current cell which will trigger our events.
            oldCell.CellText = newCell.CellText;
            oldCell.BGColor = newCell.BGColor;
        }

        /// <summary>
        /// Makes a new cell based on the cell needed and returns the cell at that location.
        /// </summary>
        /// <param name="cellName"> Coordinates with the cell we need to work with. </param>
        /// <returns> Returns the cell at the specified location. </returns>
        private SpreadsheetCell MakeCellWithXML(string cellName)
        {
            // Parse out the row and then get the letter based on the first character.
            int rowIndex;
            if (int.TryParse(cellName.Substring(1), out rowIndex))
            {
                int colIndex = (int)cellName[0] - 65;
                NewCell newCell = new NewCell(rowIndex - 1, colIndex);

                return newCell;
            }

            return null;
        }

        /// <summary>
        /// This allows us to grab the values stored in the cells expression tree and either subscribes to that cell again or not.
        /// </summary>
        /// <param name="cell"> Cell that was modified. </param>
        /// <param name="expression"> Expression that is passed in. </param>
        /// <param name="subscribe"> Value to tell if we need to subscribe or unsubscribe. </param>
        private void SubscriptionToCell(SpreadsheetCell cell, string expression, bool subscribe)
        {
            // Setter method gets called which evaluates the tree and restores the variables it found into a list.
            cell.ExpTree.Expression = expression;
            List<string> references = cell.ExpTree.GetVariable();

            // Iterates through the list of variabels found
            foreach (string cellName in references)
            {
                // If we are passed in the prompt to subscribe then we set the variables name to a value for lookup later
                if (subscribe == true)
                {
                    SpreadsheetCell valueNeeded = this.GetCell(cellName);
                    double.TryParse(valueNeeded.CellValue, out double number);
                    cell.ExpTree.SetVariable(cellName, number);
                }

                // Get the cell from looking up its cell name
                SpreadsheetCell referenceCell = this.GetCell(cellName);

                // If it's still null then we don't want to do anything but if not then we want to either subscribe or unsubscribe.
                if (referenceCell != null)
                {
                    if (subscribe == true)
                    {
                        // Subcribe the cell to the cell's property changed event.
                        referenceCell.PropertyChanged += cell.OnPropertyChanged;
                    }
                    else
                    {
                        // Unsubscribe the cell to the cell's property changed event.
                        referenceCell.PropertyChanged -= cell.OnPropertyChanged;
                    }
                }
            }
        }

        /// <summary>
        /// Function recursively calls until we find a match.
        /// </summary>
        /// <param name="referenceCellName"> Name we need to match. </param>
        /// <param name="currentCell"> Needed for the expression tree variable list. </param>
        /// <returns> If we don't get a match then we return false. </returns>
        private bool CircularReferenceHelper(string referenceCellName, SpreadsheetCell currentCell)
        {
            foreach (string cell in currentCell.ExpTree.GetVariable())
            {
                if (this.GetCell(cell).Name == referenceCellName)
                {
                    return true;
                }
                else
                {
                    return this.CircularReferenceHelper(referenceCellName, this.GetCell(cell));
                }
            }

            return false;
        }

        /// <summary>
        /// RefreshCellValue function to be fired when we get the CellText fire.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> PropertyChangedEvents e. </param>
        private void RefreshCellValue(object sender, PropertyChangedEventArgs e)
        {
            // If we get the fire of CellText then we go into this statement.
            if (e.PropertyName == "CellText")
            {
                // Convert the sender to a cell and pass it into the overloaded function.
                this.RefreshCellValue((SpreadsheetCell)sender);
            }

            // If we get the fire of Color then we go into this statement.
            else if (e.PropertyName == "Color")
            {
                // Call the Cell Color Changed Property Changed event.
                this.CellPropertyChanged((SpreadsheetCell)sender, new PropertyChangedEventArgs("CellColorChanged"));
            }
        }

        /// <summary>
        /// Overloaded method that handles when a cell should either subscribe or unsubscribe.
        /// </summary>
        /// <param name="currentCell"> Takes in teh cell that changed. </param>
        private void RefreshCellValue(SpreadsheetCell currentCell)
        {
            // Check if the value is an expression since it starts with =
            if (currentCell != null && currentCell.CellText.StartsWith("="))
            {
                // Get the coordinates of the cell
                int row = currentCell.RowIndex;
                int column = currentCell.ColumnIndex;

                bool noNeed = false;

                // Sets the string
                currentCell.ExpTree.Expression = currentCell.CellText.Substring(1);

                List<string> variablesInExpression = currentCell.ExpTree.GetVariable();

                foreach (string cell in variablesInExpression)
                {
                    double.TryParse(cell.Substring(1), out double number);
                    if (char.IsLetter(cell[1]) || number > 50)
                    {
                        // Sets the value to "!(Bad Reference)"
                        currentCell.CellValue = "!(Bad Reference)";

                        // Set the display to show the "!(Bad Reference)" message
                        this.twoDArray[row, column].CellValue = currentCell.CellValue;

                        noNeed = true;
                    }
                }

                if (!noNeed)
                {
                    if (variablesInExpression.Contains(currentCell.Name))
                    {
                        // Sets the value to "!(Self Reference)"
                        currentCell.CellValue = "!(Self Reference)";

                        // Set the display to show the "!(Self Reference)" message
                        this.twoDArray[row, column].CellValue = currentCell.CellValue;

                        // for (int i = 0; i < variablesInExpression.Count; i++)
                        // {
                        //    Console.WriteLine(variablesInExpression[i]);
                        // }
                    }
                    else if (this.CircularReferenceHelper(currentCell.Name, currentCell))
                    {
                        // Sets the value to "!(Self Reference)"
                        currentCell.CellValue = "!(Circular Reference)";

                        // Set the display to show the "!(Self Reference)" message
                        this.twoDArray[row, column].CellValue = currentCell.CellValue;
                    }
                    else
                    {
                        // Check if the cell has been modfied before.
                        if (currentCell.ExpTree.Expression != string.Empty)
                        {
                            // If it's been modified before then we know that it should be unsubscribed.
                            this.SubscriptionToCell(currentCell, currentCell.ExpTree.Expression, false);
                        }

                        // Go through and subscribe the values in the new expression.
                        this.SubscriptionToCell(currentCell, currentCell.ExpTree.Expression = currentCell.CellText.Substring(1), true);

                        // Set the value to the value from the expression tree.
                        currentCell.CellValue = this.twoDArray[row, column].CellValue = currentCell.ExpTree.Evaluate().ToString();

                        // for (int i = 0; i < variablesInExpression.Count; i++)
                        // {
                        //    Console.WriteLine(variablesInExpression[i]);
                        // }
                    }
                }
            }
            else
            {
                // This case handles when the cell is set to a number.
                currentCell.CellValue = currentCell.CellText;
                double.TryParse(currentCell.CellValue, out double number);
                currentCell.ExpTree.SetVariable(currentCell.Name, number);
            }

            // Fire the CellRefresh call so that it can be changed in the form class.
            this.CellPropertyChanged(currentCell, new PropertyChangedEventArgs("CellRefresh"));
        }
    }

    /// <summary>
    /// Class that handles out expression tree construction.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// Dictionary that holds all the values for the variables.
        /// </summary>
        private static Dictionary<string, double> userVariables = new Dictionary<string, double>();

        /// <summary>
        /// Root of the expression tree.
        /// </summary>
        private BaseNode rootNode;

        /// <summary>
        /// Stack that maintains the postFixExpression after being converted.
        /// </summary>
        private Stack<BaseNode> postFixExpression = new Stack<BaseNode>();

        /// <summary>
        /// Stack that actively maintains the operator while being converted.
        /// </summary>
        private Stack<BaseNode> operatorStack = new Stack<BaseNode>();

        /// <summary>
        /// List that holds all the variables that were encountered while traversing the expression.
        /// </summary>
        private List<string> variablesInExpression;

        /// <summary>
        /// Keep a local copy of the expression.
        /// </summary>
        private string expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> Used to construct the tree from what ever expression is fed in. </param>
        public ExpressionTree(string expression)
        {
            this.variablesInExpression = new List<string>();

            // When initialized compile with a empty string.
            this.Compile(expression);

            // Set that string to empty incase we need it for later.
            this.expression = expression;
        }

        /// <summary>
        /// Gets or sets, this holds the value of the expression.
        /// </summary>
        public string Expression
        {
            // Returns the expression when needed.
            get
            {
                return this.expression;
            }

            // Compile with the new expression being set to the expression and compile the tree such that we
            // re-evaluate the tree and also grab the values in the expression at the same time.
            set
            {
                this.Compile(value);

                while (this.operatorStack.Count > 0)
                {
                    this.postFixExpression.Push(this.operatorStack.Pop());
                }

                this.rootNode = this.CompileTreeHelper();

                // Again, set the local expression to the value being set to it.
                this.expression = value;
            }
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName"> Used to assign the variable name. </param>
        /// <param name="variableValue"> Used to assign the variable value. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            userVariables[variableName] = variableValue;
        }

        /// <summary>
        /// Utilized in the spreadsheet class.
        /// </summary>
        /// <returns> Returns the list of keys. </returns>
        public List<string> GetVariable()
        {
            return this.variablesInExpression;
        }

        /// <summary>
        /// Used to calculate the phrase fed in.
        /// </summary>
        /// <returns> Returns a double value of the evaluated total. </returns>
        public double Evaluate()
        {
            // This means that the expression was empty.
            if (this.rootNode == null)
            {
                return 0.0;
            }
            else
            {
                // If its not empty then we can evaluate.
                return this.Evaluate(this.rootNode);
            }
        }

        /// <summary>
        /// Checks whether or not we need to compile the tree if the string we passed in is legitimate.
        /// </summary>
        /// <returns> Returns the root node of the tree after building. </returns>
        private BaseNode CompileTreeHelper()
        {
            if (string.IsNullOrEmpty(this.Expression))
            {
                return null;
            }

            // Set the new node as the root and return it.
            BaseNode newNode = this.CompileTree();

            return newNode;
        }

        /// <summary>
        /// This iterates from a stack and builds iteratively to save from stack overflow.
        /// </summary>
        /// <returns> Returns the root node if the tree. </returns>
        private BaseNode CompileTree()
        {
            // Takes our postfix stack and reverses it to better work on it.
            Stack<BaseNode> reversedStack = new Stack<BaseNode>();

            // Iterate through the whole postfix expression stack and pop it onto our reversed stack.
            while (this.postFixExpression.Count > 0)
            {
                reversedStack.Push(this.postFixExpression.Pop());
            }

            // Serves as our stack to represent the tree
            Stack<BaseNode> builtTreeStack = new Stack<BaseNode>();

            // Node that is created for the purpose of comparing.
            BaseNode tempNode;

            // Iterate until the reversed stack is empty.
            while (reversedStack.Count > 0)
            {
                // Set the tempNode to the node at the top of the reversed stack
                tempNode = reversedStack.Pop();

                // Do a check to see if it is a constant.
                if (tempNode is ConstantNumNode newConstantNumNode)
                {
                    builtTreeStack.Push(newConstantNumNode);
                }

                // Do a check to see if it is a variable.
                if (tempNode is VariableNode newVariableNode)
                {
                    builtTreeStack.Push(newVariableNode);
                }

                // Do a check to see if it is a binary operator.
                if (tempNode is BinaryOperatorNode newBinaryOperatorNode)
                {
                    if (newBinaryOperatorNode != null)
                    {
                        newBinaryOperatorNode.RightNode = builtTreeStack.Pop();
                        newBinaryOperatorNode.LeftNode = builtTreeStack.Pop();

                        builtTreeStack.Push(newBinaryOperatorNode);
                    }
                }
            }

            // Return the root since it will be on the top.
            return builtTreeStack.Pop();
        }

        /// <summary>
        /// This constructs the expression tree with the expression being fed in.
        /// </summary>
        /// <param name="userExpression"> This is the expression taken from the user. </param>
        private void Compile(string userExpression)
        {
            string substring = string.Empty;
            int indexOfOperatorLocation = 0;
            double number = 0.0;
            this.variablesInExpression = new List<string>();

            // If there is no expression being fed in the return 0
            if (userExpression.Length == 0)
            {
                return;
            }
            else
            {
                if (userExpression[0] == '+' || userExpression[0] == '-' || userExpression[0] == '*' || userExpression[0] == '/')
                {
                    throw new InvalidOperationException("You may not start an expression with an operator.");
                }

                // Loop from the front to the back checking if the we can find a operator
                for (int index = 0; index < userExpression.Length; index++)
                {
                    // Set the index of the operator equal to the current parsing index value
                    indexOfOperatorLocation = index;

                    // We check to see that the operator index is within the bounds the user expression and also checking until we hit an expression
                    while (indexOfOperatorLocation < userExpression.Length && !CreateFactoryOperator.IsValidOperator(userExpression[indexOfOperatorLocation]))
                    {
                        indexOfOperatorLocation++;
                    }

                    // If the expression is found but not at the parsing index value then we do this action.
                    if (indexOfOperatorLocation != index)
                    {
                        // Set the offset
                        int offset = indexOfOperatorLocation - index;

                        // Set the substring to the part before the operator and do the next actions
                        substring = userExpression.Substring(index, offset);

                        // If the offset it more than one then we set the index to that and decrement by one so we can find that operator the next time we iterate
                        if (offset > 1)
                        {
                            index += offset;
                            index--;
                        }
                    }
                    else
                    {
                        // If parser index is equal to the operator index then we set the operator to a string
                        substring = userExpression[index].ToString();
                    }

                    if (CreateFactoryOperator.IsValidOperator(substring[0]))
                    {
                        // Use the factory method to create a operator node based on the operator
                        BinaryOperatorNode operatorNode = CreateFactoryOperator.CreateOperator(substring[0]);

                        // Step 2 of Shunting Yard Algorithm. If the incoming symbol is a left parenthesis, push it on the stack.
                        if (operatorNode.BinaryOperator == '(')
                        {
                            this.operatorStack.Push(operatorNode);
                        }

                        // Step 3 of Shunting Yard Algorithm. If the incoming symbol is a right parenthesis: discard the right parenthesis, pop and print the stack symbols until you see a left parenthesis. Pop the left parenthesis and discard it.
                        else if (operatorNode.BinaryOperator == ')')
                        {
                            // We need to check the values on the stack until we find a left parentheses.
                            // This means that since we push on a operater node, we need to get the value stored in that Binary Opertor and check against to see that it is not a left parentheses.
                            // Once we confirm that we aren't hitting a left parentheses, we push that operator node onto our post fix expression stack
                            while ((char)this.operatorStack.Peek().GetType().GetProperty("BinaryOperator").GetValue(this.operatorStack.Peek()) != '(')
                            {
                                this.postFixExpression.Push(this.operatorStack.Pop());
                            }

                            // Once we are done, we need to discard the left parentheses stored on the stack still.
                            this.operatorStack.Pop();
                        }

                        // Step 4 of Shunting Yard Algorithm. If the incoming symbol is an operator and the stack is empty or contains a left parenthesis on top, push the incoming operator onto the stack.
                        // This checks to see if the top of the operator stacks node contains the open parentheses.
                        // We check that nodes value to see if the nodes of type that is on the top of the stack is equal to a open parentheses
                        else if (this.operatorStack.Count == 0 || (char)this.operatorStack.Peek().GetType().GetProperty("BinaryOperator").GetValue(this.operatorStack.Peek()) == '(')
                        {
                            // Since we know that the operator in question isn't a open parenthesis, we can push it onto the stack of operators.
                            this.operatorStack.Push(operatorNode);
                        }

                        // Step 5 of Shunting Yard Algorithm. If the incoming symbol is an operator and has either higher precedence than the operator on the top of the stack, or has the same precedence as the operator on the top of the stack and is right associative -- push it on the stack.
                        // This checks if the prcedence of the value we have right now is greater than the prcedence of the node a the top of the operator stack.
                        else if ((int)this.operatorStack.Peek().GetType().GetProperty("Precedence").GetValue(this.operatorStack.Peek()) < CreateFactoryOperator.GetOperatorPrecedence(operatorNode.BinaryOperator))
                        {
                            this.operatorStack.Push(operatorNode);
                        }

                        // Step 6 of Shunting Yard Algorithm. If the incoming symbol is an operator and has either lower precedence than the operator on the top of the stack, or has the same precedence as the operator on the top of the stack and is left associative -- continue to pop the stack until this is not true. Then, push the incoming operator.
                        // This checks is the precedence of the value we have right now is less than the precedence of the node at the top of the operator stack
                        else if ((int)this.operatorStack.Peek().GetType().GetProperty("Precedence").GetValue(this.operatorStack.Peek()) >= CreateFactoryOperator.GetOperatorPrecedence(operatorNode.BinaryOperator))
                        {
                            // We do this while our operator stack still has operators inside, and the top isn't a ( and than our precedence is greater than top.
                            while (this.operatorStack.Count > 0 && ((BinaryOperatorNode)this.operatorStack.Peek()).BinaryOperator != '(' && ((BinaryOperatorNode)this.operatorStack.Peek()).Precedence >= operatorNode.Precedence)
                            {
                                // Pop the operator into the postfix expression stack
                                this.postFixExpression.Push(this.operatorStack.Pop());
                            }

                            // Push the operator onto the stack.
                            this.operatorStack.Push(operatorNode);
                        }
                    }
                    else if (double.TryParse(substring, out number))
                    {
                        // We try to parse the expression and check if its a number
                        ConstantNumNode temp = new ConstantNumNode(number);

                        this.postFixExpression.Push(temp);
                    }
                    else
                    {
                        // If its not a number then we know its a variable and we declare that number as 0 by default.
                        if (!userVariables.ContainsKey(substring))
                        {
                            userVariables[substring] = 0.0;
                        }

                        VariableNode temp = new VariableNode(substring);

                        // Push the variables into the list so we know that a variables was found here.
                        this.variablesInExpression.Add(substring);
                        this.postFixExpression.Push(temp);
                    }
                }
            }
        }

        /// <summary>
        /// Overloaded Evaluate function that does the operation with the node being fed in.
        /// </summary>
        /// <param name="evalTree"> Takes in the node being fed in. </param>
        /// <returns> Returns the value of the evaluated total. </returns>
        private double Evaluate(BaseNode evalTree)
        {
            // If the expression is empty then we return 0.
            if (evalTree == null)
            {
                return 0.0;
            }
            else
            {
                // Method for explicitly casting the evalTree as other nodes found from youtube tutorial
                // https://www.youtube.com/watch?v=jRkmPRk5j2E
                // If its an Binary Operator Node then we do the evaluation function from the respective operator node
                if (evalTree is BinaryOperatorNode)
                {
                    BinaryOperatorNode tempInstance = (BinaryOperatorNode)evalTree;

                    return tempInstance.Evaluate(this.Evaluate(tempInstance.LeftNode), this.Evaluate(tempInstance.RightNode));
                }
                else if (evalTree is VariableNode)
                {
                    // If its a variable node then we do a look up in the dictionary and return the value in that location or 0 if it was never changed.
                    VariableNode tempInstance = (VariableNode)evalTree;
                    return userVariables[tempInstance.VariableName];
                }
                else if (evalTree is ConstantNumNode)
                {
                    // If its a constant node then we return the value stored in that constant node.
                    ConstantNumNode tempInstance = (ConstantNumNode)evalTree;
                    return tempInstance.ConstantValue;
                }

                return 0.0;
            }
        }
    }
}