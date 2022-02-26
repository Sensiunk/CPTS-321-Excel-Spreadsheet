
namespace Spreadsheet_Manjesh_Puram
{
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
            this.SpreadsheetGridView = new System.Windows.Forms.DataGridView();
            this.DemoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SpreadsheetGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SpreadsheetGridView
            // 
            this.SpreadsheetGridView.AllowUserToAddRows = false;
            this.SpreadsheetGridView.AllowUserToDeleteRows = false;
            this.SpreadsheetGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SpreadsheetGridView.Location = new System.Drawing.Point(12, 13);
            this.SpreadsheetGridView.Name = "SpreadsheetGridView";
            this.SpreadsheetGridView.Size = new System.Drawing.Size(2853, 536);
            this.SpreadsheetGridView.TabIndex = 0;
            // 
            // DemoButton
            // 
            this.DemoButton.Location = new System.Drawing.Point(1409, 630);
            this.DemoButton.Name = "DemoButton";
            this.DemoButton.Size = new System.Drawing.Size(275, 23);
            this.DemoButton.TabIndex = 1;
            this.DemoButton.Text = "Perform Demo";
            this.DemoButton.UseVisualStyleBackColor = true;
            this.DemoButton.Click += new System.EventHandler(this.DemoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2889, 714);
            this.Controls.Add(this.DemoButton);
            this.Controls.Add(this.SpreadsheetGridView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpreadsheetGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SpreadsheetGridView;
        private System.Windows.Forms.Button DemoButton;
    }
}

