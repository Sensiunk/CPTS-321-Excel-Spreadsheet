// <copyright file="Form1.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace HW2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Form class to be able to use the Form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// This function is called to run the main code.
        /// </summary>
        /// <param name="sender"> This takes in the input of object sender. </param>
        /// <param name="e"> This takes in the input of EventArgs e. </param>
        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> masterList = new List<int>(10000); // Declaration of a list with 10000
            Random randValue = new Random(); // Creating a randomized number

            // Import 10000 numbers into the list
            for (int counter = 1; counter <= 10000; counter++)
            {
                masterList.Add(randValue.Next(20001)); // Pick a random number from 0 to 20000
            }

            // These three lines of code: Calculate the number of unique numbers using the hash method and stores into a int called hashNum
            // It then takes that num and places it into a string so that it can be printed
            // It appends that string to the starting of the text box to be displated and creates a new line after
            int hashNum = DistinctIntegersCalculator.DistinctIntegersCalculator.UniqueNumbersUsingHashSet(masterList);
            string firstMethodStats = string.Format("1. HashSet Method: {0} unique numbers", hashNum);
            this.finalTextBox.AppendText(firstMethodStats + Environment.NewLine);

            // This is the code block that shows why we recieved a O(1) time complexity when we use a hashset
            string timeComplexityExplination = string.Format("   In our scenario, a HashSet uses a O(1) time complexity for adding into a hashset. The reason for this is because we take the input and make that into a hash and stores into that location. If we get another value that happens to be the same, the hash will be the same and therefore it will just write over the prior hash and it allows for no instances of duplicates.", hashNum);
            this.finalTextBox.AppendText(timeComplexityExplination + Environment.NewLine);

            // These three lines of code: Calculate the number of unique numbers using the last index method and stores into a int called lastNum
            // It then takes that num and places it into a string so that it can be printed
            // It appends that string to the starting of the text box to be displated and creates a new line after
            int lastNum = DistinctIntegersCalculator.DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(masterList);
            string secondMethodStats = string.Format("2. O(1) storage method: {0} unique numbers", lastNum);
            this.finalTextBox.AppendText(secondMethodStats + Environment.NewLine);

            // These three lines of code: Calculate the number of unique numbers using the sorted for loop method and stores into a int called sortNum
            // It then takes that num and places it into a string so that it can be printed
            // It appends that string to the starting of the text box to be displated and creates a new line after
            int sortNum = DistinctIntegersCalculator.DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(masterList);
            string thirdMethodStats = string.Format("3. Sorted method: {0} unique numbers", sortNum);
            this.finalTextBox.AppendText(thirdMethodStats + Environment.NewLine);

            this.finalTextBox.AppendText(Environment.NewLine);
            this.finalTextBox.AppendText(Environment.NewLine);

            this.finalTextBox.AppendText("Press the X to exit the program."); // Just for the reader to know what to do once done
        }
    }
}
