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
    public partial class Warning : Form
    {
        public Warning()
        {
            InitializeComponent();
        }
        string constring = "datasource=localhost;port=3306;username=root;password=;database=hospital";


        private void Warning_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty FROM drug WHERE qty<20";
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



            //MySqlConnection conn = new MySqlConnection(constring);
            DataTable dt1 = new DataTable();
            try
            {
                string sql = "SELECT id,name,exp AS ExpiryDate,qty AS AvailableQty FROM drug WHERE exp<=CURDATE()";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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

        private void button5_Click(object sender, EventArgs e)
        {
            FormInventory fi = new FormInventory();
            fi.Show();
        }
    }
}
