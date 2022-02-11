﻿// <copyright file="FibonacciTextReader.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace HW3.FibonacciTextReader
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Create the FibonacciTextReader Class.
    /// </summary>
    public class FibonacciTextReader : System.IO.TextReader
    {
        // Variable used to hold the max number of lines when we plug into constructor
        private int maxNumberLines;
        private int fibCounter; // Holds the counter for which number we are at in the process of the Fibonacci Calculations.
        private BigInteger onePosBehind; // Number that holds the fibCounter - 1.
        private BigInteger twoPosBehind; // Number that holds the fibCounter - 2.

        /// <summary>
        /// Initializes a new instance of the <see cref="FibonacciTextReader"/> class.
        /// Constructor of the FibonacciTextReader.
        /// </summary>
        /// <param name="maxNumberLines"> Set the maxNumberLines. </param>
        public FibonacciTextReader(int maxNumberLines)
        {
            this.maxNumberLines = maxNumberLines;
            this.fibCounter = 0;
            this.onePosBehind = 0;
            this.twoPosBehind = 1;
        }

        /// <summary>
        /// Overriding the ReadLine function from the TextReader class.
        /// </summary>
        /// <returns> Return the number after calculating. </returns>
        public override string ReadLine()
        {
            if (this.maxNumberLines < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                switch (this.fibCounter)
                {
                    case 0:
                        this.fibCounter++;
                        return "0";
                    case 1:
                        this.fibCounter++;
                        return "1";
                }

                if (this.fibCounter == this.maxNumberLines)
                {
                    return null;
                }
                else
                {
                    BigInteger currentFibonacciNumber = BigInteger.Add(this.onePosBehind, this.twoPosBehind);
                    this.fibCounter++;

                    this.onePosBehind = this.twoPosBehind;
                    this.twoPosBehind = currentFibonacciNumber;

                    return currentFibonacciNumber.ToString();
                }
            }
        }

        /// <summary>
        /// Overriding the ReadToEnd function from the TextReader class.
        /// </summary>
        /// <returns> Returns the full list of the combinations from the calcuations. </returns>
        public override string ReadToEnd()
        {
            StringBuilder fullStringReadout = new StringBuilder();

            for (int lineCounter = 1; lineCounter <= this.maxNumberLines; lineCounter++)
            {
                fullStringReadout.Append(lineCounter + ": " + this.ReadLine() + Environment.NewLine);
            }

            return fullStringReadout.ToString();
        }
    }
}