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
    public partial class Customers : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=DESKTOP-2DE6KUQ\SQL2008R2;Database=project;Integrated security=true");
        void display()
        {

            SqlCommand cmd = new SqlCommand("SetectAll", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Customers()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Suppliers_Load(object sender, EventArgs e)
        {
            display();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("searchCustomer", cn);
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
                checkBox2.Text = dr[5].ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("InsertCustomer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@customer_name", SqlDbType.VarChar, 50);
                param[0].Value = textBox11.Text;

                param[1] = new SqlParameter("@customer_phone", SqlDbType.VarChar, 50);
                param[1].Value = textBox10.Text;

                param[2] = new SqlParameter("@customer_email", SqlDbType.VarChar, 50);
                param[2].Value = textBox8.Text;

                param[3] = new SqlParameter("@customer_address", SqlDbType.VarChar, 50);
                param[3].Value = textBox9.Text;

                param[4] = new SqlParameter("@customer_isactive", SqlDbType.Bit);
                param[4].Value = checkBox2.Checked ? 1 : 0;

               

                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                
                MessageBox.Show("Customer added successfully");
                display();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(" wrong"+ ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateCutomer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[6];
                param[0] = new SqlParameter("@customer_id", SqlDbType.Int);
                param[0].Value = textBox7.Text;
                param[1] = new SqlParameter("@customer_name", SqlDbType.VarChar, 50);
                param[1].Value = textBox11.Text;

                param[2] = new SqlParameter("@customer_phone", SqlDbType.VarChar, 50);
                param[2].Value = textBox10.Text;

                param[3] = new SqlParameter("@customer_email", SqlDbType.VarChar, 50);
                param[3].Value = textBox8.Text;

                param[4] = new SqlParameter("@customer_address", SqlDbType.VarChar, 50);
                param[4].Value = textBox9.Text;

                param[5] = new SqlParameter("@customer_isactive", SqlDbType.Bit);
                param[5].Value = checkBox2.Checked ? 1 : 0;

                

                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                display();
                MessageBox.Show("Customer updated successfully");
                
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
                SqlCommand cmd = new SqlCommand("DeleteCustomer", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@customer_id", SqlDbType.Int);
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

        private void button5_Click(object sender, EventArgs e)
        {
            textBox7.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            checkBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
            checkBox2.Checked = Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value);
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
