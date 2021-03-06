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
    public partial class PatientINSERT : Form
    {
        public PatientINSERT()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        private void Form4_Load(object sender, EventArgs e)
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
            // строка подключения к БД
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_1;database=is_1_19_st1_KURS;password=97537091;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Объявляем переменные для вставки в БД
            string n_id_pasient = textBox7.Text;
            string n_fio = textBox1.Text;
            string n_birthday = dateTimePicker1.Value.ToString(string.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value)); 
            string n_sex = comboBox1.Text;
            string n_polis = maskedTextBox1.Text;
            string n_number = maskedTextBox2.Text;
            string n_diagnoz = textBox6.Text;
            //Конструкция, которая помогает добавлять данные в БД, а также ограничивая добавление, если строки пусты или недописанны до конца
            if (textBox1.Text == "" || comboBox1.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Добавить пациента не удалось!");
            }
            else
            {
                string ban1 = maskedTextBox1.Text;
                string ban2 = maskedTextBox2.Text;
                if(ban1.Length < 19 || ban2.Length < 11)
                {
                    MessageBox.Show("Вы ввели недостаточно символов");
                }
                else
                {
                    string sql_update_current_pasient = $"INSERT INTO pasienti (id_pasient, fio_pasient," +
                        $" birthday, sex, polis, number_phone, prichina_pribitia)" +
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
                }
            }
        }
    }
}
