using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project
{
    public partial class Suppliers : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=DESKTOP-2DE6KUQ\SQL2008R2;Database=project;Integrated security=true");
        void display()
        {

            SqlCommand cmd = new SqlCommand("SelectSupplier", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Suppliers()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            try
            {
                SqlCommand cmd = new SqlCommand("InsertSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[6];              

                param[0] = new SqlParameter("@supplier_name", SqlDbType.VarChar, 50);
                param[0].Value = textBox11.Text;

                param[2] = new SqlParameter("@supplier_phone", SqlDbType.VarChar, 50);
                param[2].Value = textBox10.Text;

                param[1] = new SqlParameter("@supplier_address", SqlDbType.VarChar, 50);
                param[1].Value = textBox9.Text;

                param[3] = new SqlParameter("@supplier_email", SqlDbType.VarChar, 50);
                param[3].Value = textBox8.Text;

                param[4] = new SqlParameter("@supplier_isactive", SqlDbType.Bit);
                param[4].Value = checkBox2.Checked ? 1 : 0;

                param[5] = new SqlParameter("@supplier_comapny", SqlDbType.VarChar, 50);
                param[5].Value = textBox1.Text;

                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Supplier added successfully");
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int supplierId;
                if (!int.TryParse(textBox7.Text.Trim(), out supplierId))
                {
                    MessageBox.Show("يرجى إدخال رقم صحيح للمعرف.");
                    return;
                }

                SqlCommand cmd = new SqlCommand("UpdateSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[7];
                param[0] = new SqlParameter("@supplier_id", SqlDbType.Int);
                param[0].Value = supplierId;

                param[1] = new SqlParameter("@supplier_name", SqlDbType.VarChar, 50);
                param[1].Value = textBox11.Text;

                param[2] = new SqlParameter("@supplier_phone", SqlDbType.VarChar, 50);
                param[2].Value = textBox10.Text;

                param[3] = new SqlParameter("@supplier_email", SqlDbType.VarChar, 50);
                param[3].Value = textBox8.Text;

                param[4] = new SqlParameter("@supplier_address", SqlDbType.VarChar, 50);
                param[4].Value = textBox9.Text;

                param[5] = new SqlParameter("@supplier_isactive", SqlDbType.Bit);
                param[5].Value = checkBox2.Checked ? 1 : 0;

                param[6] = new SqlParameter("@supplier_comapny", SqlDbType.VarChar, 50);
                param[6].Value = textBox1.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                display();
                MessageBox.Show("supplier updated successfully");

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
                SqlCommand cmd = new SqlCommand("DeleteSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(textBox7.Text);

                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();

                MessageBox.Show("Deleted successfully");
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
       try
            {
                SqlCommand cmd = new SqlCommand("searchSupplier", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
                param[0].Value = textBox5.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                textBox7.Text = dr[0].ToString();
                textBox11.Text = dr[1].ToString();
                textBox10.Text = dr[2].ToString();
                textBox9.Text = dr[3].ToString();
                textBox8.Text = dr[4].ToString();
                textBox1.Text = dr[5].ToString();
                checkBox2.Text = dr[6].ToString();
                dr.Close();
                cn.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            textBox1.Clear();
            checkBox2.Text = "";
            textBox5.Clear();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox11_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Enabled = false;
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

           
        }
    }
}
