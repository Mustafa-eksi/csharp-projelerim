using System.Windows.Forms;

namespace DosyaYazOku
{
    public partial class Form1 : Form
    {
        string mevcutDosyaIsmi = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "txt";
            ofd.ShowDialog();
            mevcutDosyaIsmi = ofd.FileName;
            string mevcutDosya = System.IO.File.ReadAllText(ofd.FileName);
            textBox1.Text = mevcutDosya;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mevcutDosyaIsmi != "")
            {
                System.IO.File.WriteAllText(mevcutDosyaIsmi, textBox1.Text);
            }
            else
                MessageBox.Show("Dosya seçin.");
        }
    }
}