// <copyright file="VariableNode.cs" company="Manjesh Reddy Puram 11716685">
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
    /// This serves as the node that gets created in the case that we see a variable in the expression given by the user.
    /// </summary>
    internal class VariableNode : BaseNode
    {
        private string variableName; // This holds the value of our variable name

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableNode"/> class.
        /// </summary>
        /// <param name="newVariableName"> Takes in a value for our variable name when we get a new instance created. </param>
        public VariableNode(string newVariableName)
        {
            this.variableName = newVariableName; // Set the value of the variableName to the value being passed in during instantiation.
        }

        /// <summary>
        /// Gets or sets, this serves as the get and set controller for our variableName.
        /// </summary>
        public string VariableName
        {
            get { return this.variableName; }
            set { this.variableName = value; }
        }
    }
}