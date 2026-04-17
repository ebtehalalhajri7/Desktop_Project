using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void أغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void المستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void المنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void العملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers cus = new Customers();
            cus.MdiParent=this;
            cus.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers Sup = new Suppliers();
            Sup.Show();

        }

      

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void اضافةمستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users use = new Users();
            use.Show();
        }

        private void المنتجاتToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            u.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Customers cus = new Customers();
            cus.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Suppliers Sup = new Suppliers();
            Sup.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Store sto = new Store();
            sto.Show();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void حولالمشروعToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_us about = new About_us();
            about.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            About_us about = new About_us();
            about.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Home Ho = new Home();
            Ho.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            About_us about = new About_us();
            about.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Store sto = new Store();
            sto.Show();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Users use = new Users();
            use.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

            Customers cus = new Customers();
            cus.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.Show();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Suppliers Sup = new Suppliers();
            Sup.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
