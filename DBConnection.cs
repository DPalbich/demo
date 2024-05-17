using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Кафе2
{
    internal class DBConnection
    {
        static string DBconnect = "server = localhost; user=root; password=root;database=cafe";
        static public MySqlDataAdapter msDataAdapter;
        static MySqlConnection myconnect;
        static public MySqlCommand msCommand;

        public static bool ConnectionDB()
        {
            try
            {
                myconnect = new MySqlConnection(DBconnect);
                myconnect.Open();
                msCommand = new MySqlCommand();
                msCommand.Connection = myconnect;
                msDataAdapter = new MySqlDataAdapter(msCommand);
                return true;
            }
            catch
            {
                MessageBox.Show("error database");
                return false;
            }
        }

        public static void CloseDB()
        {
            myconnect.Close();
        }
        public MySqlConnection GetConnection()
        {
            return myconnect;
        }
    }

}
