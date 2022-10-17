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
        /*1. Ba�la.
          2. textBox1'in de�erini oku, int'e d�n��t�r ve n'ye ata.
          3. N say�s�n� asal b�lenlerine ay�r.
                3.1. 2'den ba�layarak n'nin yar�s�na kadar olan say�lardan asal olanlar� tek tek kalans�z b�l�n�yor mu diye dene.
                    3.1.1. Say�n�n karek�k�ne kadar olan say�lara b�l�n�p b�l�nemedi�ine bak, e�er b�l�nm�yorsa asald�r.
                3.2. Kalans�z b�l�nenler n say�s�n�n asal b�lenleridir.
          4. Bu asal b�lenlerden 2 (veya 2'nin kat� bir say� kadar) tekrar edenleri bul.
          5. Tekrarl� asal b�lenlerin �arp�m�n�n k�k�n� al, bunu k�k d���na yaz.
          6. Tekrars�z asal b�lenleri �arp, k�k i�ine yaz.
          7. Sadele�en k�kl� say�y� textBox2'ye yaz.  
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