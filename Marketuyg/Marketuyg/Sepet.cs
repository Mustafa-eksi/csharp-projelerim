using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Marketuyg
{
    public partial class Sepet : Form
    {
        public ArrayList sepettekiler;
        public int sepet_tutari = 0;
        public int cantastok = 10;
        public int defterstok = 5;
        public int kalemstok = 2;
        public int sulukstok = 0;
        public int silgistok = 15;
        public int kalemlikstok = 40;
        public Sepet()
        {
            InitializeComponent();
        }

        private void Sepet_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(sepettekiler.ToArray());
            label13.Text = sepet_tutari.ToString() + " ₺";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Form2 form2 = new Form2();
            form2.sepettekiler = this.sepettekiler;
            form2.sepet_tutari = sepet_tutari;
            form2.sepet_tutari = sepet_tutari;
            form2.cantastok = cantastok;
            form2.defterstok = defterstok;
            form2.kalemstok = kalemstok;
            form2.sulukstok = sulukstok;
            form2.silgistok = silgistok;
            form2.kalemlikstok = kalemlikstok;
            this.Hide();
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0 || sepettekiler.Count == 0) // Sepette hiç bir şey yoksa bu metodu çalıştırma
                return;

            string[] urunaciklama = listBox1.Items[listBox1.SelectedIndex].ToString().Split(" - ");
            switch (urunaciklama[1])
            {
                case "Çanta":
                    cantastok++;
                    break;
                case "Defter":
                    defterstok++;
                    break;
                case "Kalem":
                    kalemstok++;
                    break;
                case "Silgi":
                    silgistok++;
                    break;
                case "Kalemlik":
                    kalemlikstok++;
                    break;
                case "Suluk":
                    sulukstok++;
                    break;
            }
            sepet_tutari -= Convert.ToInt32(urunaciklama[0].Substring(0, urunaciklama[0].Length-2));
            sepettekiler.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            label13.Text = sepet_tutari.ToString() + " ₺"; // sepet tutarını güncelle
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Odeme odemeekrani = new Odeme();
            odemeekrani.sepettekiler = sepettekiler;
            odemeekrani.sepet_tutari = sepet_tutari;
            odemeekrani.cantastok = cantastok;
            odemeekrani.defterstok = defterstok;
            odemeekrani.kalemstok = kalemstok;
            odemeekrani.sulukstok = sulukstok;
            odemeekrani.silgistok = silgistok;
            odemeekrani.kalemlikstok = kalemlikstok;
            odemeekrani.Show();
            this.Hide();
        }
    }
}
