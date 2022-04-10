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
    public partial class Doctorinfo : Form
    {
        public Doctorinfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        MySqlConnection conn;
        private void Doctorinfo_Load(object sender, EventArgs e)
        {
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_1;database=is_1_19_st1_KURS;password=97537091;"; 
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Открываем соединение
            conn.Open();

            //Меняем на форме название, с указанием того контакта, которого хотим изменить
            this.Text = $"Информация ID: {infodoc.doctor_id}";
            //Объявляем запрос на вывод данных из таблицы в поля
            string sql_select_current_contact = $"SELECT id_vrach, fio_vrach, nphone_vrach, spes, graficworks FROM vrachi" +
                $" WHERE id_vrach = '{infodoc.doctor_id}' ;";
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(sql_select_current_contact, conn);
            // объект для чтения ответа сервера
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                label6.Text = reader[1].ToString();
                label7.Text = reader[2].ToString();
                label8.Text = reader[3].ToString();
                label9.Text = reader[4].ToString();

            }
            reader.Close(); // закрываем reader
            // закрываем соединение с БД
            conn.Close();
        }
    }
}
