using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HMS
{
    public partial class DrugIssue : Form
    {
        public DrugIssue()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        private void DrugIssue_Load(object sender, EventArgs e)
        {
            radioButton3.Checked = true;

            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM drug_issue";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }




        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            textBox3.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = false;
            textBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (radioButton3.Checked == true)
            {
                sql = "SELECT * FROM drug_issue WHERE Student_ID='"+textBox1.Text+"'  ";
            }
            if (radioButton2.Checked == true)
            {
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                sql = "SELECT * FROM drug_issue WHERE Date LIKE '%" + theDate + "%' ";
            }

            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            button8.Enabled = false;

            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM drug_issue";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
