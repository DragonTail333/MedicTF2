using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicTF2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5();
            Form5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form6 Form6 = new Form6();
            Form6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 Form7 = new Form7();
            Form7.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 Form8= new Form8();
            Form8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form9 Form9 = new Form9();
            Form9.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form Form = new Form1();
            Form.Show();
            this.Close();
        }
    }
}
