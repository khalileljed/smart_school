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

namespace SchoolManagment3.PL
{
    public partial class Form_Login : MetroForm
    {
        public Form_Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUserName.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please fill all the blanks");
                    return;
                }
                Class_login cl = new Class_login();
                DataTable dt = cl.usp_login(txtUserName.Text, txtPassword.Text);
                if (dt.Rows.Count == 1)
                {
                    MainForm.check = true;
                    MainForm.username = txtUserName.Text;
                    MainForm.idPre = Convert.ToInt32(dt.Rows[0][0].ToString());
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User name or Password is Wrong !!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
