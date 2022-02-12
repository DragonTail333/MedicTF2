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
using static MedicTF2.PatientList;

namespace MedicTF2
{
    public partial class PatientUPDATE : Form
    {
        public PatientUPDATE()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        private void Form11_Load(object sender, EventArgs e)
        {
            //Делает все lable прозрачными
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            // строка подключения к БД
            string connStr = "server=caseum.ru;port=33333;user=st_1_1_19;database=st_1_1_19;password=79335329;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод установления значений полей
            // SelectData();
        }

        public void SelectData()
        {
            //Открываем соединение
            conn.Open();
            string redactid = textBox1.Text;
            //Меняем на форме название, с указанием того студента, которого хотим изменить
            this.Text = $"Меняем пользователя ID: {redactid}";
            //Объявляем запрос на вывод данных из таблицы в поля
            string sql_select_current_pasient = $"SELECT pasienti.id_pasient, pasienti.fio_pasient, pasienti.birthday, pasienti.sex, pasienti.polis, pasienti.number_phone, pasienti.prichina_pribitia FROM pasienti WHERE id_pasient = {redactid}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_select_current_pasient, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                textBox4.Text = reader[3].ToString();
                textBox5.Text = reader[4].ToString();
                textBox6.Text = reader[5].ToString();
                textBox7.Text = reader[6].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //Объявлем переменную для запроса в БД
            string selected_id_pasient = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT fio_pasient, birthday, sex, polis, " +
                $"number_phone, prichina_pribitia FROM pasienti WHERE id_pasient={selected_id_pasient}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            string fio_pasient = command.ExecuteScalar().ToString();
            string birthday = command.ExecuteScalar().ToString();
            string sex = command.ExecuteScalar().ToString();
            string polis = command.ExecuteScalar().ToString();
            string number_phone = command.ExecuteScalar().ToString();
            string prichina_pribitia = command.ExecuteScalar().ToString();
            // выводим ответ в TextBox
            textBox2.Text = fio_pasient;
            textBox3.Text = birthday;
            textBox4.Text = sex;
            textBox5.Text = polis;
            textBox6.Text = number_phone;
            textBox7.Text = prichina_pribitia;
            // закрываем соединение с БД
            conn.Close();
            SelectData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Получаем ID изменяемого пациента
            string redact_id = textBox1.Text;
            //Получаем значение новых данных из TextBox
            string new_fio = textBox2.Text;
            string new_birthday = textBox3.Text;
            string new_sex = textBox4.Text;
            string new_polis = textBox5.Text;
            string new_number_phone = textBox6.Text;
            string new_prichina_pribitia = textBox7.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE pasienti SET fio_pasient = '{new_fio}', birthday = '{new_birthday}', sex = '{new_sex}', polis = '{new_polis}'," +
                $" number_phone = '{new_number_phone}', prichina_pribitia  = '{new_prichina_pribitia}' WHERE id_pasient = {redact_id}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }
    }

}
