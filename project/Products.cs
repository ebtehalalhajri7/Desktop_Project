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
using System.IO;
namespace project
{
    public partial class Products : Form
    {
        string productImagePath = "";
        SqlConnection cn = new SqlConnection(@"Server=DESKTOP-2DE6KUQ\SQL2008R2;Database=project;Integrated security=true");
        void display()
        {

            SqlCommand cmd = new SqlCommand("SetectAllPro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public Products()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            display();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  
            try
            {
                SqlCommand cmd = new SqlCommand("InsertProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[9];

                param[0] = new SqlParameter("@product_name", SqlDbType.VarChar, 50);
                param[0].Value = textBox2.Text;

                param[1] = new SqlParameter("@product_code", SqlDbType.VarChar, 50);
                param[1].Value = textBox1.Text;
               
                param[2] = new SqlParameter("@product_price", SqlDbType.Decimal);
                param[2].Value = Convert.ToDecimal(textBox3.Text);

                param[3] = new SqlParameter("@product_quntity", SqlDbType.Int);
                param[3].Value = Convert.ToInt32(textBox4.Text);

                param[4] = new SqlParameter("@product_country", SqlDbType.VarChar, 50);
                param[4].Value = textBox5.Text;
                param[5] = new SqlParameter("@product_startdate", SqlDbType.VarChar, 50);
                param[5].Value = dateTimePicker1.Text;
                param[6] = new SqlParameter("@product_enddate", SqlDbType.VarChar, 50);
                param[6].Value = dateTimePicker2.Text;
                param[7] = new SqlParameter("@product_image", SqlDbType.VarChar, 255);
                param[7].Value = productImagePath;
                param[8] = new SqlParameter("@product_type", SqlDbType.VarChar, 50);
                param[8].Value = textBox8.Text;
                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                display();
                MessageBox.Show("product added successfully");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
           
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            ofd.Title = "اختر صورة المنتج";

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                ofd.Dispose();
                return;
            }

            string sourcePath = ofd.FileName;//نحصل على المسار كامل  للصوره الي اختاره المستخدم
            string imagesFolder = Path.Combine(Application.StartupPath, "Images", "Products");
            if (!Directory.Exists(imagesFolder))
                Directory.CreateDirectory(imagesFolder);

            string ext = Path.GetExtension(sourcePath);
            string fileName = Guid.NewGuid().ToString() + ext;//نولد اسم ملف فريد
            string destPath = Path.Combine(imagesFolder, fileName);//نكون المسار كامل للنسخه داخل مجلد المشروع

            File.Copy(sourcePath, destPath, true);
            ofd.Dispose();//نغلق ونحرر موارد مربع الحوار

            string relativePath = Path.Combine("Images", "Products", fileName);
            relativePath = relativePath.Replace("\\", "/");//نعمل المسار النسبي الي بنخزنه في الداتا بيس

            pictureBox1.ImageLocation = Path.Combine(Application.StartupPath, relativePath);//نعرض الصوره باستخدام المسار كامل

            // هنا نخزن المسار في المتغير
            productImagePath = relativePath;
        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = false;
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
           textBox8.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[8].Value != null)
            {
                string imgPath = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                productImagePath = imgPath; // نخزن المسار عشان لو عدلنا المنتج

                string fullPath = Path.Combine(Application.StartupPath, imgPath.Replace("/", "\\"));
                if (File.Exists(fullPath))
                {
                    pictureBox1.Image = Image.FromFile(fullPath);
                }
                else
                {
                    pictureBox1.Image = null; // أو صورة افتراضية
                }
            }
            else
            {
                pictureBox1.Image = null;
                productImagePath = "";
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = Image.FromFile(@"F:\IMAJES\about-img (2).png");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateProduct", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[9];

                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(textBox6.Text);

                param[1] = new SqlParameter("@product_name", SqlDbType.VarChar, 50);
                param[1].Value = textBox1.Text;

                param[2] = new SqlParameter("@product_code", SqlDbType.VarChar, 50);
                param[2].Value = textBox2.Text;

                param[3] = new SqlParameter("@product_price", SqlDbType.Decimal);
                param[3].Value = Convert.ToDecimal(textBox3.Text);

                param[4] = new SqlParameter("@product_quntity", SqlDbType.Int);
                param[4].Value = Convert.ToInt32(textBox4.Text);

                param[5] = new SqlParameter("@product_country", SqlDbType.VarChar, 50);
                param[5].Value = textBox5.Text;

                param[6] = new SqlParameter("@product_startdate", SqlDbType.VarChar, 50);
                param[6].Value = dateTimePicker1.Text;

                param[7] = new SqlParameter("@product_enddate", SqlDbType.VarChar, 50);
                param[7].Value = dateTimePicker2.Text;

                param[8] = new SqlParameter("@product_image", SqlDbType.VarChar, 255);
                param[8].Value = productImagePath;
                param[9] = new SqlParameter("@product_type", SqlDbType.VarChar, 50);
                param[9].Value =textBox8.Text;

                cmd.Parameters.AddRange(param);

                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                display();
                MessageBox.Show("Product updated successfully");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("DeletePro", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = Convert.ToInt32(textBox6.Text);

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

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox7.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox5.Clear();
            pictureBox1.Image=null;
            productImagePath = "";
            textBox8.Clear();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            openFileDialog1.InitialDirectory=(":D");
        }
    }
}
