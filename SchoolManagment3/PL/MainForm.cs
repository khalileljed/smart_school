using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using SchoolManagment3.BL;
using System.Configuration;
using System.Data.SqlClient;

namespace SchoolManagment3.PL
{
    public partial class MainForm : MetroForm
    {
        public static bool check = false;
        public static int idPre = 0;
        public static string username;
        public MainForm()
        {
            InitializeComponent();

        }

        

       

        

        private void btnAddFilier_Click(object sender, EventArgs e)
        {
            new Form_addFiliere().ShowDialog();
        }

        private void loginpanel_Click(object sender, EventArgs e)
        {
            new Form_Login().ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {

            if (check == false)
            {
                Maintab.DisableTab(metroTabPage1);
            }
            else if (check == true)
            {
                if (idPre == 1)
                {
                    Maintab.EnableTab(metroTabPage1);
                    LogoutPanel.Enabled = true;
                    Pbackup.Enabled = false;
                    foreach (Control c in metroTabPage1.Controls)
                    {
                        if (c is Button)
                        {
                            c.Enabled = true;
                        }
                    }

                }
               
                else if (idPre == 0)
                {
                    Maintab.DisableTab(metroTabPage1);
                    LogoutPanel.Enabled = false;
                    Pbackup.Enabled = false;
                    username = null;
                    idPre = 0;
                    check = false;
                }
                
            }
        }

        

       

       

        

        
        private void btnUsersMan_Click(object sender, EventArgs e)
        {
            new Form_addMissions().ShowDialog();
        }


        private void LogoutPanel_Click(object sender, EventArgs e)
        {
            Maintab.DisableTab(metroTabPage1);
            LogoutPanel.Enabled = false;
            Pbackup.Enabled = false;
            username = null;
            idPre = 0;
            check = false;

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Server = {0}", txtIp.Text);
            SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(connectionString);

            // Supply the additional values.
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "ISETManagment";
            builder.DataSource = "DESKTOP-1TE5FKC";
            sqlHelper help = new sqlHelper(builder.ToString());
            try
            {
                if (help.IsConnection)
                {
                    MessageBox.Show("Connection Established", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Connection Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("server = {0}", txtIp.Text);
            SqlConnectionStringBuilder builder =
            new SqlConnectionStringBuilder(connectionString);

            // Supply the additional values.
            builder.IntegratedSecurity = true;
            builder.InitialCatalog = "ISETManagment";
            builder.DataSource = "DESKTOP-1TE5FKC";
            sqlHelper help = new sqlHelper(builder.ToString());
            try
            {
                if (help.IsConnection)
                {
                    AppSettings setting = new AppSettings();
                    setting.SaveConnectionString("partialConnectString", connectionString);
                    MessageBox.Show("Data Base is Saved", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void Pbackup_Click(object sender, EventArgs e)
        {
            try
            {
                string path = string.Format("{0}\\School-{1}{2}.bak", "C:\\Backup", DateTime.Now.ToShortDateString().Replace('/', '-'), DateTime.Now.ToShortTimeString().Replace(':', '-'));
                Class_Backup.usp_backup(path);
                MessageBox.Show("Backup Sucesfully Saved");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error in saving");
               // MessageBox.Show(ex.Message);
            }
        }

        private void btnStudentsManagment_Click(object sender, EventArgs e)
        {
            new Equip().ShowDialog();

        }
    }
}
