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
            string connStr = "server=caseum.ru;port=33333;user=st_1_1_19;database=st_1_1_19;password=79335329;";
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
                comboBox1.SelectedValue = reader[1].ToString();
                comboBox2.SelectedValue = reader[2].ToString();
                comboBox3.SelectedValue = reader[3].ToString();
                comboBox4.SelectedValue = reader[4].ToString();
                textBox6.Text = reader[5].ToString();
                textBox7.Text = reader[6].ToString();
                textBox8.Text = reader[7].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Получаем ID изменяемого пациента
            string redact_id = textBox1.Text;
            ///Получаем значение новых данных из TextBox
            ///string new_id_vrach = ;
            ///string new_id_pasient =;
            ///string new_id_palata = ;
            ///string new_id_koika = ;
            string new_date_pribitia = textBox6.Text;
            string new_date_lechit = textBox7.Text;
            string new_date_vipiski = textBox8.Text;
            // устанавливаем соединение с БД
            conn.Open();
            // запрос обновления данных
            ///string query2 = $"UPDATE stasionar SET fio_pasient = '{new_fio}', birthday = '{new_birthday}', sex = '{new_sex}', polis = '{new_polis}'," +
            /// $" number_phone = '{new_number_phone}', prichina_pribitia  = '{new_prichina_pribitia}' WHERE id_pasient = {redact_id}";
            // объект для выполнения SQL-запроса
            ///MySqlCommand command = new MySqlCommand(query2, conn);
            // выполняем запрос
            ///command.ExecuteNonQuery();
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
            string fio_pasient = command.ExecuteScalar().ToString();
            string birthday = command.ExecuteScalar().ToString();
            string sex = command.ExecuteScalar().ToString();
            string polis = command.ExecuteScalar().ToString();
            string number_phone = command.ExecuteScalar().ToString();
            string prichina_pribitia = command.ExecuteScalar().ToString();
            // выводим ответ в TextBox
            comboBox1.SelectedValue = fio_pasient;
            comboBox2.SelectedValue = birthday;
            comboBox3.SelectedValue = sex;
            comboBox4.SelectedValue = polis;
            textBox6.Text = number_phone;
            textBox7.Text = prichina_pribitia;
            // закрываем соединение с БД
            conn.Close();
            SelectData();
        }
    }
}
