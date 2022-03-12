// <copyright file="CreateFactoryOperator.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace CptS321
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Factory Method for making new Nodes pertaining to certain operators.
    /// </summary>
    internal class CreateFactoryOperator
    {
        /// <summary>
        /// Creates the correct operator node based on the input char value.
        /// </summary>
        /// <param name="operatorValue"> Can be either a plus, minus, multiply, or divide. </param>
        /// <returns> Returns the correct node. </returns>
        public static BinaryOperatorNode CreateOperator(char operatorValue)
        {
            switch (operatorValue)
            {
                case '+':
                    return new PlusOperatorNode();
                case '-':
                    return new MinusOperatorNode();
                case '*':
                    return new MultiplyOperatorNode();
                case '/':
                    return new DivisionOperatorNode();
                case '(':
                    return new OpenParenthesesNode();
                case ')':
                    return new ClosingParenthesesNode();
            }

            throw new Exception("Operator not supported");
        }

        /// <summary>
        /// Function to streamline checking if a operator in the input expression is a valid operator.
        /// </summary>
        /// <param name="operatorValue"> Takes in the operator in question. </param>
        /// <returns> Returns true if in the case that the operator is actually a valid operator. </returns>
        public static bool IsValidOperator(char operatorValue)
        {
            switch (operatorValue)
            {
                case '+':
                    return true;
                case '-':
                    return true;
                case '*':
                    return true;
                case '/':
                    return true;
                case '(':
                    return true;
                case ')':
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Function to streamline checking what precedence the operator has.
        /// </summary>
        /// <param name="operatorValue"> Takes in the operator in question. </param>
        /// <returns> Returns the value of the precedence of the operator. </returns>
        public static int GetOperatorPrecedence(char operatorValue)
        {
            switch (operatorValue)
            {
                case '+':
                    return 5;
                case '-':
                    return 5;
                case '*':
                    return 6;
                case '/':
                    return 6;
                case '(':
                    return 7;
                case ')':
                    return 7;
            }

            return 0;
        }
    }
}