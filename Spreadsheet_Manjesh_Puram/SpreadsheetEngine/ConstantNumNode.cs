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
    /// </summary>
    internal class ConstantNumNode : BaseNode
    {
        /// <summary>
        /// This holds the value of our constant value.
        /// </summary>
        private double constantValue;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantNumNode"/> class.
        /// </summary>
        /// <param name="newConstantValue"> Takes in a value for our constant value when get a new instance created. </param>
        public ConstantNumNode(double newConstantValue)
        {
            this.constantValue = newConstantValue; // Set the value of constantValue to the value being passed in during instantiation.
        }

        /// <summary>
        /// Gets or sets, this serves as the get and set controller for our constantValue.
        /// </summary>
        public double ConstantValue
        {
            get { return this.constantValue; }
            set { this.constantValue = value; }
        }
    }
}
