// <copyright file="FibonacciTextReader.cs" company="Manjesh Reddy Puram 11716685">
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
        /// Overriding the ReadToEnd function from the TextReader class.
        /// </summary>
        /// <returns> Return the string after calculating. </returns>
        public override string ReadToEnd()
        {
            StringBuilder outputResult = new StringBuilder();
            for (int lineNum = 1; lineNum <= this.maxNumberLines; lineNum++)
            {
                BigInteger currentFibonacciNumber = 0;
                if (this.fibCounter == this.maxNumberLines)
                {
                    return null;
                }
                else
                {
                    switch (this.fibCounter)
                    {
                        case 0:
                            this.fibCounter++;
                            outputResult.Append(lineNum + ": " + "0" + Environment.NewLine);
                            continue;
                        case 1:
                            this.fibCounter++;
                            outputResult.Append(lineNum + ": " + "1" + Environment.NewLine);
                            continue;
                    }

                    this.fibCounter++;

                    currentFibonacciNumber = this.onePosBehind + this.twoPosBehind;
                    this.onePosBehind = this.twoPosBehind;
                    this.onePosBehind = currentFibonacciNumber;
                }

                outputResult.Append(lineNum + ": " + currentFibonacciNumber + Environment.NewLine);
            }

            return outputResult.ToString();
        }
    }
}
