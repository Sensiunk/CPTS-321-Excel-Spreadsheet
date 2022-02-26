// <copyright file="Class1.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Abstract class of the Spreadsheetcell.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        protected int rowIndex; // Index of the row
        protected int columnIndex; // Index of the column
        protected string cellText; // Text in the cell
        protected string cellValue; // Value in the cell

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
                else
                {
                    this.cellText = value;

                    this.OnPropertyChanged("CellText");
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
                if (this.cellValue == value)
                {
                    return;
                }
                else
                {
                    this.cellValue = value;

                    this.OnPropertyChanged("CellValue");
                }
            }
        }

        /// <summary>
        /// This is needed in order to invoke the property change.
        /// </summary>
        /// <param name="name"> Takes the name of the things being changed and broadcasts it. </param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
}