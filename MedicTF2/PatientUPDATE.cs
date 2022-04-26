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
            string sql_select_current_pasient = $"SELECT pasienti.id_pasient, pasienti.fio_pasient, pasienti.birthday, pasienti.sex, pasienti.polis," +
                $" pasienti.number_phone, pasienti.prichina_pribitia FROM pasienti WHERE id_pasient = {redactid}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_select_current_pasient, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                textBox2.Text = reader[1].ToString();
                dateTimePicker1.Value = (DateTime)new DateTimeConverter().ConvertFrom(reader[2].ToString());
                comboBox1.Text = reader[3].ToString();
                maskedTextBox1.Text = reader[4].ToString();
                maskedTextBox2.Text = reader[5].ToString(); //добавил маску текст бокс, как просила Рыскулова
                textBox7.Text = reader[6].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SelectData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Получаем ID изменяемого пациента
            conn.Open();
            string redact_id = textBox1.Text;
            //Меняем на форме название, с указанием того пациента, которого хотим изменить
            this.Text = $"Меняем пользователя ID: {redact_id}";
            //Получаем значение новых данных из TextBox
            string new_fio = textBox2.Text;
            string new_sex = comboBox1.Text;
            string new_polis = maskedTextBox1.Text;
            string new_number_phone = maskedTextBox2.Text;
            string new_prichina_pribitia = textBox7.Text;
            // запрос обновления данных
            string query2 = $"UPDATE pasienti SET fio_pasient = '{new_fio}', birthday = @dateb, sex = '{new_sex}', polis = '{new_polis}'," +
                $" number_phone = '{new_number_phone}', prichina_pribitia  = '{new_prichina_pribitia}' WHERE id_pasient = {redact_id}";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query2, conn);
            // объект для выполнения SQL-запроса
            command.Parameters.Add("@dateb", MySqlDbType.Timestamp).Value = dateTimePicker1.Value;
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            conn.Close();
        }
    }

}
