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
    public partial class Equip : MetroForm
    {
        public Equip()
        {
            InitializeComponent();
        }
        private void loadData()
        {

            Class_Equip ce = new Class_Equip();
            DataTable dt = ce.usp_tblEquipsSelect();
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
                Class_Equip cf = new Class_Equip();

                cf.usp_tblEquipInsert(txtcode.Text, txtmateriel.Text, txtconso.Text, txtmission.Text, txtsec.Text,txtlieu.Text, txtduree.Text);
                MessageBox.Show("The Client has been successfully added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
                Clear();
            }
            catch (Exception ex)
            {

            }
        }

        private void Equip_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();

            txtcode.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtmateriel.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtconso.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtmission.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtsec.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtlieu.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtduree.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

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


                Class_Equip cu = new Class_Equip();
                cu.usp_tblEquipUpdate(dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), txtcode.Text, txtmateriel.Text, txtconso.Text, txtmission.Text, txtsec.Text, txtlieu.Text, txtduree.Text);
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

                DialogResult dr = MessageBox.Show("Do you Wanna really Delete this Equipement ?", "Wait", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    Class_Equip cu = new Class_Equip();
                    cu.usp_tblEquipDelete(id);
                    MessageBox.Show("Equipement has been deleted");
                    loadData();
                    Clear();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Equipement Cannot be deleted");
            }
        }
    }
}
