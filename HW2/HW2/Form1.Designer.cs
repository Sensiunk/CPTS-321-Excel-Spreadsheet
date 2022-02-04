// <copyright file="Form1.Designer.cs" company="Manjesh Reddy Puram 11716685">
// Copyright (c) Manjesh Reddy Puram 11716685. All rights reserved.
// </copyright>

using System.Windows.Forms;

namespace HW2
{
    /// <summary>
    /// Class to access the form and run it.
    /// </summary>
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.finalTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // finalTextBox
            // 
            this.finalTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finalTextBox.Location = new System.Drawing.Point(0, 0);
            this.finalTextBox.Multiline = true;
            this.finalTextBox.Name = "finalTextBox";
            this.finalTextBox.Size = new System.Drawing.Size(800, 450);
            this.finalTextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.finalTextBox);
            this.Name = "Form1";
            this.Text = "Manjesh Reddy Puram 11716685";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox finalTextBox;

        /// <summary>
        /// Creates the textbox
        /// </summary>
        /// <param name="finalTextBox"> Takes in the input of finalTextBox </param>
        public Form1(TextBox finalTextBox)
        {
            this.finalTextBox = finalTextBox;
        }
    }
}