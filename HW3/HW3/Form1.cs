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
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        private void LoadText(TextReader sr)
        {
            this.textBox1.Text = sr.ReadToEnd();
        }

        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void LoadFibonacciNumbersFirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void LoadFibonacciNumbersFirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
