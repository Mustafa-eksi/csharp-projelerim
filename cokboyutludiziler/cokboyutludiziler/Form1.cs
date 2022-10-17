namespace cokboyutludiziler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,,] dizi = { { { 1, 2}, {3, 4 }, { 5, 6} }, { {7, 8 }, {9, 10 }, {11, 12 } } };
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < dizi.GetLength(0); i++)
            {
               listBox1.Items.Add(dizi[i,0,0]);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}