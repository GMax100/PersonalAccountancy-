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
namespace UserInterfase
{
    public partial class Authorisate : Form
    {
        public Authorisate()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;database=bugalteria;password=root;";
            // объект для установления соединения с БД
            MySqlConnection connection = new MySqlConnection(connectionString);
            // открываем соединение
            connection.Open();
            // запросы
            // запрос вставки данных
            
            // объект для выполнения SQL-запроса
            MySqlCommand command = new MySqlCommand(query, connection);
            // выполняем запрос
            command.ExecuteNonQuery();
            // закрываем подключение к БД
            connection.Close();
        }
    }
}
