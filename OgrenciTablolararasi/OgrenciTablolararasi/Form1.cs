using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;

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
        private void button1_Click_1(object sender, EventArgs e)
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            baglantiac();
            string ogrno = textBox1.Text;
            SqlCommand ucretkomut = new("select kimlik_bilgi.ogrno, kimlik_bilgi.adi, kimlik_bilgi.soyadi, ucret_bilgi.miktar, ucret_bilgi.odeme_tarihi, ucret_bilgi.borcu from kimlik_bilgi inner join ucret_bilgi on kimlik_bilgi.ogrno=ucret_bilgi.ogrno where kimlik_bilgi.ogrno=" + ogrno, con);
            SqlDataAdapter sda = new SqlDataAdapter(ucretkomut);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglantiac();
            string ogrno = textBox1.Text;
            SqlCommand derskomut = new("select kimlik_bilgi.ogrno, kimlik_bilgi.adi, kimlik_bilgi.soyadi, ders_bilgi.ders_adi, ders_bilgi.donem_sonu_notu, ders_bilgi.donem from kimlik_bilgi inner join ders_bilgi on kimlik_bilgi.ogrno=ders_bilgi.ogrno where kimlik_bilgi.ogrno=" + ogrno, con);
            SqlDataAdapter sda = new SqlDataAdapter(derskomut);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        bool SayiMi(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9') // ASCII tablosunda 48 ile 57 arasýndaki karakterler rakamdýr.
                {
                    return false;
                }
            }
            return true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string ogrno = textBox2.Text;
            string adi = textBox3.Text;
            string soyadi = textBox4.Text;
            string tc = textBox5.Text;
            string donem = textBox7.Text;
            string bolum = textBox6.Text;
            if (!SayiMi(ogrno) || !SayiMi(tc) || !SayiMi(donem))
            {
                MessageBox.Show("Girilen bilgiler hatalý.");
                return;
            }
            string giris_tarihi = DateTime.Now.ToString("yyyy-MM-dd");
            baglantiac();
            SqlCommand ogrkayit = new("insert into kimlik_bilgi (ogrno, adi, soyadi, tc, giris_tarihi, donem, bolum) values (" + ogrno + ", '" + adi + "', '" + soyadi + "', " + tc + ", '" + giris_tarihi + "', " + donem + ", '" + bolum + "')", con);
            ogrkayit.ExecuteNonQuery();
            MessageBox.Show("Baþarýyla kayýt olundu.");
        }

        private void kisikayitgoster()
        {
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            button7.Visible = true;
        }
        private void kisikayitgizle()
        {
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            button7.Visible = false;
        }

        private void derskayitgizle()
        {
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            label22.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            textBox11.Visible = false;
            textBox12.Visible = false;
            button8.Visible = false;
        }
        private void derskayitgoster()
        {
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            textBox11.Visible = true;
            textBox12.Visible = true;
            button8.Visible = true;
        }

        private void ucretkayitgoster()
        {
            label23.Visible = true;
            label24.Visible = true;
            button9.Visible = true;
            textBox13.Visible = true;
            textBox14.Visible = true;
        }

        private void ucretkayitgizle()
        {
            label23.Visible = false;
            label24.Visible = false;
            button9.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            derskayitgizle();
            ucretkayitgizle();
            kisikayitgoster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kisikayitgizle();
            ucretkayitgizle();
            derskayitgoster();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string tc = textBox8.Text;
            string ders_kodu = textBox11.Text;
            string ders_adi = textBox10.Text;
            string not = textBox9.Text;
            string donem = textBox12.Text;
            int ogrno = 0;
            if (!SayiMi(tc) || !SayiMi(not))
            {
                MessageBox.Show("Girilen bilgiler hatalý.");
                return;
            }
            baglantiac();
            SqlCommand tcdenbul = new("select ogrno from kimlik_bilgi where tc="+tc, con);
            SqlDataReader tcdenoku = tcdenbul.ExecuteReader();
            if(tcdenoku.Read())
            {
                if (tcdenoku.HasRows)
                {
                    ogrno = tcdenoku.GetInt32(0);
                }
            }
            if (ogrno == 0)
            {
                MessageBox.Show("Öðrenci bulunamadý.");
                return;
            }
            tcdenoku.Close();
            SqlCommand derskayit = new("insert into ders_bilgi (ogrno, donem, ders_kod, ders_adi, donem_sonu_notu) values ("+ogrno+", "+donem+", "+ders_kodu+", '"+ders_adi+"', "+not+")", con);
            derskayit.ExecuteNonQuery();
            MessageBox.Show("Baþarýyla ders kaydý yapýldý.");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string tc = textBox13.Text;
            string miktar = textBox14.Text;
            int ogrno = 0;
            string odeme_tarihi = DateTime.Now.ToString("yyyy-MM-dd");
            if (!SayiMi(tc) || !SayiMi(miktar))
            {
                MessageBox.Show("Girilen bilgiler hatalý.");
                return;
            }
            baglantiac();
            SqlCommand tcdenbul = new("select ogrno from kimlik_bilgi where tc=" + tc, con);
            SqlDataReader tcdenoku = tcdenbul.ExecuteReader();
            if (tcdenoku.Read())
            {
                if (tcdenoku.HasRows)
                {
                    ogrno = tcdenoku.GetInt32(0);
                }
            }
            if (ogrno == 0)
            {
                MessageBox.Show("Öðrenci bulunamadý.");
                return;
            }
            tcdenoku.Close();
            SqlCommand derskayit = new("insert into ucret_bilgi (ogrno, odeme_tarihi, miktar, borcu) values ("+ogrno+", '"+odeme_tarihi+"', "+miktar+", 0)", con);
            derskayit.ExecuteNonQuery();
            MessageBox.Show("Baþarýyla ücret kaydý yapýldý.");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            derskayitgizle();
            kisikayitgizle();
            ucretkayitgoster();
        }
    }
}