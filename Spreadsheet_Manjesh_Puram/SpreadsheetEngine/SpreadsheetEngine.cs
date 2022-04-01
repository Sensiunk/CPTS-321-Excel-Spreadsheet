﻿// <copyright file="SpreadsheetEngine.cs" company="Manjesh Reddy Puram 11716685">
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
    /// Abstract class of the Spreadsheet cell.
    /// </summary>
    public abstract class SpreadsheetCell : INotifyPropertyChanged
    {
        /// <summary>
        /// Stores the user variables that end up getting passed into the cell.
        /// </summary>
        public Dictionary<string, double> userVariableNames;

        /// <summary>
        /// Creating an instance of a tree in each cell.
        /// </summary>
        private ExpressionTree expressionTree;

        /// <summary>
        /// Creating a dictionary that contains the locations of the cells such that when we need to find the cell
        /// it becomes much easier and simplifies things.
        /// </summary>
        private Dictionary<int, string> cellLocation;

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
        /// Initializes a new instance of the <see cref="SpreadsheetCell"/> class.
        /// </summary>
        /// <param name="newRowIndex"> Uses the value passed in to set the value of the rowIndex. </param>
        /// <param name="newColumnIndex"> Uses the value passed in to set the value of the columnIndex. </param>
        public SpreadsheetCell(int newRowIndex, int newColumnIndex)
        {
            this.cellLocation = new Dictionary<int, string>();
            this.userVariableNames = new Dictionary<string, double>();
            this.rowIndex = newRowIndex;
            this.columnIndex = newColumnIndex;
            this.cellText = string.Empty;
            this.cellValue = string.Empty;

            int j = 0;
            for (int i = 65; i < 91; i++)
            {
                this.cellLocation[j] = ((char)i).ToString();
                ++j;
            }
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

            set
            {
                if (this.cellValue == value)
                {
                    return;
                }
                else
                {
                    this.cellValue = value;

                    this.PropertyChanged(this, new PropertyChangedEventArgs("CellValue"));
                }
            }
        }

        /// <summary>
        /// Gets, storing the locations within the dictionary and returning the name of the location when we need it.
        /// </summary>
        public string IndexLocationName
        {
            get
            {
                // Returns the location of the cell in terms of Letter first then the row number.
                return this.cellLocation[this.columnIndex].ToString() + (this.rowIndex + 1).ToString();
            }
        }

        /// <summary>
        /// Serves to subscribe the expression tree to the cell such that it can be changed using events.
        /// </summary>
        /// <param name="cell"> Takes in the cell as the parameter. </param>
        public void SubscribeExpressionTreeToIndividualCell(SpreadsheetCell cell)
        {
            this.expressionTree.CellSubscriber(cell);
        }

        /// <summary>
        /// Creates a new tree for the cell to work with.
        /// </summary>
        /// <param name="expressionString"> Takes in the string that is passed in. </param>
        public void NewExpressionTreeInstance(string expressionString)
        {
            this.expressionTree = new ExpressionTree(expressionString);
            this.userVariableNames = this.expressionTree.UserVariables;
            this.expressionTree.parentCell = this;
        }

        /// <summary>
        /// This function gets called when we need to evaluate the expression entered into the cell.
        /// </summary>
        /// <returns> Returns of the evaluated expression. </returns>
        public string EvaluateExpression()
        {
            return this.expressionTree.Evaluate().ToString();
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
        /// <summary>
        /// Dictionary that holds the locations of the cells.
        /// </summary>
        private Dictionary<string, int> cellLocation;

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
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="newRow"> Construct with a row input. </param>
        /// <param name="newColumn"> Construct with a column input. </param>
        public Spreadsheet(int newRow, int newColumn)
        {
            this.cellLocation = new Dictionary<string, int>();
            this.spreadsheetRow = newRow;
            this.spreadsheetColumn = newColumn;

            this.twoDArray = new NewCell[newRow, newColumn];

            for (int i = 0; i < newRow; i++)
            {
                for (int j = 0; j < newColumn; j++)
                {
                    this.twoDArray[i, j] = new NewCell(i, j);

                    // We are told not to initialize to empty string.
                    // this.twoDArray[i, j].CellText = string.Empty;
                    this.twoDArray[i, j].PropertyChanged += this.RefreshCellValue;
                }
            }

            int z = 0;
            for (int i = 65; i < 91; i++)
            {
                this.cellLocation[((char)i).ToString()] = z;
                z++;
            }
        }

        /// <summary>
        /// Event to fire when we have property change in the cell
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged = (sender, e) => { };

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
        /// Function implemented to return the cell at a location when fed in coordinates of where we want.
        /// </summary>
        /// <param name="coordinates"> We take in a coordinate and using that we are able to grab a Cell. </param>
        /// <returns> Returns a value that gives us the cell at a certain location. </returns>
        public SpreadsheetCell GetCellWithCoordinates(string coordinates)
        {
            int columnGrab = this.cellLocation[coordinates[0].ToString()];
            int rowGrab = Convert.ToInt16(coordinates.Substring(1)) - 1;
            return this.GetCell(rowGrab, columnGrab);
        }

        /// <summary>
        /// This function extracts the text from a cell.
        /// </summary>
        /// <param name="cellName"> We are passed in the name of the cell. </param>
        /// <returns> We return the text stored in a cells. </returns>
        public string GetText(string cellName)
        {
            return this.GetCell(Convert.ToInt32(cellName[2].ToString()) - 1, this.cellLocation[cellName[1].ToString()]).CellText;
        }

        /// <summary>
        /// RefreshCellValue function to be fired when we get the CellText fire.
        /// </summary>
        /// <param name="sender"> Object sender. </param>
        /// <param name="e"> PropertyChangedEvents e. </param>
        private void RefreshCellValue(object sender, EventArgs e)
        {
            NewCell cell = sender as NewCell;

            PropertyChangedEventArgs eve = e as PropertyChangedEventArgs;

            // If we get the fire of CellValue then we go into this statement.
            if (eve.PropertyName == "CellValue")
            {
                this.CellPropertyChanged(this, new PropertyChangedEventArgs(cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString() + "," + cell.CellValue));
            }

            // If the starting of the input is equal to = then we go into this.
            if (cell.CellText[0] == '=')
            {
                /*string equalsSign = ((SpreadsheetCell)sender).CellText.Substring(0);
                int columnGrab = Convert.ToInt16(equalsSign[1]) - 'A';
                int rowGrab = Convert.ToInt16(equalsSign.Substring(2)) - 1;
                ((SpreadsheetCell)sender).CellValue = this.GetCell(rowGrab, columnGrab).CellValue;*/
                cell.NewExpressionTreeInstance(cell.CellText.Substring(1));
                foreach (KeyValuePair<string, double> cellLocationIndexName in cell.userVariableNames.ToList())
                {
                    cell.SubscribeExpressionTreeToIndividualCell(this.GetCellWithCoordinates(cellLocationIndexName.Key));
                }

                cell.CellValue = cell.EvaluateExpression();
                this.CellPropertyChanged(cell, new PropertyChangedEventArgs("CellText"));
            }
            else
            {
                cell.CellValue = cell.CellText;
                this.CellPropertyChanged(this, new PropertyChangedEventArgs(cell.RowIndex.ToString() + "," + cell.ColumnIndex.ToString() + "," + cell.CellValue));
            }
        }
    }

    /// <summary>
    /// Class that handles out expression tree construction.
    /// </summary>
    public class ExpressionTree
    {
        /// <summary>
        /// This tree will be stored in this cell.
        /// </summary>
        public SpreadsheetCell parentCell;

        /// <summary>
        /// Dictionary that holds all the values for the variables.
        /// </summary>
        private Dictionary<string, double> userVariables;

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
        /// Initializes a new instance of the <see cref="ExpressionTree"/> class.
        /// </summary>
        /// <param name="expression"> Used to construct the tree from what ever expression is fed in. </param>
        public ExpressionTree(string expression)
        {
            if (expression.Length == 0)
            {
                return;
            }

            this.userVariables = new Dictionary<string, double>();

            this.Compile(expression);

            while (this.operatorStack.Count > 0)
            {
                this.postFixExpression.Push(this.operatorStack.Pop());
            }

            this.rootNode = this.postFixExpression.Pop();

            this.rootNode = this.CompileTree(this.rootNode);

            this.Expression = expression;
        }

        /// <summary>
        /// Gets or sets, this holds the value of the expression.
        /// </summary>
        public string Expression { get; set; }

        /// <summary>
        /// Gets, returns the dictionary that holds our variables.
        /// </summary>
        public Dictionary<string, double> UserVariables
        {
            get
            {
                return this.userVariables;
            }
        }

        /// <summary>
        /// Sets the specified variable within the ExpressionTree variables dictionary.
        /// </summary>
        /// <param name="variableName"> Used to assign the variable name. </param>
        /// <param name="variableValue"> Used to assign the variable value. </param>
        public void SetVariable(string variableName, double variableValue)
        {
            this.userVariables[variableName] = variableValue;
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
        /// Function that subscribes the cell to the cell change occured event handler.
        /// </summary>
        /// <param name="cell"> Pass in the cell we want to subscribe. </param>
        public void CellSubscriber(SpreadsheetCell cell)
        {
            cell.PropertyChanged += this.CellChangeOccured;
        }

        private void CellChangeOccured(object sender, EventArgs e)
        {
            if (sender.GetType() == typeof(NewCell))
            {
                NewCell cell = sender as NewCell;

                // if (this.userVariables.ContainsKey(cell.In))
            }
        }

        /// <summary>
        /// This recursively calls the compile tree function that builds from the stack.
        /// </summary>
        /// <param name="currentNode"> The current node from the stack that is passed in. </param>
        /// <returns> Returns the node for the tree. </returns>
        private BaseNode CompileTree(BaseNode currentNode)
        {
            if (currentNode is BinaryOperatorNode)
            {
                BinaryOperatorNode tempNode = (BinaryOperatorNode)currentNode;
                tempNode.LeftNode = this.CompileTree(this.postFixExpression.Pop());
                tempNode.RightNode = this.CompileTree(this.postFixExpression.Pop());
            }

            return currentNode;
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
                        this.userVariables[substring] = 0.0;
                        VariableNode temp = new VariableNode(substring);

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
                    return this.userVariables[tempInstance.VariableName];
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