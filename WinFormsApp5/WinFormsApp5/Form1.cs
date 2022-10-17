namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string isimsoyisim = textBox1.Text;
            string bolum = textBox2.Text;
            int ales = Convert.ToInt32(textBox3.Text);
            if(ales < 70)
            {
                label7.Text = "Sevgili " + isimsoyisim + " baþvurmuþ olduðunuz " + bolum + " programýný kaybettiniz. Sebebi ales puanýnýzýn " + ales.ToString() + " olmasý, 70'ten yüksek olmasý gerekiyor.";
            }
            else
            {
                int yds = Convert.ToInt32(textBox4.Text);
                if(yds < 50)
                {
                    label7.Text = "Sevgili " + isimsoyisim + " baþvurmuþ olduðunuz " + bolum + " programýný kaybettiniz. Sebebi yds puanýnýzýn " + yds.ToString() + " olmasý, 50'den yüksek olmasý gerekiyor.";
                }
                else
                {
                    int mulakat = Convert.ToInt32(textBox5.Text);
                    if(mulakat < 70)
                    {
                        label7.Text = "Sevgili " + isimsoyisim + " baþvurmuþ olduðunuz " + bolum + " programýný kaybettiniz. Sebebi mulakat puanýnýzýn " + mulakat.ToString() + " olmasý, 70'ten yüksek olmasý gerekiyor.";
                    }
                    else
                    {
                        int okulnotu = Convert.ToInt32(textBox6.Text);
                        if(okulnotu < 85)
                        {
                            label7.Text = "Sevgili " + isimsoyisim + " baþvurmuþ olduðunuz " + bolum + " programýný kaybettiniz. Sebebi okul notunuzun " + okulnotu.ToString() + " olmasý, 85'ten yüksek olmasý gerekiyor.";
                        }
                        else
                        {
                            label7.Text = "Sevgili " + isimsoyisim + " baþvurmuþ olduðunuz " + bolum + " programýný kazandýnýz, baþarýlar dileriz.";
                        }
                    }
                }
            }
        }
    }
}