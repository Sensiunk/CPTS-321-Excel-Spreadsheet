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
        /// <param name="maxNumberLines"> Set the maxNumberLines to the inputted maxNumberLines, set the counter to 0, set the onePosBehind to 0 and the twoPosBehind to 1. </param>
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
            if (this.maxNumberLines < 1)
            {
                throw new ArgumentOutOfRangeException(); // We throw an error here if we receive a number that is less than 1 since we will always be looking for either 1 or more numbers.
            }
            else
            {
                // Switch statement that checks if the counter is in the 1st posiiton or the 2nd posiiton
                switch (this.fibCounter)
                {
                    case 0:
                        this.fibCounter++; // Increase the counter if we get the posiiton to be in the 1st
                        return "0"; // Return 0 as the string
                    case 1:
                        this.fibCounter++; // Increase the counter if we get the potition to be in the 2nd
                        return "1"; // Return 1 as the string
                }

                // If we get our counter to be the max then we return null since we reached our cap
                if (this.fibCounter == this.maxNumberLines)
                {
                    return null; // Don't add anything
                }
                else
                {
                    BigInteger currentFibonacciNumber = BigInteger.Add(this.onePosBehind, this.twoPosBehind); // Adds the two number to be stored as our currectFibonacciNumber

                    this.fibCounter++; // Increase the counter since we are counting towards our goal of numbers

                    this.onePosBehind = this.twoPosBehind; // Set the number that was originally two behind as the one that is now one behind
                    this.twoPosBehind = currentFibonacciNumber; // Set the number that is currently as the number that two positions behind

                    return currentFibonacciNumber.ToString(); // Return the string to the ReadToEnd function
                }
            }
        }

        /// <summary>
        /// Overriding the ReadToEnd function from the TextReader class.
        /// </summary>
        /// <returns> Returns the full list of the combinations from the calcuations. </returns>
        public override string ReadToEnd()
        {
            StringBuilder fullStringReadout = new StringBuilder(); // Our temporary string builder that we will be returning

            // If we hit a case where our maxNumberLines is less than 1 then we return an exception
            if (this.maxNumberLines < 1)
            {
                throw new ArgumentOutOfRangeException(); // Out of range exception
            }
            else
            {
                // Loops through the first time all the way to the max numbers of lines we are looking for
                for (int lineCounter = 1; lineCounter <= this.maxNumberLines; lineCounter++)
                {
                    fullStringReadout.Append(lineCounter + ": " + this.ReadLine() + Environment.NewLine); // Add the number line and the calculated number to the string and add a new line to the end
                }
            }

            return fullStringReadout.ToString(); // Return the complete string builder once we are done.
        }
    }
}