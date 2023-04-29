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
using System.Data.SqlClient;
using SchoolManagment3.BL;

namespace SchoolManagment3.PL
{
    public partial class Form_addFiliere : MetroForm
    {
        public Form_addFiliere()
        {
            InitializeComponent();

        }

        string user;
        private void loadData()
        {
            cmbPres.Items.Add("CND");
            cmbPres.Items.Add("CRS");
            cmbPres.Items.Add("Exp Tech");

            Class_Client cf = new Class_Client();
            DataTable dt = cf.PS_SelectFiliere();
            dataGridView1.DataSource = dt;
        }

        private void Clear()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
        }
      



        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Mission.usp_searchUsr(txtSearch.Text);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            user = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            txtname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtmat.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtadress.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txttel.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txttype.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void Form_addFiliere_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c == txtadress)
                    {
                        continue;
                    }
                    if (c.Text == "")
                    {
                        MessageBox.Show("Please Fill all the Blanks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }

            try
            {
                Class_Client cf = new Class_Client();
                cmbPres.BindingContext = new BindingContext();

                cf.PS_InsertFiliere(txtname.Text, txtmat.Text, txtadress.Text, txtemail.Text, txttel.Text, Convert.ToString(cmbPres.SelectedItem), txttype.Text);
                MessageBox.Show("The Client has been successfully added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                Clear();
                foreach (Control c in groupBox1.Controls)
                {
                    if (c is TextBox)
                    {
                        c.Text = "";
                    }
                }
                DataTable dt = cf.PS_SelectFiliere();

                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            try
            {
                string cl =  dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                
                DialogResult dr = MessageBox.Show("Do you Wanna really Delete this Client ?", "Wait", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Client cf = new Class_Client();
                    cf.PS_RemoveFiliere(cl);
                    MessageBox.Show("Client has been deleted");
                    loadData();
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Client Cannot be deleted");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    
                    if (c.Text == "")
                    {
                        MessageBox.Show("Please Fill all the Blanks", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                }
            }

            try
            {

                Class_Client cf = new Class_Client();
                string cl = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                cf.PS_UpdateFiliere(cl,txtname.Text, txtmat.Text, txtadress.Text, txtemail.Text, txttel.Text, Convert.ToString(cmbPres.SelectedItem), txttype.Text);
                MessageBox.Show("Successfully Updated");
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

                //
            }
        }
    }
}
