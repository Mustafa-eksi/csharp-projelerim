namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yazili1 = Convert.ToInt32(textBox1.Text);
            int yazili2 = Convert.ToInt32(textBox2.Text);
            int sozlu = Convert.ToInt32(textBox3.Text);
            double karne = yazili1 * 0.4 + yazili2 * 0.4 + sozlu * 0.2;
            if (karne > 59)
                textBox4.Text = "notunuz " + karne + " ve dersten geçtiniz.";
            else
                textBox4.Text = "notunuz " + karne + " ve dersten kaldýnýz";
        }
    }
}