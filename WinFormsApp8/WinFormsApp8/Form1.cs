namespace WinFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            int b = Convert.ToInt32(textBox3.Text);
            textBox2.Text = Math.Sqrt(a*a + b*b).ToString();
            if(radioButton1.Checked == true)
            {
                textBox3.Text = "RadioButton seçili";
                textBox2.Clear();
            }
        }
    }
}