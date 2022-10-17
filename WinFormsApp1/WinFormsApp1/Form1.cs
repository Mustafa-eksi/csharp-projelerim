namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int yas = 2022 - Convert.ToInt32(textBox1.Text);
            if(yas > 17 && yas < 66)
                textBox2.Text = "Ehliyet alabilir.";
            else
                textBox2.Text = "Ehliyet alamaz.";
        }
    }
}