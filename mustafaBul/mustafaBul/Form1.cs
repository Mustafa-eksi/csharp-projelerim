namespace mustafaBul
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.DefaultExt = "txt";
            filedialog.ShowDialog();
            string yazi = File.ReadAllText(filedialog.FileName);
            string bulunacak = textBox2.Text;
            int kactane = 0;
            for (int i = 0; i < yazi.Length - bulunacak.Length + 1; i++)
            {
                string kelime = yazi.Substring(i, bulunacak.Length);
                if (kelime == bulunacak)
                {
                    kactane++;
                }
            }
            textBox1.Text = kactane.ToString();
        }
    }
}