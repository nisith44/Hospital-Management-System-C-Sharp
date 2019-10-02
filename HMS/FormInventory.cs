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
    public partial class FormInventory : Form
    {
        public FormInventory()
        {
            InitializeComponent();
        }

        public FormInventory(int doc)
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }
        public FormInventory(string admin)
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            textBox4.Enabled = false;
            textBox3.Enabled = false;
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";

        private void FormInventory_Load(object sender, EventArgs e)
        {
            radioButton3.Text = "Item No.";
            radioButton2.Text = "Name";
            radioButton1.Text = "Exp. Date";
            radioButton3.Checked = true;
            //button2.Enabled = false;
            //button1.Enabled = false;
            //comboBox1.Enabled = false;
            //textBox3.Enabled = false;

            
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug";
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
            textBox2.Enabled = true;
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;

        
    }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox1.Enabled = true;
            dateTimePicker1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (radioButton3.Checked == true)
            {
                sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug WHERE id='" + textBox2.Text + "' ";
            }
            if (radioButton2.Checked == true)
            {
                sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug WHERE name LIKE '%" + textBox1.Text + "%' ";
            }
            if (radioButton1.Checked == true)
            {
                string theDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug WHERE exp LIKE '%" + theDate + "%' ";
            }


            string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";
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

        string old_qty="";
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con1 = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            con1.Open();
            MySqlDataReader myReader = null;
            MySqlCommand myCommand = new MySqlCommand("select * from drug where id='" + textBox4.Text + "'  ", con1);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                
                old_qty = (myReader["qty"].ToString());
                
            }
            con1.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int int_old_qty = Int32.Parse(old_qty);
            int int_new_qty= Int32.Parse(textBox3.Text);
            int total = int_new_qty + int_old_qty;

            MySqlConnection conn = new MySqlConnection(constring);

            try
            {
                string sql = "UPDATE drug SET qty=@qty WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qty", total);
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
              


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
        string selected_item_id;
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            selected_item_id = dataGridView1.Rows[row].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            try
            {
                string sql = "DELETE FROM drug WHERE id=@id";
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
                MessageBox.Show("Drug Deleted successfully");

                //reload
                DataTable dt = new DataTable();
                try
                {
                    string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty,unit FROM drug";
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
}
