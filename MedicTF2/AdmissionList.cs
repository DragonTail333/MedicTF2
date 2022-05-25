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
    public partial class AdmissionList : Form
    {
        public AdmissionList()
        {
            InitializeComponent();
        }
        //Переменная соединения
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        //Переменная для ID записи в БД, выбранной в гриде. Пока она не содердит значения, лучше его инициализировать с 0
        //что бы в БД не отправлялся null
        public static string id_selected_rows = "0";

        public void GetListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = "SELECT id AS 'Код', id_vrach AS 'Код врача', id_pasient AS 'Код пациента', " +
                "id_palata AS 'Код палаты', id_koika AS 'Код койки', date_prebitia AS 'Дата пребытия'," +
                "date_lechit AS 'Дата лечение', date_vipiski AS 'Дата выписки' FROM stasionar";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
            //Отражаем количество записей в ДатаГриде
            int count_rows = dataGridView1.RowCount - 1;
            toolStripLabel2.Text = (count_rows).ToString();
        }
        public void reload_list()
        {
            //Чистим виртуальную таблицу
            table.Clear();
            //Вызываем метод получения записей, который вновь заполнит таблицу
            GetListUsers();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            //делает toolStrip прозрачным
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_19_1;database=is_1_19_st1_KURS;password=97537091;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод для заполнение дата Грида
            GetListUsers();
            //Видимость полей в гриде
            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[7].Visible = true;
            //Ширина полей
            dataGridView1.Columns[0].FillWeight = 5;
            dataGridView1.Columns[1].FillWeight = 25;
            dataGridView1.Columns[2].FillWeight = 12;
            dataGridView1.Columns[3].FillWeight = 13;
            dataGridView1.Columns[4].FillWeight = 17;
            dataGridView1.Columns[5].FillWeight = 14;
            dataGridView1.Columns[6].FillWeight = 15;
            dataGridView1.Columns[7].FillWeight = 15;
            //Режим для полей "Только для чтения"
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[6].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            //Растягивание полей грида
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //Убираем заголовки строк
            dataGridView1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Метод обновления dataGridView
            reload_list();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Тестим вывод ID выбранной строки в MessageBox
            MessageBox.Show("Содержимое поля Код, в выбранной строке" + id_selected_rows);
            //Формируем запрос на удаление из БД на основании полученного ID записи в БД
            MessageBox.Show("DELETE FROM stasionar WHERE id=" + id_selected_rows);
            //В данной кнопке, вы можете вызвать метод удаления строки и в качестве
            //параметра передать ему переменную id_selected_rows в которой хранится
            //id записи в БД для удаления. Аналогично, вы можете изменить любую строку
            //так же, передав в качестве параметра данную переменную
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            AdmissionUPDATE Form = new AdmissionUPDATE();
            Form.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AdmissionINSERT Form = new AdmissionINSERT();
            Form.ShowDialog();
        }
    }
}
