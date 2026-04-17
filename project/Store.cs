using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project
{
    public partial class Store : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=DESKTOP-2DE6KUQ\SQL2008R2;Database=project;Integrated security=true");
        public Store()
        {
            InitializeComponent();
        }

        void display()
        {
            //SqlDataAdapter da = new SqlDataAdapter("selectStore", cn);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;

            SqlCommand cmd = new SqlCommand("selectStore", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }





        private void Store_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insertStore", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[4];
                

                param[0] = new SqlParameter("@store_name", SqlDbType.VarChar, 50);
                param[0].Value = textBox1.Text;

                param[1] = new SqlParameter("@product_type", SqlDbType.VarChar, 50);
                param[1].Value = textBox3.Text;

                param[2] = new SqlParameter("@product_quntity", SqlDbType.Int);
                param[2].Value = textBox4.Text;

                param[3] = new SqlParameter("@store_active", SqlDbType.Bit);
                param[3].Value = checkBox1.Checked ? 1 : 0;

                //param[4] = new SqlParameter("@product_name", SqlDbType.VarChar,50);
                //param[4].Value = textBox6.Text;



                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Added successfuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("update_store", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@store_id", SqlDbType.Int);
                param[0].Value = textBox2.Text;

                param[1] = new SqlParameter("@store_name", SqlDbType.VarChar, 50);
                param[1].Value = textBox1.Text;

                param[2] = new SqlParameter("@product_type", SqlDbType.VarChar, 50);
                param[2].Value = textBox3.Text;

                param[3] = new SqlParameter("@product_quntity", SqlDbType.VarChar, 50);
                param[3].Value = textBox4.Text;

                param[4] = new SqlParameter("@store_isactive", SqlDbType.Bit);
                param[4].Value = checkBox1.Checked ? 1 : 0;

                param[5] = new SqlParameter("@product_id", SqlDbType.Int);
                param[5].Value = textBox6.Text;

                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("updated successfuly", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("delete_store", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@store_id", SqlDbType.Int);
                param[0].Value = textBox2.Text;

                param[1] = new SqlParameter("@product_id", SqlDbType.Int);
                param[1].Value = textBox6.Text;

                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("deleted successfuly", "delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("searchStore", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
                param[0].Value = textBox5.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox2.Text = dr[0].ToString();
                textBox6.Text = dr[1].ToString();
                textBox1.Text = dr[2].ToString();
                checkBox1.Checked = Convert.ToBoolean(dr[3]);
                textBox4.Text = dr[4].ToString();
                textBox3.Text = dr[5].ToString();
                dr.Close();
                cn.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            //checkBox1.Checked = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
