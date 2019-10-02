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
    public partial class FormStudent : Form
    {
        public FormStudent(string id)
        {
            InitializeComponent();
            textBox6.Text = id;
            textBox6.Enabled = false;
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        private void button5_Click(object sender, EventArgs e)
        {
            FormMedHistory medHistory = new FormMedHistory(textBox6.Text);
            medHistory.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void FormStudent_Load(object sender, EventArgs e)
        {
            FormLogin f = new FormLogin();
            //textBox6.Text = f.this_user_id;

            MySqlConnection con1 = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("select * from students where id='" + textBox6.Text + "'  ", con1);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                textBox13.Text = (myReader["first_name"].ToString());
                textBox12.Text = (myReader["last_name"].ToString());
                textBox11.Text = (myReader["address"].ToString());
                textBox10.Text = (myReader["tel"].ToString());
                string date= (myReader["bday"].ToString());
                DateTime myDate = myReader.GetDateTime("bday");
                dateTimePicker1.Value = myDate;


            }
            con1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "UPDATE students SET first_name=@first_name,last_name=@last_name,bday=@bday,address=@address,tel=@tel,password=@password WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id",textBox6.Text );
                cmd.Parameters.AddWithValue("@first_name", textBox13.Text);
                cmd.Parameters.AddWithValue("@last_name", textBox12.Text);
                cmd.Parameters.AddWithValue("@tel", textBox10.Text);
                cmd.Parameters.AddWithValue("@address", textBox11.Text);
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@bday",theDate );
                cmd.Parameters.AddWithValue("@password",textBox2.Text);

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
                MessageBox.Show("Your Profile updated Successfully");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO feedback(std_id,StudentName,message,date) VALUES (@std_id,@StudentName,@message,@date)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("@id", textBox2.Text);
                cmd.Parameters.AddWithValue("@std_id", textBox6.Text);
                cmd.Parameters.AddWithValue("@StudentName", textBox13.Text+" "+textBox12.Text);
                cmd.Parameters.AddWithValue("@message", textBox1.Text);
                
                string theDate = DateTime.Now.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@date", theDate);
                

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
                MessageBox.Show("Feedback Sent Succesfully");
                conn.Close();
            }
        }
    }
}
