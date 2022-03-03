// <copyright file="BaseNode.cs" company="Manjesh Reddy Puram 11716685">
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
    /// This serves as the initial base class for all the other Nodes to build off of.
    /// </summary>
    internal abstract class BaseNode
    {
        /// <summary>
        /// This is the default Evaluate method for all other Nodes to build off of.
        /// </summary>
        /// <returns> We return the evaluated double. </returns>
        public abstract double Evaluate();
    }
}
