namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int no = Convert.ToInt32(textBox1.Text);
            int kacinci = listBox1.Items.IndexOf(no.ToString());
            textBox2.Text = listBox2.Items[kacinci] + " " + listBox3.Items[kacinci];
        }
    }
}