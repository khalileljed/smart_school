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
    class Class_Equip
    {
        MySqlCommand cmd;
        MySqlConnection conn;

        public Class_Equip()
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

        public DataTable usp_tblEquipsSelect()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id", typeof(int));
            dt2.Columns.Add("code", typeof(int));
            dt2.Columns.Add("materiels", typeof(string));
            dt2.Columns.Add("consomable", typeof(string));
            dt2.Columns.Add("mission", typeof(string));
            dt2.Columns.Add("sec", typeof(string));
            dt2.Columns.Add("lieu", typeof(string));
            dt2.Columns.Add("duree", typeof(string));
            cmd.CommandText = "select * from equip ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    object[] o = { Convert.ToInt32(dr.GetValue(0)), Convert.ToInt32(dr.GetValue(1)), Convert.ToString(dr.GetValue(2)), Convert.ToString(dr.GetValue(3)), Convert.ToString(dr.GetValue(4)), Convert.ToString(dr.GetValue(5)), Convert.ToString(dr.GetValue(6)), Convert.ToString(dr.GetValue(7)) };
                    dt2.Rows.Add(o);

                }
            }
            return dt2;
        }
        public void usp_tblEquipInsert(string code, string materiels, string consomable,string mission , string sec, string lieu, string duree)
        {
            try
            {
                cmd.Parameters.Clear();

                conn = Connection.Connect();
                cmd.CommandText = "insert into equip(code, materiels, consomable,mission, sec, lieu, duree) values(?,?,?,?,?,?,?)";
                cmd.Parameters.Add("code", MySqlDbType.Int32).Value = code;
                cmd.Parameters.Add("materiels", MySqlDbType.VarChar).Value = materiels;
                cmd.Parameters.Add("consomable", MySqlDbType.VarChar).Value = consomable;
                cmd.Parameters.Add("mission", MySqlDbType.VarChar).Value = mission;
                cmd.Parameters.Add("sec", MySqlDbType.VarChar).Value = sec;
                cmd.Parameters.Add("lieu", MySqlDbType.VarChar).Value = lieu;
                cmd.Parameters.Add("duree", MySqlDbType.VarChar).Value = duree;

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public  void usp_tblEquipUpdate(string id , string code, string materiels, string consomable, string mission, string sec, string lieu, string duree)
        {
            conn = Connection.Connect();
            cmd.Connection = conn;
            cmd.Parameters.Clear();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE equip SET code= " + code + " , materiels ='" + materiels + "', consomable ='" + consomable + "' , mission = '" + mission + "' , sec= '" + sec + "' ,lieu = '" + lieu + "' , duree = '" + duree + "' WHERE id=" + id;


            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public  void usp_tblEquipDelete(string id)
        {
            conn = Connection.Connect();
            cmd.Connection = conn;

            cmd.CommandText = "delete from equip where id = " + id;
            cmd.ExecuteNonQuery();
        }
    }
}
