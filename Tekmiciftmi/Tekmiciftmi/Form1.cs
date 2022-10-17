namespace Tekmiciftmi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            int bolum = sayi / 2;
            int kalan = sayi - (2 * bolum);
            if(kalan == 1)
                textBox2.Text = "Tek";
            else
                textBox2.Text = "Çift";
        }
    }
}