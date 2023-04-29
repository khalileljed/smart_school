using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagment3.DAL;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;

namespace SchoolManagment3.BL
{
    class Class_Mission
    {
        MySqlCommand cmd;
        MySqlConnection conn;

        public Class_Mission()
        {
            conn = Connection.Connect();
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }
        

        public static DataTable usp_getNameOfUsers()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_getNameOfUsers", CommandType.StoredProcedure);
            return dt;
        }

        
        
        

        public static DataTable usp_searchUsr(string search)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_searchUsr", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@search", SqlDbType.NVarChar, search));
            return dt;
        }

        public DataTable usp_tblUsersSelect()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id", typeof(int));
            dt2.Columns.Add("code", typeof(int));
            dt2.Columns.Add("type", typeof(string));
            dt2.Columns.Add("charge", typeof(string));
            dt2.Columns.Add("projet", typeof(string));
            dt2.Columns.Add("lieu", typeof(string));
            dt2.Columns.Add("duree", typeof(string));
            dt2.Columns.Add("depart", typeof(DateTime));
            dt2.Columns.Add("arrivee", typeof(DateTime));
            dt2.Columns.Add("trans", typeof(string));
            dt2.Columns.Add("mat", typeof(int));
            cmd.CommandText = "select * from missions ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    object[] o = { Convert.ToInt32(dr.GetValue(0)), Convert.ToInt32(dr.GetValue(1)), Convert.ToString(dr.GetValue(2)), Convert.ToString(dr.GetValue(3)), Convert.ToString(dr.GetValue(4)), Convert.ToString(dr.GetValue(5)), Convert.ToString(dr.GetValue(6)), Convert.ToDateTime(dr.GetValue(7)), Convert.ToDateTime(dr.GetValue(8)), Convert.ToString(dr.GetValue(9)), Convert.ToInt32(dr.GetValue(10)) };
                    dt2.Rows.Add(o);

                }
            }
            return dt2;
        }
        public void usp_tblUsersInsert(string code, string type, string charge, string projet, string lieu, string duree, string depart, string arrivee, string trans, string mat)
        {
            try
            {
                cmd.Parameters.Clear();

                conn = Connection.Connect();
                cmd.CommandText = "insert into missions(code, type, charge, projet, lieu, duree, depart, arrivee, trans, mat) values(?,?,?,?,?,?,?,?,?,?)";
                cmd.Parameters.Add("code", MySqlDbType.Int32).Value = code;
                cmd.Parameters.Add("type", MySqlDbType.VarChar).Value = type;
                cmd.Parameters.Add("charge", MySqlDbType.VarChar).Value = charge;
                cmd.Parameters.Add("projet", MySqlDbType.VarChar).Value = projet;
                cmd.Parameters.Add("lieu", MySqlDbType.VarChar).Value = lieu;
                cmd.Parameters.Add("duree", MySqlDbType.VarChar).Value = duree;
                cmd.Parameters.Add("depart", MySqlDbType.VarChar).Value = depart;
                cmd.Parameters.Add("arrivee", MySqlDbType.VarChar).Value = arrivee;
                cmd.Parameters.Add("trans", MySqlDbType.VarChar).Value = trans;
                cmd.Parameters.Add("mat", MySqlDbType.Int32).Value = mat;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public  void usp_tblUsersUpdate(string id ,string code, string type, string charge, string projet, string lieu, string duree, string depart, string arrivee, string trans, string mat)
        {
            conn = Connection.Connect();
            cmd.Connection = conn;
            cmd.Parameters.Clear();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE missions SET code= " + code + " , type ='" + type + "', charge ='" + charge + "' , projet = '" + projet + "' , lieu= '" + lieu + "' ,duree = '" + duree + "' , depart = '" + depart + "' , arrivee = '"+ arrivee + "' , trans = '"+ trans + "' , mat = '"+ mat + "' WHERE id=" + id;


            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public  void usp_tblUsersDelete(string id)
        {
            conn = Connection.Connect();
            cmd.Connection = conn;

            cmd.CommandText = "delete from missions where id = " + id;
            cmd.ExecuteNonQuery();
        }
    }
}
