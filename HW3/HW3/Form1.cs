// <copyright file="Form1.cs" company="Manjesh Reddy Puram">
// Copyright (c) Manjesh Reddy Puram. All rights reserved.
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
    /// Create the form class.
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
        /// Button in the menu for loading a file.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
        private void LoadFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Button in the menu for loading a file with 50 fibonacci numbers.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
        private void LoadFibonacciNumbersFirst50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Button in the menu for loading a file with 100 fibonacci numbers.
        /// </summary>
        /// <param name="sender"> Sender Object. </param>
        /// <param name="e"> Passing in the EventArgs called e. </param>
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
            Stream textExtraction;
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                if ((textExtraction = saveFileDialog.OpenFile()) != null)
                {
                    string input = this.textBox1.Text;
                    byte[] helloWorldBytes = Encoding.UTF8.GetBytes(input);
                    try
                    {
                        textExtraction.Write(helloWorldBytes, 0, helloWorldBytes.Length);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("ERROR: Something went wrong");
                    }

                    textExtraction.Close();
                }
            }
        }
    }
}
