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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            JoinPatient Form4 = new JoinPatient();
            Form4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListPatient Form5 = new ListPatient();
            Form5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListDoctor Form6 = new ListDoctor();
            Form6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ListChambers Form7 = new ListChambers();
            Form7.ShowDialog(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListAdmission Form8= new ListAdmission();
            Form8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form Form = new Auth();
            Form.Show();
            this.Close();
        }
    }
}
