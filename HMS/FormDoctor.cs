using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace HMS
{
    public partial class FormDoctor : Form
    {
        public FormDoctor()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        string selected_drug_id = "";
        string low_drug = "", exp_drug = "";
        string appointment = "no";

        private void FormDoctor_Load(object sender, EventArgs e)
        {
            textBox6.Text = "0";
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            comboBox1.SelectedIndex = 2;


           //appoinmenet
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt1 = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment ORDER BY date,time";
                MySqlCommand cmd1 = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd1);
                conn.Open();
                adapter.Fill(dt1);
                dataGridView2.DataSource = dt1;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }




            //Making Sql Connection
            MySqlConnection cn = new MySqlConnection(constring);
            //Setting Connection String Property
            //cn.ConnectionString = "data source = (local); initial catalog = TestDB; integrated security =sspi";
            //Opening Connection
            cn.Open();

            //Creating Sql Command
            MySqlCommand cmd = new MySqlCommand();
            //Creating String Variable for SQL Command CommandProperty
            string sqlQuery = "select name from drug";
            //Passing Query and Connection to the SQL Command
            cmd = new MySqlCommand(sqlQuery, cn);
            //Creating Sql Data Adapter
            MySqlDataAdapter dAdapter = new MySqlDataAdapter();
            //Creating Data Table
            DataTable dt = new DataTable();
            //Initializing SQL Data Adapter Command Property
            dAdapter.SelectCommand = cmd;
            //Filling Data Table
            dAdapter.Fill(dt);
            //Populating Combo Box from Data Table
            comboBox2.DataSource = dt;
            //Setting Combo Box ValueMember Property
            comboBox2.ValueMember = "name";
            //Setting Combo Box DisplayMember Property
            comboBox2.DisplayMember = "GenderType";




            //notification
            MySqlConnection con1 = new MySqlConnection(constring);
            //DataTable dt1 = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("SELECT COUNT(*) AS count FROM drug WHERE qty<20", con1);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                low_drug = (myReader["count"].ToString());
            }


            con1.Close();

            if (Int32.Parse(low_drug) > 0)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Low Drug notification";
                popup.ContentText = low_drug + " of Dugs are low in quantity";
                popup.Popup();// show 

                label11.Text = low_drug + " of Dugs are low in quantity\n";
            }


            //MySqlConnection con1 = new MySqlConnection(constring);
            //DataTable dt1 = new DataTable();
            con1.Open();
            MySqlDataReader myReader2 = null;
            MySqlCommand myCommand2 = new MySqlCommand("SELECT COUNT(*) AS count FROM drug WHERE exp<=CURDATE()", con1);

            myReader2 = myCommand2.ExecuteReader();

            while (myReader2.Read())
            {
                exp_drug = (myReader2["count"].ToString());
            }


            con1.Close();

            if (Int32.Parse(exp_drug) > 0)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.TitleText = "Expired Drug notification";
                popup.ContentText = exp_drug + " of Dugs are Expired";
                popup.Popup();// show 

                label15.Text = exp_drug + " of Dugs are Expired";
            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            int doc = 1;
            FormMedHistory medHistory = new FormMedHistory(doc);
            medHistory.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int doc = 1;
            FormInventory inventory = new FormInventory(doc);
            inventory.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(comboBox2.Text,comboBox1.Text,textBox6.Text);
            /*
            int qty = Int32.Parse(textBox6.Text);
            int av_qty= Int32.Parse(textBox7.Text);
            int total = av_qty - qty;
            textBox7.Text = total.ToString();

            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "UPDATE drug SET qty=@qty WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qty", total);
                cmd.Parameters.AddWithValue("@id", selected_drug_id);


                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            } */
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string textToPrint="";
            for (int row = 0; row < dataGridView1.Rows.Count; row++)
            {
                textToPrint = textToPrint +
                dataGridView1.Rows[row].Cells[0].Value + "\t" +
                dataGridView1.Rows[row].Cells[1].Value+ "\t" +
                dataGridView1.Rows[row].Cells[2].Value + Environment.NewLine;
                textBox1.Text = textToPrint;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO medical_history(std_id,std_name,diagnostic,drug,date) VALUES (@std_id,@std_name,@diagnostic,@drug,@date)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@std_id", textBox2.Text);
                cmd.Parameters.AddWithValue("@std_name", textBox3.Text);
                cmd.Parameters.AddWithValue("@diagnostic", textBox1.Text);

                string textToPrint = "";
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    textToPrint = textToPrint +
                    dataGridView1.Rows[row].Cells[0].Value + "\t" +
                    dataGridView1.Rows[row].Cells[1].Value + "\t" +
                    dataGridView1.Rows[row].Cells[2].Value + Environment.NewLine;
                    
                }

                cmd.Parameters.AddWithValue("@drug",textToPrint);
                
                DateTime today = DateTime.Today;
                string theDate = today.ToString("yyyy-MM-dd");
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
                MessageBox.Show("Medical report added");
                conn.Close();
            }

            if (appointment == "yes")
            {
                //appointment mark as completed


                try
                {
                    string sql = "UPDATE appointment SET completed='yes' WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id", selected_appo_id);



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

                //relod
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT * FROM appointment WHERE completed='no' ORDER BY date,time";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    conn.Open();
                    adapter.Fill(dt);
                    dataGridView2.DataSource = dt;

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

        private void button7_Click(object sender, EventArgs e)
        {
            Warning wrn = new Warning();
            wrn.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Warning wrn = new Warning();
            wrn.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Warning wrn = new Warning();
            wrn.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("select * from students where id='" + textBox2.Text + "'  ", con1);

            myReader = myCommand.ExecuteReader();
            string fname="", lname="";
            while (myReader.Read())
            {
                fname = (myReader["first_name"].ToString());
                lname= (myReader["last_name"].ToString());
                
            }
            textBox3.Text = fname + " " + lname;
            con1.Close();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click_2(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            feedback fb = new feedback();
            fb.Show();
        }
        string selected_item_id;
        string selected_appo_id;
        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            selected_item_id = dataGridView2.Rows[row].Cells[1].Value.ToString();
            selected_appo_id = dataGridView2.Rows[row].Cells[0].Value.ToString();
            textBox2.Text = selected_item_id;
            appointment = "yes";

            MySqlConnection con1 = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("select * from students where id='" + selected_item_id + "'  ", con1);

            myReader = myCommand.ExecuteReader();
            string fname = "", lname = "";
            while (myReader.Read())
            {
                fname = (myReader["first_name"].ToString());
                lname = (myReader["last_name"].ToString());

            }
            textBox3.Text = fname + " " + lname;
            con1.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            //textBox2.Text = today;

            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM appointment WHERE date='" + today + "' ORDER BY time";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                dataGridView2.DataSource = dt;

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
                dataGridView2.DataSource = dt;

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
                dataGridView2.DataSource = dt;

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
                dataGridView2.DataSource = dt;

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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("select DATE_FORMAT(exp, '%Y-%m-%d') exp1,qty,id from drug where name='" + comboBox2.Text+"'  ", con1);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                textBox5.Text = (myReader["exp1"].ToString()).Substring(0, 10);
                
                textBox7.Text = (myReader["qty"].ToString());
                selected_drug_id= (myReader["id"].ToString());
                int qty_int = Int32.Parse(textBox7.Text);
                if (qty_int < 10) { label16.Text = "Low"; } else { label16.Text = " "; }
                
                DateTime myDate = DateTime.ParseExact(textBox5.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

                DateTime today = DateTime.Now;
                if(myDate<today) { label17.Text = "Expired"; } else { label17.Text = " "; }

            }
            con1.Close();
            
        }
    }
}
