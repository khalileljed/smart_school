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
    public partial class Form_addMissions : MetroForm
    {
        public Form_addMissions()
        {
            InitializeComponent();
        }
        string user;
        private void loadData()
        {
            cmbtrans.Items.Add("Voiture");
            cmbtrans.Items.Add("Train");
            cmbtrans.Items.Add("Avion");
            Class_Mission cu = new Class_Mission();
            DataTable dt = cu.usp_tblUsersSelect();
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
       

        private void Form_addNewUsers_Load(object sender, EventArgs e)
        {
           loadData();
        }

        

        private void btnAdd_Click(object sender, EventArgs e)
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
                Class_Mission cu = new Class_Mission();
                cu.usp_tblUsersInsert(code.Text, txttype.Text,txtchar.Text, txtProjet.Text, txtlieu.Text,txtduree.Text, depart.Text,arrivé.Text, Convert.ToString(cmbtrans.SelectedItem) , mat.Text);
                MessageBox.Show("The Mission has been successfully added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

                MessageBox.Show("You Cannot Add this Mission, it may be exist : "+ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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


                Class_Mission cu = new Class_Mission();
              cu.usp_tblUsersUpdate(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(),code.Text, txttype.Text, txtchar.Text, txtProjet.Text, txtlieu.Text, txtduree.Text, depart.Text, arrivé.Text, Convert.ToString(cmbtrans.SelectedItem), mat.Text);
                MessageBox.Show("Successfully Updated");
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

                //
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                
                DialogResult dr = MessageBox.Show("Do you Wanna really Delete this Mission ?", "Wait", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Mission cu = new Class_Mission();
                    cu.usp_tblUsersDelete(id);
                    MessageBox.Show("Misison has been deleted");
                    loadData();
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Mission Cannot be deleted");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = Class_Mission.usp_searchUsr(txtSearch.Text);
            dataGridView1.DataSource = dt;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            user = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            code.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txttype.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtchar.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtProjet.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtlieu.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtduree.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            mat.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
        }
    }
}
