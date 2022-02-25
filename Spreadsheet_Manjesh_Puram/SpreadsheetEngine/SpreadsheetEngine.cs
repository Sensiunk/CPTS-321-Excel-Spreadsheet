namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Abstract class of the Spreadsheetcell.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        protected readonly int rowIndex;
        protected readonly int columnIndex;
        protected string cellText;
        protected string cellValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        //public SpreadsheetCell()
        //{
        //}

        /// <summary>
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="newRowIndex"> Uses the value passed in to set the value of the rowIndex. </param>
        /// <param name="newColumnIndex"> Uses the value passed in to set the value of the columnIndex. </param>
        public SpreadsheetCell(int newRowIndex, int newColumnIndex)
        {
            this.rowIndex = newRowIndex;
            this.columnIndex = newColumnIndex;
        }

        /// <summary>
        /// This is the property changed manager.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Gets the rowIndex number.
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Gets the columnIndex number.
        /// </summary>
        public int ColumnIndex
        {
            get { return this.columnIndex; }
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
                if (this.cellText == value)
                {
                    return;
                }

                this.cellText = value;

                this.OnPropertyChanged("CellText");
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
                if (this.cellValue == value)
                {
                    return;
                }

                this.cellValue = value;

                this.OnPropertyChanged("CellValue");
            }
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }

    /// <summary>
    /// Public class of the Spreadsheet.
    /// </summary>
    public class Spreadsheet
    {
        public event PropertyChangedEventHandler CellPropertyChanged = (sender, e) => { };
        private int spreadsheetColumn;
        private int spreadsheetRow;
        private SpreadsheetCell[,] twoDArray;

        public sealed class NewCell : SpreadsheetCell
        {
            public NewCell(int newRow, int newColumn) : base(newRow, newColumn)
            {

            }
        }
        public Spreadsheet (int newRow, int newColumn)
        {
            this.spreadsheetRow = newRow;
            this.spreadsheetColumn = newColumn;

            this.twoDArray = new SpreadsheetCell[newRow, newColumn];

            for (int i = 0; i < newRow; i++)
            {
                for (int j = 0; i < newColumn; j++)
                {
                    SpreadsheetCell currentCell = new NewCell(i, j);

                    currentCell.PropertyChanged += RefreshCellValue;

                    twoDArray[i, j] = currentCell;
                }
            }
        }

        public SpreadsheetCell GetCell(int inputRow, int inputColumn)
        {
            if (inputRow > twoDArray.GetLength(0) || inputColumn > twoDArray.GetLength(1))
            {
                return null;
            }
            else
            {
                return twoDArray[inputRow, inputColumn];
            }
        }

        public int ColumnCount
        {
            get { return this.ColumnCount; }
        }

        public int RowCount
        {
            get { return this.RowCount; }
        }

        private void RefreshCellValue(object sender, PropertyChangedEventArgs e)
        {
            if ("Text" == e.PropertyName)
            {
                SpreadsheetCell updateCell = (SpreadsheetCell)sender;
                
                if(updateCell.CellText[0] == '=')
                {

                }
            }
        }
    }
}
