namespace BozuklukSayici
{
    public partial class Form1 : Form
    {
        public int birlik = 0, ellilik = 0, yirmibeslik = 0, onluk = 0, beslik = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            ellilik++;
            textBox2.Text = ellilik.ToString();
            toplamhesapla();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yirmibeslik++;
            textBox3.Text = yirmibeslik.ToString();
            toplamhesapla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            onluk++;
            textBox4.Text = onluk.ToString();
            toplamhesapla();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            beslik++;
            textBox5.Text = beslik.ToString();
            toplamhesapla();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            birlik--;
            textBox1.Text = birlik.ToString();
            toplamhesapla();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ellilik--;
            textBox2.Text = ellilik.ToString();
            toplamhesapla();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            yirmibeslik--;
            textBox3.Text = yirmibeslik.ToString();
            toplamhesapla();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            onluk--;
            textBox4.Text = onluk.ToString();
            toplamhesapla();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            beslik--;
            textBox5.Text = beslik.ToString();
            toplamhesapla();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void toplamhesapla()
        {
            textBox6.Text = Convert.ToString((double)((birlik*100) + (ellilik*50) + (yirmibeslik*25) + (onluk*10) + (beslik*5))/100);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            birlik++;
            textBox1.Text = birlik.ToString();
            toplamhesapla();
        }
    }
}