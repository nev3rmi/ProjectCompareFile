using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectCheckSum_V2.Model.Start;
using ProjectCheckSum_V2.ViewModel;
using System.Threading;

namespace ProjectCheckSum_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


        public void updateView()
        {
            try
            {
                dataGridView1.DataSource = Store.myDataTable;
                //foreach (DataGridViewColumn column in dataGridView1.Columns)
                //{

                //    column.SortMode = DataGridViewColumnSortMode.Automatic;
                //}
                dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Go();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text = Store.Log;
        }
    }
}
