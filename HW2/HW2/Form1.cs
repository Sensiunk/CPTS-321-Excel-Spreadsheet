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

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> masterList = new List<int>(10000);
            Random randValue = new Random();

            for (int counter = 1; counter <= 10000; counter++)
            {
                masterList.Add(randValue.Next(20001));
            }

            int hashNum = DistinctIntegersCalculator.DistinctIntegersCalculator.UniqueNumbersUsingHashSet(masterList);
            int lastNum = DistinctIntegersCalculator.DistinctIntegersCalculator.UniqueNumbersUsingLastIndex(masterList);
            int sortNum = DistinctIntegersCalculator.DistinctIntegersCalculator.UniqueNumbersUsingSortedForLoops(masterList);

            string test = string.Format("{0} This is a test", hashNum);
            string test1 = string.Format("{0} This is a test", lastNum);
            string test2 = string.Format("{0} This is a test", sortNum);

            this.finalTextBox.Text = test + Environment.NewLine;
            this.finalTextBox.AppendText(test1 + Environment.NewLine);
            this.finalTextBox.AppendText(test2 + Environment.NewLine);
        }
    }
}
