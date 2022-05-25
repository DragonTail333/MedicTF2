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
        }

        public void SelectData()
        {
            //Открываем соединение
            conn.Open();
            string redactid = textBox1.Text;
            //Меняем на форме название, с указанием того приёма, которого хотим изменить
            this.Text = $"Меняем пользователя ID: {redactid}";
            //Объявляем запрос на вывод данных из таблицы в поля
            string sql_select_current_priem = $"SELECT stasionar.id, stasionar.id_vrach, stasionar.id_pasient, stasionar.id_palata, stasionar.id_koika," +
                $"stasionar.date_prebitia, stasionar.date_vipiski, stasionar.date_lechit FROM stasionar WHERE id = {redactid}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_select_current_priem, conn);
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
                dateTimePicker1.Value = (DateTime)new DateTimeConverter().ConvertFrom(reader[5].ToString());
                dateTimePicker2.Value = (DateTime)new DateTimeConverter().ConvertFrom(reader[6].ToString());
                dateTimePicker3.Value = (DateTime)new DateTimeConverter().ConvertFrom(reader[7].ToString());

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
            string n_id_vrach = textBox2.Text;
            string n_id_pasient = textBox3.Text;
            string n_id_palati = textBox4.Text;
            string n_id_koiki = textBox5.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            string query2 = $"UPDATE stasionar SET id_vrach = '{n_id_vrach}', id_pasient = '{n_id_pasient}', id_palata = '{n_id_palati}', id_koika = '{n_id_koiki}'," +
             $" date_prebitia = @dateo, date_lechit  = @dated , date_vipiski  = @dateb WHERE id_pasient = {redact_id}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // объект для выполнения SQL-запроса
            command.Parameters.Add("@dateo", MySqlDbType.Timestamp).Value = dateTimePicker1.Value;
            command.Parameters.Add("@dated", MySqlDbType.Timestamp).Value = dateTimePicker2.Value;
            command.Parameters.Add("@dateb", MySqlDbType.Timestamp).Value = dateTimePicker3.Value;
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SelectData();
        }
    }
}
