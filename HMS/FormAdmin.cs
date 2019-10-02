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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        private void button1_Click(object sender, EventArgs e)
        {
            FormStudentReg studReg = new FormStudentReg();
            studReg.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            dateTimePicker1.ResetText();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            radioButton1.Checked = true;

            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment ORDER BY date,time";
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

        private void button2_Click(object sender, EventArgs e)
        {
            FormDoctorReg docReg = new FormDoctorReg();
            docReg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormPharmasistReg pharReg = new FormPharmasistReg();
            pharReg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormAdminReg adminReg = new FormAdminReg();
            adminReg.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormMedHistory medHistory = new FormMedHistory();
            medHistory.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string admin = "admin";
            FormInventory inventory = new FormInventory(admin);
            inventory.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            users us = new users();
            us.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO appointment(std_id,date,time,note,completed) VALUES (@std_id,@date,@time,@note,'no')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@std_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@note", textBox1.Text);
                
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@date", theDate);

                string hour = comboBox1.Text;
                string min = comboBox2.Text;
                string time = hour + ":" + min+":00";
                cmd.Parameters.AddWithValue("@time", time);



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
                MessageBox.Show("appointment added");
                conn.Close();

                MySqlConnection conn2 = new MySqlConnection(constring);
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT * FROM appointment";
                    MySqlCommand cmd = new MySqlCommand(sql, conn2);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn2.Open();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    conn2.Close();
                }
            }

        }
        string selected_item_id;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            selected_item_id = dataGridView1.Rows[row].Cells[0].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            try
            {
                string sql = "DELETE FROM appointment WHERE id=@id";
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
                MessageBox.Show("Appointment Deleted successfully");

                //reload
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT * FROM appointment";
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

        private void button11_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            textBox2.Text = today;

            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment WHERE date='"+today+"' ORDER BY time";
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
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment ORDER BY date,time";
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
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment WHERE completed='yes' ORDER BY date,time";
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

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment WHERE completed='no' ORDER BY date,time";
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

        private void button12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "UPDATE appointment SET completed='yes' WHERE id=@id";
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
                MessageBox.Show("Selected Appointment Mark As Completed Successfully");
            }

            //reload
            //MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment WHERE completed='no' ORDER BY date,time";
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

        private void button13_Click(object sender, EventArgs e)
        {
            feedback fb = new feedback();
            fb.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DrugIssue dg = new DrugIssue();
            dg.Show();
        }
    }
}
