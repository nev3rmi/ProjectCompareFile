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
            Start start = new Start();
            start.Go();
            timer1.Start();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            var drive1 = "";
            foreach (var drive in Store.ListOfDrive)
            {
                drive1 += drive.label;
            }
            richTextBox1.Text = drive1;
        }
    }
}
