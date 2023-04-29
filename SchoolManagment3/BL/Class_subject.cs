using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SchoolManagment3.DAL;

namespace SchoolManagment3.BL
{
    class Class_subject
    {
        public static DataTable Ps_GetFilierByNivau(int id)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetFilierByNivau", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id));
            return dt;
        }

        
        public static DataTable Ps_GetClassByFiliere(int id, int idYear)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetClassByFiliere", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id),
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));
            return dt;
        }
        public static DataTable Ps_GetUnityByClass(int id, int idYear)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetUnityByClass", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.BigInt, id),
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));
            return dt;
        }
        public static int PS_addSubject(/*int idSubject,*/string label, double vhg, double vhc,
            double vhtd, double vhtp, int credit, double coef, string regime, int idUnity, int idyear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_addSubject", CommandType.StoredProcedure,
               /* DataAccessLayer.CreateParameter("@idSubject", SqlDbType.Int, idSubject),*/
                DataAccessLayer.CreateParameter("@label", SqlDbType.NVarChar, label),
                DataAccessLayer.CreateParameter("@vhg", SqlDbType.Float, vhg),
                DataAccessLayer.CreateParameter("@vhc", SqlDbType.Float, vhc),
                DataAccessLayer.CreateParameter("@vhtd", SqlDbType.Float, vhtd),
                DataAccessLayer.CreateParameter("@vhtp", SqlDbType.Float, vhtp),
                DataAccessLayer.CreateParameter("@credit", SqlDbType.Int, credit),
                DataAccessLayer.CreateParameter("@coef", SqlDbType.Float, coef),
                DataAccessLayer.CreateParameter("@regime", SqlDbType.NVarChar, regime),
                DataAccessLayer.CreateParameter("@idUnity", SqlDbType.Int, idUnity),
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, idyear)
                );
            DataAccessLayer.Close();
            return count;
        }
        public static int PS_addPart(int idSubject,string username, int idyear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("PS_addPart", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idSubject", SqlDbType.Int, idSubject),
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, idyear)
                );
            DataAccessLayer.Close();
            return count;
        }
        public static int usp_tblSubjectUpdate(int idSubject, string label, double vhg, double vhc,
            double vhtd, double vhtp, int credit, double coef, string regime, int idUnity, int idyear)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblSubjectUpdate", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idSubject", SqlDbType.Int, idSubject),
                DataAccessLayer.CreateParameter("@label", SqlDbType.NVarChar, label),
                DataAccessLayer.CreateParameter("@vhg", SqlDbType.Float, vhg),
                DataAccessLayer.CreateParameter("@vhc", SqlDbType.Float, vhc),
                DataAccessLayer.CreateParameter("@vhtd", SqlDbType.Float, vhtd),
                DataAccessLayer.CreateParameter("@vhtp", SqlDbType.Float, vhtp),
                DataAccessLayer.CreateParameter("@credit", SqlDbType.Int, credit),
                DataAccessLayer.CreateParameter("@coef", SqlDbType.Float, coef),
                DataAccessLayer.CreateParameter("@regime", SqlDbType.NVarChar, regime),
                DataAccessLayer.CreateParameter("@idUnity", SqlDbType.Int, idUnity),
                DataAccessLayer.CreateParameter("@idyear", SqlDbType.BigInt, idyear)
                
                );
            DataAccessLayer.Close();
            return count;
        }

        public static int usp_tblPartDelete(int id)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblPartDelete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.NVarChar, id));
            DataAccessLayer.Close();
            return count;
        }
        public static int usp_tblSubjectDelete(int id)
        {
            DataAccessLayer.Open();
            int count = DataAccessLayer.ExecuteNonQuery("usp_tblSubjectDelete", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idSubject", SqlDbType.NVarChar, id));
            DataAccessLayer.Close();
            return count;
        }
        public static DataTable usp_tblSubjectSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblSubjectSelect", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable usp_tblPartSelect()
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblPartSelect", CommandType.StoredProcedure);
            return dt;
        }
        public static DataTable usp_tblPartSelectByUserSub(int id, string username,int idYear)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblPartSelectByUserSub", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idSubject", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
            DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));

            return dt;
        }
        public static DataTable usp_tblPartSelectByUser(string username, int idYear)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("usp_tblPartSelectByUser", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@username", SqlDbType.NVarChar, username),
            DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));

            return dt;
        }
        public static DataTable Usp_SearchSubjectbyClass(int classe)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Usp_SearchSubjectbyClass", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@idClass", SqlDbType.BigInt, classe));
            return dt;
        }

        public static DataTable Ps_GetSubByid(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetSubByid", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetSubByid2(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetSubByid2", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetCompRequi(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetCompRequi", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetContenu(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetContenu", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetCoRRTT(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetCoRRTT", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetMetRRTT(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetMetRRTT", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetPartCont(int number)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetPartCont", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, number));

            return dt;
        }
        public static DataTable Ps_GetSubByUnity(int id, int idYear)
        {
            DataTable dt = DataAccessLayer.ExecuteTable("Ps_GetSubByUnity", CommandType.StoredProcedure,
                DataAccessLayer.CreateParameter("@id", SqlDbType.Int, id),
                DataAccessLayer.CreateParameter("@idYear", SqlDbType.BigInt, idYear));
            return dt;
        }
    }
}
