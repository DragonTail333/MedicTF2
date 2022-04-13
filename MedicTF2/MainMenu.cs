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
            //Делает все lable прозрачными
            this.label1.BackColor = System.Drawing.Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PatientINSERT Form4 = new PatientINSERT();
            Form4.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientList Form5 = new PatientList();
            Form5.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DoctorList Form6 = new DoctorList();
            Form6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RoomsHospital Form7 = new RoomsHospital();
            Form7.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AdmissionList Form8= new AdmissionList();
            Form8.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Programinfo Form = new Programinfo();
            Form.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form Form = new Auth();
            Form.Show();
            this.Close();
        }
    }
}
