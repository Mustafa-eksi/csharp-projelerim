namespace diziler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] sayilar = { 1, 1, 1, -2, 7, 10, 3, -8, 4, 11, 28, 496};
        private void Form1_Load(object sender, EventArgs e)
        {
            /*for (int i = sayilar.Length-1; i > -1; i--)
            {
                listBox1.Items.Add(sayilar[i]);
            }*/
            /*for(int i = 0; i < sayilar.Length; i=i+2)
            {
                int a = sayilar[i];
                sayilar[i] = sayilar[i + 1];
                sayilar[i + 1] = a;
            }
            for(int i = 0; i < sayilar.Length; i++)
            {
                listBox1.Items.Add(sayilar[i]);
            }*/
            for(int i = 0; i < sayilar.Length; i++)
            {
                int bolentoplami = 0;
                for(int n = 1; n < (sayilar[i]/2)+1; n++)
                {
                    if (sayilar[i] % n == 0)
                        bolentoplami = bolentoplami + n;
                }
                if(bolentoplami == sayilar[i])
                    listBox1.Items.Add(sayilar[i] + " - mükemmel sayý");
                else
                    listBox1.Items.Add(sayilar[i] + " - normal sayý");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int bulunacak = Convert.ToInt32(textBox1.Text);
            int kactane = 0;
            for (int i = 0; i < sayilar.Length; i++)
            {
                if (sayilar[i] == bulunacak)
                {
                    kactane++;
                }
            }
            if (kactane == 0)
                textBox2.Text = "Girdiðiniz sayý dizide bulunmuyor.";
            else
                textBox2.Text = kactane + " tane var";
        }
    }
}