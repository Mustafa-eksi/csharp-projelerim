using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marketuyg
{
    public partial class Odeme : Form
    {
        public Odeme()
        {
            InitializeComponent();
        }
        public ArrayList sepettekiler;
        public int sepet_tutari = 0;
        public int cantastok = 10;
        public int defterstok = 5;
        public int kalemstok = 2;
        public int sulukstok = 0;
        public int silgistok = 15;
        public int kalemlikstok = 40;

        private void button2_Click(object sender, EventArgs e)
        {
            Sepet sepet = new Sepet();
            sepet.sepettekiler = sepettekiler;
            sepet.sepet_tutari = sepet_tutari;
            sepet.sepet_tutari = sepet_tutari;
            sepet.cantastok = cantastok;
            sepet.defterstok = defterstok;
            sepet.kalemstok = kalemstok;
            sepet.sulukstok = sulukstok;
            sepet.silgistok = silgistok;
            sepet.kalemlikstok = kalemlikstok;
            sepet.Show();
            this.Hide();
        }

        private void Odeme_Load(object sender, EventArgs e)
        {
            label9.Text = sepet_tutari.ToString() + " ₺";
            label10.Text = sepettekiler.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string adsoyad = textBox5.Text;
            string adres = textBox6.Text;
            long kredino = Convert.ToInt64(textBox1.Text);
            int guvenlikkodu = Convert.ToInt32(textBox2.Text);
            int ay = Convert.ToInt32(textBox3.Text);
            int yil = 2000 + Convert.ToInt32(textBox4.Text);

            long gecerli_kredino = 1234567812345678; // 16 haneli bir kredi kartı numarası
            int gecerli_guvenlikkodu = 1234;
            int buay = DateTime.Now.Month;
            int buyil = DateTime.Now.Year;
            // eğer bu yıldan düşükse veya bu yılla aynı ve ayı küçükse tarihi geçmiştir.
            if(kredino == gecerli_kredino && gecerli_guvenlikkodu == guvenlikkodu && !(yil < buyil || (buyil == yil && ay < buay)))
            {
                MessageBox.Show(adsoyad + ", işleminiz kaydedildi. Ürünler en yakın zamanda " + adres + " adresine gönderilecektir.");
                sepettekiler.Clear();
                sepet_tutari = 0;
                Form2 form2 = new Form2();
                form2.sepet_tutari = sepet_tutari;
                form2.cantastok = cantastok;
                form2.defterstok = defterstok;
                form2.kalemstok = kalemstok;
                form2.sulukstok = sulukstok;
                form2.silgistok = silgistok;
                form2.kalemlikstok = kalemlikstok;
                form2.Show();
                this.Close();
            }
            else
                MessageBox.Show("Kredi kartı bilgileri yanlış.");
        }
    }
}
