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
using ProjectCheckSum_V2.Model.Watch;

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
                if (Store.myDataTable != null && (Store.myDataTable != Store.myPreDataTable || Store.myPreDataTable == new DataTable())) { 
                    dataGridView1.DataSource = Store.myDataTable;
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {

                        column.SortMode = DataGridViewColumnSortMode.Automatic;
                    }
                    dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);

                    // Progress Bar
                    progressBar1.Value = Store.CurrentMyWorkingIs;
                }
            }
            catch (Exception)
            {

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateView(); // TODO: Active this one time only do not use it as a timer

            //Thread newThread = new Thread(new ThreadStart(CalculateCurrent));
            //newThread.Start();

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Go();
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            richTextBox1.Text = Store.Log;
            textBox1.Text = Store.TotalFiles.ToString();

            if (Store.ListOfFile.Count() > 0 && !timer1.Enabled)
            {
                Log.Write("Begin to Show Data");
                timer1.Start();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // set the current caret position to the end
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                // scroll it automatically
                richTextBox1.ScrollToCaret();
            }
            
            if (checkBox2.Checked)
            {
                // Export Log
                Log.Export(@"B:\Learn\Log.txt");
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
