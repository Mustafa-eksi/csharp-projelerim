using System.ComponentModel.Design.Serialization;

namespace TodoUyg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string gorev = textBox1.Text;
            listBox1.Items.Add(dateTimePicker1.Value.ToString() + ", " + gorev);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            else if (listBox2.SelectedIndex != -1)
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string a = listBox1.Items[listBox1.SelectedIndex].ToString();
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox2.Items.Add(a);
            }

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
                listBox1.ClearSelected();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                string a = listBox2.Items[listBox2.SelectedIndex].ToString();
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
                listBox1.Items.Add(a);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
                listBox2.ClearSelected();
        }
    }
}