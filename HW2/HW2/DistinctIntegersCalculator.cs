// <copyright file="DistinctIntegersCalculator.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace HW2.DistinctIntegersCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class to hold the methods to check for Unique numbers within a given random list.
    /// </summary>
    public class DistinctIntegersCalculator
    {
        /// <summary>
        /// Calculate the number of unique numbers within a list using a hash set.
        /// </summary>
        /// <param name="hashUtilizedList"> Pass in a random list generated such that it can sort and return the unique numbers. </param>
        /// <returns> Returns the number of unique numbers found in the random list. </returns>
        public static int UniqueNumbersUsingHashSet(List<int> hashUtilizedList)
        {
            HashSet<int> hashSetForUniqueness = new HashSet<int>(); // Create and allocate space for a new hash set.

            // Iterate through the list and grab each value and place it in the retreivedValues variable.
            foreach (int retreivedValues in hashUtilizedList)
            {
                if (retreivedValues <= -1 || retreivedValues >= 20001)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(retreivedValues)} must be greater than or equal to zero.");
                }
                else
                {
                    hashSetForUniqueness.Add(retreivedValues); // Add the retreivedValues into the hash set.
                }
            }

            return hashSetForUniqueness.Count(); // Return the value we got from hash set count.
        }

        /// <summary>
        /// Calculate the number of unique numbers within a list using last index.
        /// </summary>
        /// <param name="forUtilizedList"> Pass in a random list generated such that it can sort and return the unique numbers. </param>
        /// <returns> Returns the number of unique numbers found in the random list. </returns>
        public static int UniqueNumbersUsingLastIndex(List<int> forUtilizedList)
        {
            int uniqueNumbers = 0; // Declare a variable we are going to increment with each unique number

            // Making a for loop that we are going to iterate through the count of the list
            for (int index = 0; index < forUtilizedList.Count(); index++)
            {
                // We check to see if the value found at the last index is where our index incrementer is
                if (forUtilizedList.FindLastIndex(indexLastChecker => indexLastChecker == forUtilizedList[index]) == index)
                {
                    uniqueNumbers++; // Increment the counter if the statement is true
                }
            }

            return uniqueNumbers; // Return the value we got from the for loop
        }

        /// <summary>
        /// Calculate the number of unique number within a sorted list using a for loop.
        /// </summary>
        /// <param name="sortedForUtilizedList"> Pass in a random list generated such that it can sort and return the unique numbers. </param>
        /// <returns> Returns the number of unique numbers found in the random list. </returns>
        public static int UniqueNumbersUsingSortedForLoops(List<int> sortedForUtilizedList)
        {
            sortedForUtilizedList.Sort();
            int uniqueNumbers = 1;


            for (int i = 1; i < sortedForUtilizedList.Count(); i++)
            {
                if (sortedForUtilizedList[i - 1] != sortedForUtilizedList[i])
                {
                    uniqueNumbers++;
                }
            }

            return uniqueNumbers;
        }
    }
}
