using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace HMS
{
    public partial class FormStudentReg : Form
    {
        MySqlConnection connection;

        public FormStudentReg()
        {
            InitializeComponent();
            
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        private void FormStudentReg_Load(object sender, EventArgs e)
        {
            try
            {
                connection = new MySqlConnection(@"datasource=localhost;port=3306;username=root;password=;database=hospital");
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    label1.Text = "Connected";
                    label1.ForeColor = Color.Green;
                }
                else
                {
                    label1.Text = "Not Connected";
                    label1.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            dateTimePicker1.ResetText();
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO students(id,first_name,last_name,bday,address,tel,password) VALUES (@id,@fname,@lname,@bday,@address,@tel,@password)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",textBox2.Text );
                cmd.Parameters.AddWithValue("@fname", textBox3.Text);
                cmd.Parameters.AddWithValue("@lname", textBox4.Text);
                cmd.Parameters.AddWithValue("@tel", textBox1.Text);
                cmd.Parameters.AddWithValue("@address", textBox5.Text);
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@bday", theDate);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);

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
                MessageBox.Show("Student Added Succesfully");
                conn.Close();
            }
        }
    }
}
