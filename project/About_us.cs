using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace project
{
    public partial class About_us : Form
    {
        public About_us()
        {
            InitializeComponent();
        }

        private void الصفحةالرئيسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home hom = new Home();
            hom.Show();
        }

        private void نبذهتعريفيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About_us abo = new About_us();
            abo.Show();
        }

        private void عملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers custom = new Customers();
            custom.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Suppliers supp = new Suppliers();
            supp.Show();
        }

        private void المستخدمينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users us = new Users();
            us.Show();
        }

        private void المنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products prod = new Products();
            prod.Show();
        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("WWW.Facebok.com");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("WWW.Instagram.com");

        }

        private void About_us_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
