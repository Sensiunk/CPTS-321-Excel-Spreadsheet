// <copyright file="Form1.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

namespace HW3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// Form class to be able to use the Form.
    /// </summary>
    public partial class Form1 : Form
    {
        private StringBuilder fibonacciResult = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Used as our method to load our text.
        /// </summary>
        /// <param name="sr"> TextReader Object. </param>
        private void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd();
        }

        /// <summary>
        /// Button in the menu for loading a file.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog(); // Make an instance of the open file dialog

            // Checks to see if opening and getting the file was successful
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName); // Sets the Stream reader up and tells where and what the file is called
                this.LoadText(sr); // Calls the function and doesnt override the function since we are passing in a StreamReader
                sr.Dispose(); // Dispose of the StreamReader once we are done such that it is ready for garbage collection
            }
        }

        /// <summary>
        /// Button in the menu for loading the first 50 fibonacci numbers into the text box.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
        private void LoadFibonacciNumbersFirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader.FibonacciTextReader firstFiftyFibonacci = new FibonacciTextReader.FibonacciTextReader(50); // Create a new instance of the FibonacciTextReader and load 50 into the maxNumber
            this.LoadText(firstFiftyFibonacci); // Calls the function to calculate the first 50 fibonacci and it does this through overriding the function
            firstFiftyFibonacci.Dispose(); // Dispose of the FibonacciTextReader once we are done such that it is ready for garbage collection
        }

        /// <summary>
        /// Button in the menu for loading the first 100 fibonacci numbers into the text box.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
        private void LoadFibonacciNumbersFirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FibonacciTextReader.FibonacciTextReader firstHundredFibonacci = new FibonacciTextReader.FibonacciTextReader(100); // Create a new instance of the FibonacciTextReader and load 100 into the maxNumber
            this.LoadText(firstHundredFibonacci); // Calls the function to calculate the first 100 fibonacci and it does this through overriding the function
            firstHundredFibonacci.Dispose(); // Dispose of the FibonacciTextReader once we are done such that it is ready for garbage collection
        }

        /// <summary>
        /// Store text from the textbox into a file.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create new stream such that we can use it go grab from textbox
            Stream textExtraction;

            // Create an instance of saveFileDialog so that we can use the method to help create the file.
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Batch of setting we need to set in order to get the file dialog to work
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.RestoreDirectory = true;

            // Checking to see if the fileDialog works
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // We are checking if the stream variable is not null
                if ((textExtraction = saveFileDialog.OpenFile()) != null)
                {
                    string input = this.textBox1.Text; // Create an input variable for text

                    byte[] textBoxInput = Encoding.UTF8.GetBytes(input); // Transcribe the text into the byte array
                    try
                    {
                        textExtraction.Write(textBoxInput, 0, textBoxInput.Length); // Use the stream to write the string into the file
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Something went wrong"); // If we fail then we through the exception
                    }

                    textExtraction.Close(); // Close the stream once we are done
                }
            }
        }
    }
}
