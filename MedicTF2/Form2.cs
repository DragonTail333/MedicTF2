using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MedicTF2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        private void Form2_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=caseum.ru;port=33333;user=st_1_1_19;database=account;password=79335329;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form = new Form3();
            Form.Show();
            this.Close();
        }
    }
}
