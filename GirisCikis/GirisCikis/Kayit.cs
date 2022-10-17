using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GirisCikis
{
    public partial class Kayit : Form
    {
        public Kayit()
        {
            InitializeComponent();
        }
        public SqlConnection conn = new SqlConnection("Data Source=HOSAF-WINDOWS;Initial Catalog=GirisCikis;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string kullanici_adi = textBox1.Text;
            string parola = textBox2.Text;
            string parola_yeniden = textBox3.Text;
            if(kullanici_adi == null || parola == null || parola_yeniden == null)
            {
                MessageBox.Show("Bilgileri girmeniz gerekiyor.");
                return;
            }
            if(parola != parola_yeniden)
            {
                MessageBox.Show("Parolalar eşleşmiyor.");
                return;
            }
            if(!checkBox1.Checked)
            {
                MessageBox.Show("Kayıt olmanız için kullanıcı sözleşmesini kabul etmeniz gerekiyor.");
                return;
            }
            SqlCommand sorgum = new SqlCommand("select count(*) from Kullanicilar where kullanici_adi='" + kullanici_adi + "'", conn);
            SqlDataReader reader = sorgum.ExecuteReader();
            //SqlCommand sorgum2 = new SqlCommand("select count(*) from Kullanicilar", conn);
            
            if (reader.Read())
            {
                if (Convert.ToInt32(reader[0]) == 0) {
                    reader.Close();
                    //SqlDataReader reader2 = sorgum2.ExecuteReader();
                    //reader2.Read();
                    SqlCommand kayit = new SqlCommand("insert into Kullanicilar (kullanici_adi, parola, kayit_tarihi) values (@kullanici_adi, @parola, @kayit_tarihi)", conn);
                    //kayit.Parameters.AddWithValue("@kullanici_no", SqlDbType.Int).Value = Convert.ToInt32(reader2[0])+1;
                    kayit.Parameters.AddWithValue("@kullanici_adi", SqlDbType.NVarChar).Value = kullanici_adi;
                    kayit.Parameters.AddWithValue("@parola", SqlDbType.NVarChar).Value = parola;
                    kayit.Parameters.AddWithValue("@kayit_tarihi", SqlDbType.DateTime).Value = DateTime.Now;
                    //reader2.Close();
                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla kayıt olundu.");
                    conn.Close();
                    Form2 form2 = new(); // Böyle de oluyormuş
                    form2.kullanici_adi = kullanici_adi;
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bu kullanıcı adı başkası tarafından kullanılıyor.");
                    return;
                }
            }
        }
    }
}
