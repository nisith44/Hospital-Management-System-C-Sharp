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
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        string selected_type="students";

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void users_Load(object sender, EventArgs e)
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id AS StudentID,first_name AS FirstName,last_name AS LastName,bday AS BirthDay,address AS Address,tel AS Contact FROM students";
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
            selected_type = "students";
            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id AS StudentID,first_name AS FirstName,last_name AS LastName,bday AS BirthDay,address AS Address,tel AS Contact FROM students";
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
            selected_type = "doctor";
            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id AS DoctorID,first_name AS FirstName,last_name AS LastName,date AS appointedDate,address AS Address,tel AS Contact FROM doctor";
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

        private void button9_Click(object sender, EventArgs e)
        {
            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string key = textBox1.Text;
                string sql = "SELECT * FROM "+selected_type+" WHERE first_name LIKE '%"+key+"%' ";
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

        private void button3_Click(object sender, EventArgs e)
        {
            selected_type = "pharmasist";
            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id AS PharmasistID,first_name AS FirstName,last_name AS LastName,date AS BirthDay,address AS Address,tel AS Contact FROM pharmasist";
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

        private void button4_Click(object sender, EventArgs e)
        {
            selected_type = "admin";
            
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id AS AdminID,first_name AS FirstName,last_name AS LastName,date AS appointedDate,address AS Address,tel AS Contact FROM admin";
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
        string selected_user_id;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            selected_user_id= dataGridView1.Rows[row].Cells[0].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            try
            {
                string sql = "DELETE FROM "+selected_type+" WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", selected_user_id);
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
                MessageBox.Show("User Deleted successfully");

                //reload
                DataTable dt = new DataTable();
                try
                {
                    string sql="";
                    if (selected_type == "students")
                    {
                         sql = "SELECT id AS UserID,first_name AS FirstName,last_name AS LastName,bday AS BirthDay,address AS Address,tel AS Contact FROM " + selected_type;
                    }
                    else
                    {
                         sql = "SELECT id AS UserID,first_name AS FirstName,last_name AS LastName,date AS BirthDay,address AS Address,tel AS Contact FROM " + selected_type;
                    }
                    
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
