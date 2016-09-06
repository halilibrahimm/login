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
    public partial class K_Ekle : Form
    {
        public K_Ekle()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-ALC4JFR; Initial Catalog = kayit; Integrated Security=SSPI");
        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        void verileriGetir()
        {
            cmd = new SqlCommand("Select * from kisiler", con);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            verileriGetir();
            textBox1.MaxLength = 11;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Insert into kisiler(k_no,ad,soyad,adres,telefon,eposta,uyelik,t_suresi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Eklendi");
            verileriGetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "delete from kisiler where k_no=" + textBox1.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            verileriGetir();
            MessageBox.Show("Silindi");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "update kisiler set ad='" + textBox2.Text + "',soyad='" + textBox3.Text + "',adres='" + textBox4.Text + "',telefon='" + textBox5.Text + "',eposta='" + textBox6.Text + "',uyelik='" + comboBox1.Text + "',t_suresi='" + comboBox2.Text + "' where k_no='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                verileriGetir();
                MessageBox.Show("Güncellendi");

            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();



        }
    
}
}
