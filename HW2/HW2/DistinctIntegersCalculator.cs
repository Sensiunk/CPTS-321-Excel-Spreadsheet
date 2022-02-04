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
                // Check to see if the number coming from the list is outside of the range
                if (retreivedValues <= -1 || retreivedValues >= 20001)
                {
                    throw new ArgumentOutOfRangeException(); // Throw an exception if the numbers inputted happen to be out of the range
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
                // Check to see if the number coming from the list is outside of the range
                if (forUtilizedList[index] <= -1 || forUtilizedList[index] >= 20001)
                {
                    throw new ArgumentOutOfRangeException(); // Throw an exception if the numbers inputted happen to be out of the range
                }
                else
                {
                    // We check to see if the value found at the last index is where our index incrementer is
                    if (forUtilizedList.FindLastIndex(indexLastChecker => indexLastChecker == forUtilizedList[index]) == index)
                    {
                        uniqueNumbers++; // Increment the counter if the statement is true
                    }
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
            sortedForUtilizedList.Sort(); // Sort the list for this method

            int uniqueNumbers = 1; // Start the counter at 1 since there will always be 1 unique number

            for (int index = 1; index < sortedForUtilizedList.Count(); index++)
            {
                // Check to see if the number coming from the list is outside of the range
                if (sortedForUtilizedList[index] <= -1 || sortedForUtilizedList[index] >= 20001 || sortedForUtilizedList[index - 1] <= -1 || sortedForUtilizedList[index - 1] >= 20001)
                {
                    throw new ArgumentOutOfRangeException(); // Throw an exception if the numbers inputted happen to be out of the range
                }
                else
                {
                    // Check to see if the number at index is the same as the index place minus 1
                    if (sortedForUtilizedList[index - 1] != sortedForUtilizedList[index])
                    {
                        uniqueNumbers++; // Increment our counter if it is unique
                    }
                }
            }

            return uniqueNumbers; // Return the value after we calculate the uniqueNumberCount
        }
    }
}
