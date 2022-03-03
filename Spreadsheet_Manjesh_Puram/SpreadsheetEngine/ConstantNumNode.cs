// <copyright file="ConstantNumNode.cs" company="Manjesh Reddy Puram 11716685">
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
    /// This serves as the node that gets created in the case that we see a constant number in the expression given by the user.
    /// We also are inheriting the BaseNode class which lets us utilize the abstract function of Evaluate which in this case,
    /// allows us to return the constant value when we get this class called on to evaluate.
    /// </summary>
    internal class ConstantNumNode : BaseNode
    {
        private double constantValue; // This holds the value of our constant value.

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNumNode"/> class.
        /// </summary>
        /// <param name="newConstantValue"> Takes in a value for our constant value when get a new instance created. </param>
        public ConstantNumNode(double newConstantValue)
        {
            this.constantValue = newConstantValue; // Set the value of constantValue to the value being passed in during instantiation.
        }

        /// <summary>
        /// Evaluate method which is overriden from the base abstract class. This is called on when we utilize the evaluate function in the expression tree class.
        /// </summary>
        /// <returns> We return the constant value stored in this Class. </returns>
        public override double Evaluate()
        {
            return this.constantValue; // Returrn the value of our constant value.
        }
    }
}
