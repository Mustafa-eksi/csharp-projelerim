using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Marketuyg
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int sepet_tutari = 0;
        public int cantastok = 10;
        public int defterstok = 5;
        public int kalemstok = 2;
        public int sulukstok = 0;
        public int silgistok = 15;
        public int kalemlikstok = 40;
        public ArrayList sepettekiler = new ArrayList();
        private void Form2_Load(object sender, EventArgs e)
        {
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
        }
        private int sepeteekle(ref int urunstok, int fiyat, string isim, Button buton)
        {
            if (urunstok < 4 && urunstok > 0)
            {
                MessageBox.Show("Stok azalıyor!!!");
                int indirimlifiyat = fiyat - (fiyat * 10 / 100);
                sepet_tutari += indirimlifiyat;
                sepettekiler.Add(indirimlifiyat.ToString() + " ₺ - " + isim);
                urunstok -= 1;
            }
            else if (urunstok < 1)
            {
                MessageBox.Show("Ürünün stoğu yoktur.");
                buton.Enabled = false;
            }
            else
            {
                sepet_tutari += 60;
                sepettekiler.Add(fiyat.ToString() +" ₺ - " + isim);
                urunstok -= 1;
            }
            return urunstok;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Sepet sepet = new Sepet();
            sepet.sepettekiler = this.sepettekiler;
            sepet.sepet_tutari = sepet_tutari;
            sepet.cantastok = cantastok;
            sepet.defterstok = defterstok;
            sepet.kalemstok = kalemstok;
            sepet.sulukstok = sulukstok;
            sepet.silgistok = silgistok;
            sepet.kalemlikstok = kalemlikstok;
            this.Hide();
            sepet.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sepeteekle(ref cantastok, 60, "Çanta", button1);
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sepeteekle(ref defterstok, 30, "Defter", button2);
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sepeteekle(ref kalemstok, 5, "Kalem", button4);
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sepeteekle(ref silgistok, 3, "Silgi", button3);
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sepeteekle(ref kalemlikstok, 20, "Kalemlik", button6);
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sepeteekle(ref sulukstok, 35, "Suluk", button5);
            label13.Text = " " + sepet_tutari.ToString() + " ₺";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sepet_tutari = 0;
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
