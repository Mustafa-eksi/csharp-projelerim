using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GirisCikis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=HOSAF-WINDOWS;Initial Catalog=GirisCikis;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string kullanici_adi = textBox1.Text;
            string parola = textBox2.Text;
            SqlCommand sorgum = new SqlCommand("select count(*) from Kullanicilar where kullanici_adi='"+kullanici_adi+"' and parola='"+parola+"'", conn);
            SqlDataReader reader = sorgum.ExecuteReader();
            if (reader.Read())
            {
                if(Convert.ToInt32(reader[0]) == 0) // kullanýcý bilgileri yanlýþ
                {
                    MessageBox.Show("Kullanýcý bilgileri yanlýþ.");
                    return;
                }
                else // kullanýcý bilgileri doðru
                {
                    Form2 form2 = new Form2();
                    form2.kullanici_adi = kullanici_adi;
                    this.Hide();
                    form2.Show();
                }
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kayit k = new Kayit();
            conn.Close();
            k.Show();
            this.Hide();
        }
    }
}