namespace KDVHesapla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int oran = 0;
            if (radioButton3.Checked)
                oran = 1;
            else if (radioButton4.Checked)
                oran = 8;
            else if (radioButton5.Checked)
                oran = 18;
            else if (radioButton6.Checked)
                oran = Convert.ToInt32(textBox1.Text);
            else
                MessageBox.Show("KDV oraný seçmeniz veya girmeniz gerekiyor.");
            double deger = Convert.ToDouble(textBox3.Text);
            if(radioButton1.Checked == true) // KDV dahilden KDV hariç
            {
                double kdvsiz = deger / (1 + ((double) oran / 100));
                textBox2.Text = kdvsiz.ToString();
            }
            else if(radioButton2.Checked == true) // KDV hariçten KDV dahil
            {
                double kdvli = deger + ((double)(deger * oran) / 100);
                textBox2.Text = kdvli.ToString();
            }else // Ýkisi de seçili deðilse
            {
                MessageBox.Show("Hesaplama türünü seçmeniz gerekiyor.");
            }
        }
    }
}