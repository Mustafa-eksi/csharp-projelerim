using System.Data;
using System.Data.SqlClient;

namespace Sqllekod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=HOSAF-WINDOWS;Initial Catalog=Ilkveritabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            } else
            {
                MessageBox.Show("Baðlantý zaten açýk.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Baðlantý zaten kapalý.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(baglanti.State.ToString());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void sorgula(string sorgu)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand sorgum = new SqlCommand(sorgu, baglanti);
            SqlDataAdapter adaptor = new SqlDataAdapter(sorgum);
            DataTable dt = new DataTable();
            adaptor.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            sorgula("select * from Ogrenci");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sorgula("select * from Ogrenci where sinif < 11");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sorgula("select * from Ogrenci where sinif > 10");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sorgula("select * from Ogrenci where okul_no=" + textBox1.Text);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlCommand kayit = new SqlCommand("insert into Ogrenci (isim, veli_adi, cinsiyet, okul_no, tc_kimlik, tel, sinif) values (@isim, @veli_adi, @cinsiyet, @okul_no, @tc_kimlik, @tel, @sinif)", baglanti);
            kayit.Parameters.AddWithValue("@isim", SqlDbType.NVarChar).Value = textBox2.Text;
            kayit.Parameters.AddWithValue("@veli_adi", SqlDbType.NVarChar).Value = textBox3.Text;
            kayit.Parameters.AddWithValue("@cinsiyet", SqlDbType.NVarChar).Value = comboBox1.SelectedItem.ToString();
            kayit.Parameters.AddWithValue("@okul_no", SqlDbType.Int).Value = Convert.ToInt16(textBox4.Text);
            kayit.Parameters.AddWithValue("@tc_kimlik", SqlDbType.BigInt).Value = Convert.ToInt64(textBox5.Text);
            kayit.Parameters.AddWithValue("@tel", SqlDbType.BigInt).Value = Convert.ToInt64(textBox6.Text);
            kayit.Parameters.AddWithValue("@sinif", SqlDbType.Int).Value = Convert.ToInt16(comboBox2.SelectedItem.ToString());
            kayit.ExecuteNonQuery();
            baglanti.Close();
        }

        
    }
}