// <copyright file="BinaryOperatorNode.cs" company="Manjesh Reddy Puram 11716685">
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
    /// This serves as the node that gets created in the case that we a see a operator in the expression given by the user.
    /// </summary>
    internal class BinaryOperatorNode : BaseNode
    {
        private char binaryOperator; // This holds the value of our binary operator.
        private BaseNode leftNode; // This holds the Node of our left node.
        private BaseNode rightNode; // This holds the Node of our right node.

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryOperatorNode"/> class.
        /// </summary>
        /// <param name="newBinaryOperator"> Takes in a value for our binary operator name when we get a new instance created. </param>
        /// <param name="newLeftNode"> Takes in a Node for our left node when we get a new instance created. </param>
        /// <param name="newRightNode"> Takes in a Node for our right node when we get a new instance created. </param>
        public BinaryOperatorNode (char newBinaryOperator, BaseNode newLeftNode, BaseNode newRightNode)
        {
            this.binaryOperator = newBinaryOperator; // Set the value of the binaryOperator to the value being passed in during instantiation.
            this.leftNode = newLeftNode; // Set the value of the leftNode to the Node being passed in during instantiation.
            this.rightNode = newRightNode; // Set the value of the rightNode to the Node being passed in during instantiation.
        }

        /// <summary>
        /// Gets or sets, this serves as the get and set controller for our binaryOperator.
        /// </summary>
        public char BinaryOperator
        {
            get { return this.binaryOperator; }
            set { this.binaryOperator = value; }
        }

        /// <summary>
        /// Gets or sets, this serves as the get and set controller for our leftNode.
        /// </summary>
        public BaseNode LeftNode
        {
            get { return this.leftNode; }
            set { this.leftNode = value; }
        }

        /// <summary>
        /// Gets or sets, this serves as the get and set controller for our rightNode.
        /// </summary>
        public BaseNode RightNode
        {
            get { return this.rightNode; }
            set { this.rightNode = value; }
        }

        /// <summary>
        /// This function serves the purpose to return the value we receive when we do the evaluation for the calculations.
        /// </summary>
        /// <param name="binOperator"> Takes in a binOperator which is used to check what operation needs to be done. </param>
        /// <param name="leftVal"> Takes in the double from the left side. </param>
        /// <param name="rightVal"> Takes in the double from the right side. </param>
        /// <returns> Returns the operated value of the left side and right side. </returns>
        public double Evaluate (char binOperator, double leftVal, double rightVal)
        {
            switch (binOperator)
            {
                case '+':
                    return leftVal + rightVal;
                case '-':
                    return leftVal - rightVal;
                case '*':
                    return leftVal * rightVal;
                case '/':
                    return leftVal / rightVal;
                default: // if it is not any of the operators that we support, throw an exception:
                    throw new NotSupportedException(
                        "Operator " + binOperator.ToString() + " not supported.");
            }
        }
    }
}
