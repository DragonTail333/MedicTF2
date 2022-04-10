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
    public partial class AdmissionINSERT : Form
    {
        public AdmissionINSERT()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        private void AdmissionINSERT_Load(object sender, EventArgs e)
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
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_1;database=is_1_19_st1_KURS;password=97537091;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string n_id = textBox1.Text;
            string n_id_vrach = textBox2.Text;
            string n_id_pasient = textBox3.Text;
            string n_id_palati = textBox4.Text;
            string n_id_koiki = textBox5.Text;
            string n_datapribitia = textBox6.Text;
            string n_datavipiski = textBox7.Text;
            string n_datalechit = textBox8.Text;
            //Формируем запрос на изменение
            string sql_update_current_pasient = $"INSERT INTO stasionar (id, id_vrach, id_pasient, id_palata, id_koika, date_pribitia, date_vipiski, date_lechit)" +
                $" VALUES ('{n_id}','{n_id_vrach}', '{n_id_pasient}', '{n_id_palati}', '{n_id_koiki}', '{n_datapribitia}', '{n_datavipiski}', '{n_datalechit}')";
            // устанавливаем соединение с БД
            conn.Open();
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_update_current_pasient, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
            //Закрываем форму
            this.Close();
            //Если оставить поля пустыми, то будет выдавать ошибку, что не все поля заполнены
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Добавить пациента не удалось, вам нужно обязательно заполнить все поля!");
                }
            }
        }
    }
}
