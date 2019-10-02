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
    public partial class FormPharmasist : Form
    {
        public FormPharmasist()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
        string selected_drug_id;

        private void button1_Click(object sender, EventArgs e)
        {

        }
        string low_drug="", exp_drug="";

        private void FormPharmasist_Load(object sender, EventArgs e)
        {
            comboBox6.SelectedIndex = 2;
            textBox5.Enabled = false;
            textBox2.Enabled = false;
            comboBox5.SelectedIndex = 0;


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
            comboBox4.DataSource = dt;
            //Setting Combo Box ValueMember Property
            comboBox4.ValueMember = "name";
            //Setting Combo Box DisplayMember Property
            comboBox4.DisplayMember = "GenderType";







            comboBox3.Enabled = false;
            //string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt1 = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug";
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
            FormInventory inventory = new FormInventory();
            inventory.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO drug(name,exp,qty,unit) VALUES (@name,@exp,@qty,@unit)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", comboBox2.Text);
                cmd.Parameters.AddWithValue("@qty", textBox7.Text);
                cmd.Parameters.AddWithValue("@unit", comboBox5.Text);

                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@exp", theDate);
                

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
                MessageBox.Show("New Drug Added Succesfully");
                conn.Close();
            }


           //reload 
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug";
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

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            comboBox1.Text = dataGridView2.Rows[row].Cells[1].Value.ToString();
            comboBox3.Text = dataGridView2.Rows[row].Cells[0].Value.ToString();
            string date= dataGridView2.Rows[row].Cells[2].Value.ToString();
            DateTime d=DateTime.Parse(date);
            dateTimePicker2.Value = d;
            textBox1.Text = dataGridView2.Rows[row].Cells[3].Value.ToString();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "UPDATE drug SET name=@name,exp=@exp,qty=@qty WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qty",textBox1.Text );
                cmd.Parameters.AddWithValue("@name",comboBox1.Text);
                cmd.Parameters.AddWithValue("@id", comboBox3.Text);
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("@exp", theDate);


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
                MessageBox.Show("Drug Updated Successfully");
            }


            //reload 
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug";
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("select DATE_FORMAT(exp, '%Y-%m-%d') exp1,qty,id from drug where name='" + comboBox4.Text + "'  ", con1);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                textBox5.Text = (myReader["exp1"].ToString()).Substring(0,10);
                textBox2.Text = (myReader["qty"].ToString());
                selected_drug_id = (myReader["id"].ToString());

                int qty_int = Int32.Parse(textBox2.Text);
                if (qty_int < 10) { label22.Text = "Low"; } else { label22.Text = " "; }

                DateTime myDate = DateTime.ParseExact(textBox5.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

                DateTime today = DateTime.Now;
                if (myDate < today) { label21.Text = "Expired"; } else { label21.Text = " "; }

            }
            con1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Add(comboBox4.Text, comboBox6.Text, textBox6.Text);

            int dos=3 ;
            if (comboBox6.SelectedIndex == 0)
            {
                dos = 1;
            }
            if (comboBox6.SelectedIndex == 1)
            {
                dos = 4;
            }
            if (comboBox6.SelectedIndex == 2)
            {
                dos = 3;
            }
            if (comboBox6.SelectedIndex == 3)
            {
                dos = 2;
            }
            if (comboBox6.SelectedIndex == 4)
            {
                dos = 1;
            }

            int days1 = Int32.Parse(textBox6.Text);
            int total_drug_qty = dos * days1;

            int qty = Int32.Parse(textBox6.Text);
            int av_qty = Int32.Parse(textBox2.Text);
            int total = av_qty - total_drug_qty;
            textBox2.Text = total.ToString();
            

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
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.RemoveAt(item.Index);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "INSERT INTO drug_issue(Student_ID,Date,Drugs) VALUES (@Student_ID,@Date,@Drugs)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                
                cmd.Parameters.AddWithValue("@Student_ID", textBox3.Text);
              
                string textToPrint = "";
                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    textToPrint = textToPrint +
                    dataGridView1.Rows[row].Cells[0].Value + "\t" +
                    dataGridView1.Rows[row].Cells[1].Value + "\t" +
                    dataGridView1.Rows[row].Cells[2].Value + Environment.NewLine;

                }

                cmd.Parameters.AddWithValue("@Drugs", textToPrint);

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



            

            //reload
            //MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt1 = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug";
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
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DrugIssue dg = new DrugIssue();
            dg.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            double pha = 2;
            FormMedHistory medHistory = new FormMedHistory(pha);
            medHistory.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Warning wrn = new Warning();
            wrn.Show();
        }
    }
}
