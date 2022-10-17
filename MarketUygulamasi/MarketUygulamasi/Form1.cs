using System.Windows.Forms;

namespace MarketUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + listBox1.SelectedIndex + ".jpg");
            }
        }
    }
}