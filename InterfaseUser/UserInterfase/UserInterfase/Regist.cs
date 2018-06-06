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
    public partial class Regist : Form
    {
        public Regist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myConnectionString = "Database=accouting76;Data Source= 85.10.205.173;User Id=roouting12;Port= 3306;Password=Qw123456789";
            // объект для установления соединения с БД
            MySqlConnection connection = new MySqlConnection(myConnectionString);
            // открываем соединение
            connection.Open();
            // запросы
            string query = "SELECT COUNT(*) FROM user WHERE name='" + txtUserReg.Text + "' and password='" + txtPassReg.Text + "'";
            DataTable dt = new DataTable();
            // объект для выполнения SQL-запроса
            MySqlDataAdapter command = new MySqlDataAdapter(query, connection);
            command.Fill(dt);
            int count = Convert.ToInt32(dt.Rows[0][0].ToString());

            if (count == 1)
                MessageBox.Show("Вы уже есть там!", "User not found!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                MessageBox.Show("Щас зарегаем вас ", "Hello!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string inst = "INSERT INT0(*)  user WHERE name='" + txtUserReg.Text + "' and password='" + txtPassReg.Text + "'";
                MySqlDataAdapter comman = new MySqlDataAdapter(inst, connection);

            }
        }
    }
}
