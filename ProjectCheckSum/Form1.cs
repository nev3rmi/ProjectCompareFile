using ProjectCheckSum.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCheckSum.ViewModel;
using System.Threading;

namespace ProjectCheckSum
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start me = new Start();
            me.Go();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            updateDataGridView();
            
        }

        private void updateDataGridView()
        {
            try
            {
                richTextBox1.Text = DataViewModel.myLog;
                dataGridView1.DataSource = DataViewModel.myDataTable;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {

                    column.SortMode = DataGridViewColumnSortMode.Automatic;
                }
                dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateDataGridView();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DataViewModel.myTotalScanFile.ToString();
        }
    }
}
