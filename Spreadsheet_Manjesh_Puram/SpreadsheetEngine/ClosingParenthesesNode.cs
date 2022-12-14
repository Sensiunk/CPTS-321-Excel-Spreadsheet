// <copyright file="ClosingParenthesesNode.cs" company="Manjesh Reddy Puram 11716685">
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
    /// This serves as the node that gets created in the case that we see a closing parentheses as the operator.
    /// </summary>
    internal class ClosingParenthesesNode : BinaryOperatorNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClosingParenthesesNode"/> class.
        /// </summary>
        public ClosingParenthesesNode()
            : base(')')
        {
        }

        /// <summary>
        /// Gets, this contains the information needed to know what precedence the closing parentheses has.
        /// </summary>
        public new int Precedence { get; } = 7;

        /// <summary>
        /// This function serves the purpose to return the difference when we do the evaluation for the calculations.
        /// </summary>
        /// <param name="leftVal"> Takes in the double from the left side. </param>
        /// <param name="rightVal"> Takes in the double from the right side. </param>
        /// <returns> Returns the operated value of the left side and right side. </returns>
        public override double Evaluate(double leftVal, double rightVal)
        {
            return leftVal;
        }
    }
}
