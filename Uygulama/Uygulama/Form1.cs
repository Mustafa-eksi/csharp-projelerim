namespace Uygulama
{
    public partial class Form1 : Form
    {
        string dosya = "";
        string dosyaismi = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = "txt";
            dialog.ShowDialog();
            dosya = File.ReadAllText(dialog.FileName);
            dosyaismi = dialog.FileName;
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] sat�rlar = dosya.Split('\n');
            int sat�r = Convert.ToInt32(textBox1.Text);
            sat�rlar[sat�r-1] = textBox2.Text;
            //string yaz�lacak = string.Join('\n', sat�rlar);
            File.WriteAllLines(dosyaismi, sat�rlar);
        }
    }
}