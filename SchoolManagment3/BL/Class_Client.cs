using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagment3.DAL;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
namespace SchoolManagment3.BL
{
    class Class_Client
    {

        MySqlCommand cmd;
        MySqlConnection conn;

        public Class_Client()
        {
            conn = Connection.Connect();
            cmd = new MySqlCommand();
            cmd.Connection = conn;
        }
        public DataTable PS_SelectFiliere()
        {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("id", typeof(int));
            dt2.Columns.Add("nom", typeof(string));
            dt2.Columns.Add("mat", typeof(int));
            dt2.Columns.Add("adress", typeof(string));
            dt2.Columns.Add("email", typeof(string));
            dt2.Columns.Add("tell", typeof(int));
            dt2.Columns.Add("pres", typeof(string));
            dt2.Columns.Add("type", typeof(string));
            cmd.CommandText = "select * from clients ";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                  
                    object[] o = { Convert.ToInt32(dr.GetValue(0)), Convert.ToString(dr.GetValue(1)), Convert.ToInt32(dr.GetValue(2)), Convert.ToString(dr.GetValue(3)), Convert.ToString(dr.GetValue(4)), Convert.ToInt32(dr.GetValue(5)), Convert.ToString(dr.GetValue(6)), Convert.ToString(dr.GetValue(7)) };
                    dt2.Rows.Add(o);

                }
            }
            return dt2;
        }
        public void PS_InsertFiliere(string name, string mat, string adress, string email , string tell , string pres , string type)
        {
            cmd.Parameters.Clear();

            conn = Connection.Connect();
            cmd.CommandText = "insert into clients(nom,mat,adress,email,tell,pres,type) values(?,?,?,?,?,?,?)";
            cmd.Parameters.Add("nom", MySqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("mat", MySqlDbType.Int32).Value = mat;
            cmd.Parameters.Add("adress", MySqlDbType.VarChar).Value = adress;
            cmd.Parameters.Add("email", MySqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("tell", MySqlDbType.Int32).Value = tell;
            cmd.Parameters.Add("pres", MySqlDbType.VarChar).Value = pres;
            cmd.Parameters.Add("type", MySqlDbType.VarChar).Value = type;

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        public void PS_UpdateFiliere(string id, string name, string mat, string adress, string email, string tell, string pres, string type)
        {
            conn = Connection.Connect();
            cmd.Connection = conn;
            cmd.Parameters.Clear();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE clients SET nom= '" + name + "' , mat ="+mat+", adress ='"+adress+"' , email = '"+email+"' , tell= "+tell+" ,pres = '"+pres+"' , type = '"+type+"' WHERE id=" + id ;


            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
       
        }

        public void PS_RemoveFiliere(string id)
        {
            conn = Connection.Connect();
            cmd.Connection = conn;

            cmd.CommandText = "delete from clients where id = "+ id ;
            cmd.ExecuteNonQuery();
          
        }
    }
}
