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
    public partial class FormLogin : Form
    {
        
        public FormLogin()
        {
            InitializeComponent();
        }
        
        

        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";



        private void FormLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            //this_user_id = "ddd";
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
        string query = "";
            if (comboBox1.SelectedIndex == 0) {
                FormAdmin admin = new FormAdmin();
     
                MySqlConnection conn = new MySqlConnection(constring);
                DataTable dt1 = new DataTable();
                try
                {
                    string sql = "SELECT * FROM admin WHERE first_name='" + textBox1.Text + "' AND password='" + textBox2.Text + "' LIMIT 1  ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt1);
                    if (dt1.Rows.Count == 1)
                    {
                        admin.Show();
                        this.Hide();

                    }
                    else
                    {
                        label5.Text = "Invalid Username/Password";
                    }


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
            else if(comboBox1.SelectedIndex == 1) {
                FormDoctor doctor = new FormDoctor();
                MySqlConnection conn = new MySqlConnection(constring);
                DataTable dt1 = new DataTable();
                try
                {
                    string sql = "SELECT * FROM doctor WHERE first_name='" + textBox1.Text + "' AND password='" + textBox2.Text + "' LIMIT 1  ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt1);
                    if (dt1.Rows.Count == 1)
                    {
                        doctor.Show();
                        this.Hide();

                    }
                    else
                    {
                        label5.Text = "Invalid Username/Password";
                    }


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
            else if (comboBox1.SelectedIndex == 2)
            {
                FormPharmasist pharmasist = new FormPharmasist();
                MySqlConnection conn = new MySqlConnection(constring);
                DataTable dt1 = new DataTable();
                try
                {
                    string sql = "SELECT * FROM pharmasist WHERE first_name='" + textBox1.Text + "' AND password='" + textBox2.Text + "' LIMIT 1  ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt1);
                    if (dt1.Rows.Count == 1)
                    {
                        pharmasist.Show();
                        this.Hide();

                    }
                    else
                    {
                        label5.Text = "Invalid Username/Password";
                    }


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

            

            //student select
            else if (comboBox1.SelectedIndex == 3)
            {
                


                MySqlConnection con = new MySqlConnection(constring);

                string selectSql = "SELECT * FROM students WHERE first_name='" + textBox1.Text + "' AND password='" + textBox2.Text + "' LIMIT 1  ";
                MySqlCommand com = new MySqlCommand(selectSql, con);
                

                try
                {
                    con.Open();

                    using (MySqlDataReader read = com.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            label5.Text= (read["id"].ToString());
                            

                        }
                    }
                }
                finally
                {
                    con.Close();
                }

                



        query = "SELECT * FROM students WHERE first_name='"+textBox1.Text+"' AND password='"+textBox2.Text+"' LIMIT 1  ";

                
                MySqlConnection conn = new MySqlConnection(constring);
                DataTable dt1 = new DataTable();
                try
                {
                    string sql = "SELECT * FROM students WHERE first_name='" + textBox1.Text + "' AND password='" + textBox2.Text + "' LIMIT 1  ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt1);
                    if (dt1.Rows.Count == 1)
                    {
                        FormStudent student = new FormStudent(label5.Text);
                        student.Show();
                        this.Hide();
                        
                    }
                    else
                    {
                        label5.Text = "Invalid Username/Password";
                    }
                    

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
}
