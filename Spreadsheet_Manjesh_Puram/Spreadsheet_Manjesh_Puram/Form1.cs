namespace Spreadsheet_Manjesh_Puram
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

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 65; i <= 90; i++)
            {
                string letter = ((char)i).ToString();

                this.SpreadsheetGridView.Columns.Add("newColumnName" + i, letter);
            }

            this.SpreadsheetGridView.Rows.Clear();
            this.SpreadsheetGridView.Rows.Add(50);

            for (int i = 1; i <= 50; i++)
            {
                this.SpreadsheetGridView.Rows[i - 1].HeaderCell.Value = i.ToString();
            }
        }
    }
}
