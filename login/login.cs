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
namespace login
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-ALC4JFR;Initial Catalog= kayit;Integrated Security=SSPI");
        SqlDataAdapter da;
        SqlCommand cmd;
        DataTable dt;
        SqlDataReader dr;
        K_Ekle k=new K_Ekle();

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Kullanicilar where kullaniciAdi='" + textBox1.Text + "' AND kullaniciSifre='" + textBox2.Text + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
           {
                if (textBox1.Text=="adem akar" && textBox2.Text=="1234")
                {
                    panel1.Show();
                }
                
               
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }

            con.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
           // panel1.Hide();
        }
    }
    }

