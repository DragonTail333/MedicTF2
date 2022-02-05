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
    public partial class Auth : Form
    {
        public Auth()
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
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Переход на второй Form
            MainMenu Form3 = new MainMenu();
            Form3.ShowDialog();
            Hide();
        }
    }
}
