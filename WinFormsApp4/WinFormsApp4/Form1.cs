namespace WinFormsApp4
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
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox2.Text);
            int c = Convert.ToInt32(textBox3.Text);
            int delta = b*b - 4*a*c;
            if(delta < 0)
            {
                textBox4.Text = "Girdiðiniz denklemin kökü yok.";
            } else if(delta == 0)
            {
                double kok1 = (-b + Math.Sqrt(delta)) / (2 * a);
                textBox4.Text = kok1.ToString();
            }else
            {
                double kok1 = (-b + Math.Sqrt(delta)) / (2 * a);
                double kok2 = (-b - Math.Sqrt(delta)) / (2 * a);
                textBox4.Text = kok1.ToString() + ", " + kok2.ToString();
            }
        }
    }
}