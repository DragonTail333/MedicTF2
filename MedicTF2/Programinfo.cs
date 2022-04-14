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
    public partial class Programinfo : Form
    {
        public Programinfo()
        {
            InitializeComponent();
        }

        private void Programinfo_Load(object sender, EventArgs e)
        {
            //Делает все lable прозрачными
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
        }

       
        //:3
        private void label9_Click(object sender, EventArgs e)
        {

        }
        //Открывает гиперссылку
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/id465503557 ");
        }
        //Открывает гиперссылку
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://t.me/dragonbroyn");
        }
    }
}
