using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Кафе2
{
    public partial class AuthorizationForm : Form
    {
        static public string loginActive;
        static public string whois;
        public AuthorizationForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_login.Text != "" && textBox_password.Text != "")
            {
                Authorization.Authorization1(textBox_login.Text, textBox_password.Text);
                switch(Authorization.Role)
                {
                    case null:
                        {
                            MessageBox.Show("Такого аккаунта не существует");
                            break;
                        }
                    case "Администратор":
                        {
                            loginActive = textBox_login.Text;
                            whois = "Администратор";
                            Authorization.User = textBox_login.Text;

                            string familia = Authorization.AuthorizationName(textBox_login.Text);
                            Authorization.familia = familia;
                            MessageBox.Show("Успешно! Админ");
                            this.Hide();
                            AdminForm admin = new AdminForm();
                            admin.Show();
                            break;
                        }
                    case "Повар":
                        {
                            loginActive = textBox_login.Text;
                            whois = "Повар";
                            Authorization.User = textBox_login.Text;

                            string familia = Authorization.AuthorizationName(textBox_login.Text);
                            Authorization.familia = familia;
                            MessageBox.Show("Успешно! Повар");
                            this.Hide();
                            cookForm cook = new cookForm();
                            cook.Show();
                            break;
                        }
                }

            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {
            DBConnection.ConnectionDB();
        }
    }
}
