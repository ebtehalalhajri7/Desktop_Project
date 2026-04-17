using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace project
{
    public partial class Users : Form
    { SqlConnection cn = new SqlConnection(@"Server=DESKTOP-2DE6KUQ\SQL2008R2;Database=project;Integrated security=true");
        void display()
        {

            SqlCommand cmd = new SqlCommand("select_User", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Users()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("AddUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@name", SqlDbType.VarChar,50);
                param[0].Value = textBox2.Text;
                param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
                param[1].Value = textBox3.Text;
                
                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("added successfuly");
                display();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            //textBox2.Enabled = false;
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@name", SqlDbType.VarChar,50);
                param[0].Value = textBox2.Text;
                param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
                param[1].Value = textBox3.Text;
                param[2] = new SqlParameter("@id", SqlDbType.Int);
                param[2].Value = textBox4.Text;

                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("updated successfuly");
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("deleteUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = textBox4.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Deleted successfuly");
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("searchUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@name", SqlDbType.VarChar,50);
                param[0].Value = textBox1.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                //textBox4.Text = dr[2].ToString();
                //comboBox1.Text= dr[3].ToString();
                //dateTimePicker1.Text= dr[4].ToString();
                dr.Close();
                cn.Close();
              
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("searchUser", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
                param[0].Value = textBox1.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox4.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
