namespace Marketuyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullanici = "mustafa_eksi";
            string sifre = "mustafa123";
            string girilenkullanici = textBox1.Text;
            string girilensifre = textBox2.Text;

            if(kullanici == girilenkullanici && sifre == girilensifre)
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Þifre veya kullanýcý adý yanlýþ.");
            }
        }
    }
}