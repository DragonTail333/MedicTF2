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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         //Делает все lable прозрачными
         this.label1.BackColor = System.Drawing.Color.Transparent;
         this.label2.BackColor = System.Drawing.Color.Transparent;
         this.label3.BackColor = System.Drawing.Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Переход на второй Form
            Form2 Form2 = new Form2();
            Form2.ShowDialog();
            Hide();
        }
    }
}
