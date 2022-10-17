using System.Collections;

namespace stringfonksiyonlari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yazi = textBox1.Text;
            char[] dizi = yazi.ToCharArray();
            textBox2.Text = string.Join(',', dizi);

        }
        string[,] isimler = { { "Ayþe", "Sevim", "Ahmet" }, { "Kemal", "Ali", "Kerem" } };
        string[,] pozisyonlar = { { "PA", "PA", "K" }, { "K", "S", "K" } };
        private void button2_Click(object sender, EventArgs e)
        {
            string yazi = textBox1.Text;
            string[] ayrik = yazi.Split(' ');
            textBox2.Text = ayrik.Length + " tane kelime var";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ArrayList kordinatorler = new ArrayList();
            for(int i = 0; i < isimler.GetLength(0); i++)
            {
                for(int n = 0; n < isimler.GetLength(1); n++)
                {
                    if (pozisyonlar[i, n] == "K")
                        kordinatorler.Add(isimler[i, n]);
                }
            }
            textBox2.Text = String.Join(", ", kordinatorler.ToArray());
        }
        bool siralimi(char[] dizi)
        {
            bool sonuc = true;
            for(int i = 0; i < dizi.Length-1; i++)
            {
                if(Convert.ToInt32(dizi[i]) > Convert.ToInt32(dizi[i + 1]))
                {
                    sonuc = false;
                    break;
                }
            }
            return sonuc;
        }
        string sirala(string yazi)
        {
            char[] harfler = yazi.ToLower().ToCharArray();
            while (!siralimi(harfler)) {
                for (int i = 0; i < harfler.Length - 1; i++)
                {
                    if (Convert.ToInt32(harfler[i]) > Convert.ToInt32(harfler[i+1]))
                    {
                        char a = harfler[i];
                        harfler[i] = harfler[i + 1];
                        harfler[i + 1] = a;
                    }
                        
                }
            }
            return String.Join(' ', harfler);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = sirala(textBox1.Text);
        }
    }
}