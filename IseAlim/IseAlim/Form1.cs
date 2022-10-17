using System.Data.SqlClient;
using System.Data;

namespace IseAlim
{   
    public partial class Form1 : Form
    {
        SqlConnection con = new(db.condb);
        
        public Form1()
        {
            InitializeComponent();
        }
        private void BaðlantýSaðla()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void BaðlantýKapat()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            try { 
                string ad = textBox1.Text;
                string soyad = textBox2.Text;
                long tc = Convert.ToInt64(textBox3.Text);
                string dogum_yeri = textBox4.Text;
                string dogum_tarihi = dateTimePicker1.Value.Date.ToString().Substring(0,10);
                long tel = Convert.ToInt64(textBox5.Text);
                string adres = textBox6.Text;
                string baslangic = dateTimePicker2.Value.ToString().Substring(0, 10);
                int birim = comboBox1.SelectedIndex+1;
                BaðlantýSaðla();
                SqlCommand cmd = new SqlCommand("select count(*) from basvurular where tc="+tc.ToString(), con);
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    if (r.IsDBNull(0))
                        MessageBox.Show("Haydaaaa");
                    if (Convert.ToInt32(r[0]) == 0)
                    {
                        r.Close();

                        int tumkisi = 0, birimkisi = 0;
                        SqlCommand kisibil = new("select count(*) from basvurular;" + "select count(*) from basvurular where birim=" + birim.ToString(), con);
                        SqlDataReader okuyucu = kisibil.ExecuteReader();
                        if (okuyucu.Read()) { // Okuyucu okuyabildiyse
                            tumkisi = okuyucu.GetInt32(0); // 0. sütundan (ilk) int32 al
                        }
                        okuyucu.NextResult(); // Sonraki sorgu satýrýna geç
                        if(okuyucu.Read())
                        {
                            birimkisi = okuyucu.GetInt32(0);
                        }
                        okuyucu.Close();

                        string basvuru_no = baslangic.Substring(8, 2) + birim.ToString("D2") + birimkisi.ToString("D2") + tumkisi.ToString("D2");
                        
                        SqlCommand cmd4 = new SqlCommand("insert into basvurular (basvuru_no, adi, soyadi, tc, dogum_yeri, dogum_tarihi, tel, adres, tarih, baslangic_tarihi, birim, alindi_mi) values (@basvuru_no, @adi, @soyadi, @tc, @dogum_yeri, @dogum_tarihi, @tel, @adres, @tarih, @baslangic_tarihi, @birim, @alindi_mi)", con);
                        cmd4.Parameters.AddWithValue("@basvuru_no", SqlDbType.NVarChar).Value = basvuru_no;
                        cmd4.Parameters.AddWithValue("@adi", SqlDbType.NVarChar).Value = ad;
                        cmd4.Parameters.AddWithValue("@soyadi", SqlDbType.NVarChar).Value = soyad;
                        cmd4.Parameters.AddWithValue("@tc", SqlDbType.BigInt).Value = tc;
                        cmd4.Parameters.AddWithValue("@dogum_yeri", SqlDbType.NVarChar).Value = dogum_yeri;
                        cmd4.Parameters.AddWithValue("@dogum_tarihi", SqlDbType.Date).Value = dogum_tarihi;
                        cmd4.Parameters.AddWithValue("@tel", SqlDbType.BigInt).Value = tel;
                        cmd4.Parameters.AddWithValue("@adres", SqlDbType.NVarChar).Value = adres;
                        cmd4.Parameters.AddWithValue("@tarih", SqlDbType.Date).Value = DateTime.Now.ToString().Substring(0,10);
                        cmd4.Parameters.AddWithValue("@baslangic_tarihi", SqlDbType.NVarChar).Value = baslangic;
                        cmd4.Parameters.AddWithValue("@birim", SqlDbType.Int).Value = birim;
                        cmd4.Parameters.AddWithValue("@alindi_mi", SqlDbType.VarChar).Value = "hayir";
                        cmd4.ExecuteNonQuery();
                        BaðlantýKapat();
                        MessageBox.Show("Baþvurunuz kaydedildi.");
                    }
                } else
                {
                    r.Close();
                    MessageBox.Show("TC sorgusu yapýlamýyor.");
                    BaðlantýKapat();
                    return;
                }
                BaðlantýKapat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilinmeyen bir hata oluþtu! " + ex.Message);
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string basvuruno = textBox7.Text;
            BaðlantýSaðla();
            SqlCommand basvurkomut = new("select adi, soyadi, baslangic_tarihi, alindi_mi from basvurular where basvuru_no='"+basvuruno+"'", con);
            SqlDataReader okuyucu = basvurkomut.ExecuteReader();
            if(okuyucu.HasRows) // Okuyucu herhangi bir baþvuru bulduysa devam et
            {
                if (okuyucu.Read()) // Okuyabildiðinden emin olmak için
                {
                    // Sorgulanan baþvurunun verileri yazdýrýldý.
                    label14.Text = okuyucu.GetString(0) + " " + okuyucu.GetString(1);
                    label15.Text = okuyucu.GetString(2);
                    label16.Text = okuyucu.GetString(3);
                    okuyucu.Close(); // adaptor falan oluþturmak için okuyucuyu kapatmak gerekiyor.
                    SqlCommand gorevkomut = new("select gorev, son_tarih from gorevler where basvuru_no='"+basvuruno+"'", con);
                    SqlDataAdapter adaptor = new SqlDataAdapter(gorevkomut);
                    DataTable tablo = new();
                    adaptor.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // birinci satýra, datagridview1 için verilmiþ enin hepsini kullandýrtýyor.
                }
            }else // Bulamadýysa hata yazdýr
            {
                MessageBox.Show("Girilen baþvuru no ile kayýtlý baþvuru bulunamadý.");
            }
            BaðlantýKapat();
            okuyucu.Close();
        }
    }
}