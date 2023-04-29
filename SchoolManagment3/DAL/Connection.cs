using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SchoolManagment3.DAL
{
    public sealed class Connection
    {
        private static MySqlConnection conn;

        private Connection()
        {
        }
        public static MySqlConnection Connect()
        {
            if (conn == null)
            {

                conn = new MySqlConnection("Server=localhost;Database=smart_control;Uid=root;Pwd=");
                conn.Open();

            }
            else
            {
                conn.Close();
                conn.Open();
            }
            return conn;
        }

        public void Disconnect()
        {
            Connection.conn.Close();
            Connection.conn = null;
        }
    }
}
