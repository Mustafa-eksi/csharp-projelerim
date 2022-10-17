namespace WinFormsApp6
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
            int yuzler = sayi / 100;
            int a = sayi - (yuzler * 100);
            int onlar = a / 10;
            int birler = (a - (onlar * 10));
            if (yuzler > onlar && yuzler > birler)
                textBox2.Text = "En büyük basamak yüzler: " + yuzler.ToString();
            else if (onlar > yuzler && onlar > birler)
                textBox2.Text = "En büyük basamak onlar: " + onlar.ToString();
            else if (birler > yuzler && birler > onlar)
                textBox2.Text = "En büyük basamak birler: " + birler.ToString();
            else
                textBox2.Text = "Tüm basamaklar eþit.";
        }
    }
}