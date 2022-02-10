// <copyright file="FibonacciTextReader.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace HW3.FibonacciTextReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Create the FibonacciTextReader Class.
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        private int maxNumLines;

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// Constructor of the FibonacciTextReader.
        /// </summary>
        /// <param name="maxNumOfLines"> Set the inputMaxNumOfLines. </param>
        public FibonacciTextReader(int inputMaxNumOfLines)
        {
            this.maxNumLines = inputMaxNumOfLines;
        }
    }
}
