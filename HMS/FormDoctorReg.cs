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
    public partial class FormDoctorReg : Form
    {
        public FormDoctorReg()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

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
                string sql = "INSERT INTO doctor(id,first_name,last_name,date,address,tel,password) VALUES (@id,@fname,@lname,@date,@address,@tel,@password)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", textBox2.Text);
                cmd.Parameters.AddWithValue("@fname", textBox3.Text);
                cmd.Parameters.AddWithValue("@lname", textBox4.Text);
                cmd.Parameters.AddWithValue("@tel", textBox1.Text);
                cmd.Parameters.AddWithValue("@address", textBox5.Text);
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@date", theDate);
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
                MessageBox.Show("Doctor Added Succesfully");
                conn.Close();
            }
        }
    }
}
