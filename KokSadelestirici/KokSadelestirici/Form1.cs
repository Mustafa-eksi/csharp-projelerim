using System.Collections;

namespace KokSadelestirici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean AsalMi(int n)
        {
            for(int i = 2; i < Math.Sqrt(n); i++)
            {
                if(n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        /*1. Baþla.
          2. textBox1'in deðerini oku, int'e dönüþtür ve n'ye ata.
          3. N sayýsýný asal bölenlerine ayýr.
                3.1. 2'den baþlayarak n'nin yarýsýna kadar olan sayýlardan asal olanlarý tek tek kalansýz bölünüyor mu diye dene.
                    3.1.1. Sayýnýn kareköküne kadar olan sayýlara bölünüp bölünemediðine bak, eðer bölünmüyorsa asaldýr.
                3.2. Kalansýz bölünenler n sayýsýnýn asal bölenleridir.
          4. Bu asal bölenlerden 2 (veya 2'nin katý bir sayý kadar) tekrar edenleri bul.
          5. Tekrarlý asal bölenlerin çarpýmýnýn kökünü al, bunu kök dýþýna yaz.
          6. Tekrarsýz asal bölenleri çarp, kök içine yaz.
          7. Sadeleþen köklü sayýyý textBox2'ye yaz.  
          8. Bitir.*/
        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList asalbolenler = new ArrayList();
            int n = Convert.ToInt32(textBox1.Text);
            for (int i = 2; i < n / 2; i++)
            {
                if(AsalMi(i))
                {
                    if(n % i == 0)
                    {
                        asalbolenler.Add(i);
                    }
                }else
                {
                    continue;
                }
            }
        }
    }
}