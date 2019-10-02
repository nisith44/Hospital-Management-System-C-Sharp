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
    public partial class FormMedHistory : Form
    {
        string sql;
        public FormMedHistory()
        {
            
            InitializeComponent();
            button2.Visible = false;
            sql = "SELECT std_id,std_name,diagnostic,drug,date FROM medical_history";
        }

        public FormMedHistory(string std_id)
        {
           
            InitializeComponent();
            button1.Enabled = false;
            button2.Visible = false;
            sql = "SELECT std_id,std_name,diagnostic,drug,date FROM medical_history WHERE std_id='"+std_id+"' ";
        }

        public FormMedHistory(int doc)
        {
            InitializeComponent();
            button2.Visible = false;
            button1.Enabled = false;
            sql = "SELECT std_id,std_name,diagnostic,drug,date FROM medical_history";
        }

        public FormMedHistory(double pha)
        {
            
            InitializeComponent();
            button1.Enabled = false;
            sql = "SELECT std_id,std_name,diagnostic,drug,date FROM medical_history";
        }

        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        private void FormMedHistory_Load(object sender, EventArgs e)
        {
            radioButton1.Text = "Student";
            radioButton2.Text = "Date";
            radioButton3.Text = "All";
            radioButton3.Checked = true;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;

            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            dateTimePicker1.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string selected_item_id;
        string std_id, drugs;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            selected_item_id = dataGridView1.Rows[row].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();

            std_id= dataGridView1.Rows[row].Cells[0].Value.ToString();
            drugs= dataGridView1.Rows[row].Cells[3].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (radioButton1.Checked == true)
            {
                sql = "SELECT * FROM medical_history WHERE std_id='" + textBox2.Text + "' ";
            }
            if (radioButton3.Checked == true)
            {
                sql = "SELECT * FROM medical_history ";
            }
            if (radioButton2.Checked == true)
            {
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                sql = "SELECT * FROM medical_history WHERE date LIKE '%" + theDate + "%' ";
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

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            try
            {
                string sql = "DELETE FROM medical_history WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selected_item_id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    //issuccess = true;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
                MessageBox.Show("Report Deleted successfully");

                //reload
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT * FROM medical_history";
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

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO drug_issue(Student_ID,Date,Drugs) VALUES (@Student_ID,@Date,@Drugs)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Student_ID",std_id);

                

                cmd.Parameters.AddWithValue("@Drugs", textBox3.Text);

                DateTime today = DateTime.Today;
                string theDate = today.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@Date", theDate);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex);
            }
            finally
            {
                MessageBox.Show("Drug Issued Successfully");
                conn.Close();
            }
        }
    }
}
