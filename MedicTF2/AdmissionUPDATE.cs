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
    public partial class AdmissionUPDATE : Form
    {
        public AdmissionUPDATE()
        {
            InitializeComponent();
        }
        MySqlConnection conn;

        private void AdmissionUPDATE_Load(object sender, EventArgs e)
        {
            //Делает все lable прозрачными
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_1;database=is_1_19_st1_KURS;password=97537091;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод установления значений полей
            //SelectData();
        }

        public void SelectData()
        {
            //Открываем соединение
            conn.Open();
            string redactid = textBox1.Text;
            //Меняем на форме название, с указанием того студента, которого хотим изменить
            this.Text = $"Меняем пользователя ID: {redactid}";
            //Объявляем запрос на вывод данных из таблицы в поля
            string sql_select_current_pasient = $"SELECT stasionar.id, stasionar.id_vrach, stasionar.id_pasient, stasionar.id_palata, stasionar.id_koika," +
                $" stasionar.date_pribitia, stasionar.date_lechit, stasionar.date_vipiski FROM stasionar WHERE id = {redactid}";
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
                dateTimePicker1.Text = reader[5].ToString();
                dateTimePicker1.Text = reader[6].ToString();
                dateTimePicker1.Text = reader[7].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Получаем ID изменяемого пациента
            string redact_id = textBox1.Text;
            //Получаем значение новых данных из TextBox
            string new_id_vrach = textBox2.Text;
            string new_id_pasient = textBox3.Text;
            string new_id_palata = textBox4.Text;
            string new_id_koika = textBox5.Text;
            string new_date_pribitia = dateTimePicker1.Text;
            string new_date_lechit = dateTimePicker1.Text;
            string new_date_vipiski = dateTimePicker1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE stasionar SET id_vrach = '{new_id_vrach}', id_pasient = '{new_id_pasient}', id_palata = '{new_id_palata}', id_koika = '{new_id_koika}'," +
             $" date_pribitia = '{new_date_pribitia}', date_lechit  = '{new_date_lechit}' , date_vipiski  = '{new_date_vipiski}' WHERE id_pasient = {redact_id}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявлем переменную для запроса в БД
            string selected_id = textBox1.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            string sql = $"SELECT id, id_vrach, id_pasient, id_palata, " +
                $"id_koika, date_pribitia, date_lechit, date_vipiski FROM stasionar WHERE id={selected_id}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql, conn);
            // выполняем запрос и получаем ответ
            string new_id_vrach = command.ExecuteScalar().ToString(); ;
            string new_id_pasient = command.ExecuteScalar().ToString(); ;
            string new_id_palata = command.ExecuteScalar().ToString(); ;
            string new_id_koika = command.ExecuteScalar().ToString(); ;
            string new_date_pribitia = command.ExecuteScalar().ToString(); ;
            string new_date_lechit = command.ExecuteScalar().ToString(); ;
            string new_date_vipiski = command.ExecuteScalar().ToString(); ;
            // выводим ответ в TextBox
            textBox2.Text = new_id_vrach;
            textBox3.Text = new_id_pasient;
            textBox4.Text = new_id_palata;
            textBox5.Text = new_id_koika;
            dateTimePicker1.Text = new_date_pribitia;
            dateTimePicker2.Text = new_date_lechit;
            dateTimePicker3.Text = new_date_vipiski;
            // закрываем соединение с БД
            conn.Close();
            SelectData();
        }
    }
}
