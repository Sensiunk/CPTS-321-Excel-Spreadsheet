// <copyright file="SpreadsheetEngine.cs" company="Manjesh Reddy Puram 11716685">
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

    /// <summary>
    /// Public class of the Spreadsheet.
    /// </summary>
    public class Spreadsheet
    {
        private int spreadsheetColumn;
        private int spreadsheetRow;
        private SpreadsheetCell[,] twoDArray;

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
        /// GetCell function that returns a SpreadsheetCell so it can retreive the values from that cell.
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
        /// RefreshCellValue function to be fired when we get the CellText fire.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> PropertyChangedEvents. </param>
        private void RefreshCellValue(object sender, PropertyChangedEventArgs e)
        {
            // If we get the fire of CellText then we go into this statement.
            if (e.PropertyName == "CellText")
            {
                // If the starting of the input is equal to = then we go into this.
                if (((SpreadsheetCell)sender).CellText[0] == '=')
                {
                    string equalsSign = ((SpreadsheetCell)sender).CellText.Substring(0);
                    int columnGrab = Convert.ToInt16(equalsSign[1]) - 'A';
                    int rowGrab = Convert.ToInt16(equalsSign.Substring(2)) - 1;
                    ((SpreadsheetCell)sender).CellValue = this.GetCell(rowGrab, columnGrab).CellValue;
                }
                else
                {
                    ((SpreadsheetCell)sender).CellValue = ((SpreadsheetCell)sender).CellText;
                }
            }

            // Fire the CellRefresh call so that it can be changed in the form class.
            this.CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("CellRefresh"));
        }
    }

    /// <summary>
    /// Class that handles out expression tree construction.
    /// </summary>
    public class ExpressionTree
    {
        private static Dictionary<string, double> userVariables;
        private BaseNode rootNode;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> Used to construct the tree from what ever expression is fed in. </param>
        public ExpressionTree(string expression)
        {
            userVariables = new Dictionary<string, double>();

            this.rootNode = this.Compile(expression);
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

        private BaseNode Compile(string userExpression)
        {
            if (userExpression.Length == 0)
            {
                return null;
            }
            else
            {
                for (int index = userExpression.Length - 1; index >= 0; index--)
                {
                    switch (userExpression[index])
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            return new BinaryOperatorNode(userExpression[index], this.Compile(userExpression.Substring(0, index)), this.Compile(userExpression.Substring(index + 1)));
                    }
                }

                double number;
                if (double.TryParse(userExpression, out number))
                {
                    return new ConstantNumNode(number);
                }
                else
                {
                    return new VariableNode(userExpression);
                }
            }
        }

        /// <summary>
        /// Used to calculate the phrase fed in.
        /// </summary>
        /// <returns> Returns a double value of the evaluated total. </returns>
        public double Evaluate()
        {
            if (this.rootNode == null)
            {
                return 0.0;
            }
            else
            {
                return this.Evaluate(this.rootNode);
            }
        }

        private double Evaluate(BaseNode evalTree)
        {
            if (evalTree == null)
            {
                return 0.0;
            }
            else
            {
                // Method for explicitly casting the evalTree as other nodes found from youtube tutorial
                // https://www.youtube.com/watch?v=jRkmPRk5j2E
                if (evalTree is BinaryOperatorNode)
                {
                    BinaryOperatorNode tempInstance = (BinaryOperatorNode)evalTree;

                    return tempInstance.Evaluate(tempInstance.BinaryOperator, this.Evaluate(tempInstance.LeftNode), this.Evaluate(tempInstance.RightNode));
                }
                else if (evalTree is VariableNode)
                {
                    VariableNode tempInstance = (VariableNode)evalTree;
                    return userVariables[tempInstance.VariableName];
                }
                else if (evalTree is ConstantNumNode)
                {
                    ConstantNumNode tempInstance = (ConstantNumNode)evalTree;
                    return tempInstance.ConstantValue;
                }

                return 0.0;
            }
        }
    }
}