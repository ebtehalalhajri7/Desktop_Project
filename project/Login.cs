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
    public partial class Login : Form
    {
        SqlConnection cn = new SqlConnection(@"Server=DESKTOP-2DE6KUQ\SQL2008R2;Database=project;Integrated security=true");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();

                string username = textBox2.Text; // textBox1 for username
                string password = textBox1.Text; // textBox2 for password

                string query = "SELECT COUNT(*) FROM users WHERE user_name = @username AND user_password = @password";
                SqlCommand cmd = new SqlCommand(query, cn);

                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = (int)cmd.ExecuteScalar();

                if (count > 0)
                {
                   DialogResult dr= MessageBox.Show("Login successful ✅");
                    if (dr == DialogResult.OK)
                    {
                        Home frm = new Home();
                        frm.Show();
                    }
                    // Example: open another form
                    // Form2 f2 = new Form2();
                    // f2.Show();
                    // this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password ❌");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    }

