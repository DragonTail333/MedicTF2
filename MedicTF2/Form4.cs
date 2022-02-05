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
    public partial class Form4 : Form
    {
      
        public Form4()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        private void Form4_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=caseum.ru;port=33333;user=st_1_1_19;database=st_1_1_19;password=79335329;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string n_id_pasient = textBox7.Text;
            string n_fio = textBox1.Text;
            string n_birthday = textBox2.Text;
            string n_sex = textBox3.Text;
            string n_polis = textBox4.Text;
            string n_number = textBox5.Text;
            string n_diagnoz = textBox6.Text;
            //Формируем запрос на изменение
            string sql_update_current_pasient = $"INSERT INTO pasienti (id_pasient, fio_pasient, birthday, sex, polis, number_phone, prichina_pribitia)" +
                $" VALUES ('{n_id_pasient}','{n_fio}', '{n_birthday}', '{n_sex}', '{n_polis}', '{n_number}', '{n_diagnoz}')";
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
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Добавить пациента не удалось, вам нужно обязательно заполнить все поля!");
                }
            }
            }
    }
}
