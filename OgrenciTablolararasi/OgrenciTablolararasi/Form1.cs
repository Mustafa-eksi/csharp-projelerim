using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace OgrenciTablolararasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection("Data Source=HOSAF-WINDOWS;Initial Catalog=ogrenciler;Integrated Security=True");
        private void baglantiac()
        {
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int ogrno = Convert.ToInt32(textBox1.Text);
            
            baglantiac();
            SqlCommand ogrkomut = new("select adi, soyadi, tc, bolum, donem from kimlik_bilgi where ogrno="+ogrno.ToString(), con);
            SqlDataReader ogrr = ogrkomut.ExecuteReader();
            SqlDataAdapter sda = new();
            if(ogrr.Read()) {
                label3.Text = ogrr[0].ToString();
                label5.Text = ogrr[1].ToString();
                label11.Text = ogrr[2].ToString();
                label10.Text = ogrr[3].ToString();
                label9.Text = ogrr[4].ToString();
            }
            ogrr.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantiac();
            string ogrno = textBox1.Text;
            SqlCommand ucretkomut = new("select kimlik_bilgi.ogrno, kimlik_bilgi.adi, kimlik_bilgi.soyadi, ucret_bilgi.miktar, ucret_bilgi.odeme_tarihi, ucret_bilgi.borcu from kimlik_bilgi inner join ucret_bilgi on kimlik_bilgi.ogrno=ucret_bilgi.orgno where kimlik_bilgi.ogrno=" + ogrno, con);
            SqlDataAdapter sda = new SqlDataAdapter(ucretkomut);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantiac();
            string ogrno = textBox1.Text;
            SqlCommand derskomut = new("select kimlik_bilgi.ogrno, kimlik_bilgi.adi, kimlik_bilgi.soyadi, ders_bilgi.ders_adi, ders_bilgi.donem_sonu_notu, ders_bilgi.donem from kimlik_bilgi inner join ders_bilgi on kimlik_bilgi.ogrno=ders_bilgi.orgno where kimlik_bilgi.ogrno=" + ogrno, con);
            SqlDataAdapter sda = new SqlDataAdapter(derskomut);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}