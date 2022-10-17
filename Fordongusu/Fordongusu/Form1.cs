namespace Fordongusu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] sayilar = {1,3,14,5,4,6,13,7,9,12};
        bool siralimi(int[] dizi)
        {
            bool sonuc = true;
            for(int i = 0; i < dizi.Length-1; i++)
            {
                if(dizi[i] > dizi[i+1])
                {
                    sonuc = false;
                    break;
                }
            }
            return sonuc;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //4 6 12 14
            int[] sirali = sayilar;
            while (!siralimi(sirali))
            {
                for (int i = 0; i < sirali.Length - 1; i++)
                {
                    if (sirali[i] > sirali[i + 1])
                    {
                        int a = sirali[i + 1];
                        sirali[i + 1] = sirali[i];
                        sirali[i] = a;
                    }
                }
            }
            for(int i = 0; i < sirali.Length; i++)
            {
                listBox1.Items.Add(sirali[i]);
            }
            /*int enkucukasal = int.MaxValue;
            for(int i = 0; i < sayilar.Length; i++)
            {
                bool asalmi = true;
                if (sayilar[i] > 2)
                {
                    for (int n = 2; n < sayilar[i]; n++)
                    {
                        if (sayilar[i] % n == 0)
                        {
                            asalmi = false;
                            break;
                        }
                    }
                }else
                    asalmi=false;
                if (asalmi && enkucukasal > sayilar[i])
                    enkucukasal = sayilar[i];
            }
            listBox1.Items.Add(enkucukasal);
            */
        }
    }
}