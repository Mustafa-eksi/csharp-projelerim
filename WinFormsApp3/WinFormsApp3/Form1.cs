namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sayi = Convert.ToInt32(textBox1.Text);
            int s = sayi;
            int basamak = 0;
            while(s != 0)
            {
                basamak++;
                s = s / 10;
            }
            if(basamak > 5)
            {
                MessageBox.Show("1-5 basamaklý bir sayý giriniz.");
            }else
            {
                textBox2.Text = basamak.ToString();
            }

        }
    }
}