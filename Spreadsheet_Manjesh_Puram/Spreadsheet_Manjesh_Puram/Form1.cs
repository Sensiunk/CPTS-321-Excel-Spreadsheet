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
            int asciiIncrementer = 64;

            for (int i = 1; i <= 26; i++)
            {
                string letter = ((char)(asciiIncrementer + i)).ToString();

                this.dataGridView1.Columns.Add("column" + i, letter);
            }

            this.dataGridView1.Rows.Clear();
            this.dataGridView1.Rows.Add(50);

            for (int i = 1; i < 50; i++)
            {
                var row = this.dataGridView1.Rows[i];
                row.HeaderCell.Value = (i + 1).ToString();
            }
        }
    }
}
