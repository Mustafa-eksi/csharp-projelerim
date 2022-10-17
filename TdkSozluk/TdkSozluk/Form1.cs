using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Net;

namespace TdkSozluk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string Get(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        public void sozlukteara(string terim)
        {
            string b = Get("https://sozluk.gov.tr/gts?ara=" + terim);
            JObject a = JObject.Parse(b.Substring(1, b.Length - 2));
            JToken c = a["anlamlarListe"];
            for(int i = 0; i < c.Count(); i++)
            {
                listBox1.Items.Add(c[i]["anlam"].ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string aranacak = textBox1.Text;
            sozlukteara(aranacak);
        }
    }
    public class Anlam
    {
        string anlam_id, madde_id, anlam_sira, fiil, tipkes, anlam, gos;
    }
    public class Terim
    {
        string madde_id, kac, kelime_no, cesit, anlam_gor, on_taki, madde, cesit_say, anlam_say, taki, cogul_mu, ozel_mi, lisan_kodu, lisan, telaffuz, birlesikler, font, madde_duz, gosterim_tarihi;
        Anlam[] anlamlarListe;	
    }
}