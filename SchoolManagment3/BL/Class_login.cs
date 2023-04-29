using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagment3.DAL;
using System.Data;
using MySql.Data.MySqlClient;

namespace SchoolManagment3.BL
{
    public class Class_login
    {
        MySqlCommand cmd;
        MySqlConnection conn;
        public Class_login()
        {
            conn = Connection.Connect();
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }
        public DataTable usp_login(string username, string password)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = "select * from users where login = '"+ username + "' and password = '"+ password +"'" ; 
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    dt.Columns.Add("Id", typeof(int));
                    dt.Columns.Add("login", typeof(string));
                    dt.Columns.Add("password", typeof(string));
                    object[] o = { Convert.ToInt32(dr.GetValue(0)), Convert.ToString(dr.GetValue(1)), Convert.ToString(dr.GetValue(2)) };
                    dt.Rows.Add(o);

                }
            }
            return dt;
        }
    }
}
