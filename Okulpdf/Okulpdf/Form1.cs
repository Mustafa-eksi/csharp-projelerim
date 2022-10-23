using MuPDFCore;
using MuPDFCore.MuPDFRenderer;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Okulpdf
{
    public partial class Form1 : Form
    {
        int page = 0, i = 0;
        double zoom = 1;
        string pathout = "C:\\Users\\musta\\OneDrive\\Masaüstü\\pdfout\\";
        string documentpath = "C:\\Users\\musta\\OneDrive\\Masaüstü\\dosyalarým\\Okunacaklar\\yabancý_seyahatnamelere_göre_osmanlýda_hayvan.pdf";
        public Form1()
        {
            InitializeComponent();
        }
        MuPDFContext ctx = new();
        public MuPDFDocument document;

        private void ReadPage(MuPDFDocument d)
        {
            pictureBox1.Image = null;
            d.SaveImage(page, zoom, PixelFormats.RGBA, pathout+"output"+page.ToString()+ i.ToString() + ".png", RasterOutputFileTypes.PNG);
            
            pictureBox1.Image = Image.FromFile(pathout + "output" + page.ToString() + i.ToString() + ".png");
            i++;
        }
        private void OpenDocument(string path)
        {
            document = new(ctx, path);
            ReadPage(document);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenDocument(documentpath);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width - 30;
            //pictureBox1.Height = this.Height;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            zoom += 0.1;
            textBox2.Text = (zoom * 100).ToString();
            ReadPage(document);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(zoom > 1)
            {
                zoom -= 0.1;
                textBox2.Text = (zoom * 100).ToString();
                ReadPage(document);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = "pdf";
            ofd.ShowDialog();
            documentpath = ofd.FileName;
            OpenDocument(documentpath);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(int.TryParse(textBox1.Text, out page))
            {
                page--;
                ReadPage(document);
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int a = 0;
            if (int.TryParse(textBox2.Text, out a))
            {
                zoom = a / 100;
                ReadPage(document);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(page > 0)
            {
                page--;
                textBox1.Text = (page + 1).ToString();
                ReadPage(document);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (document.Pages.Count-1 > page)
            {
                page++;
                textBox1.Text = (page+1).ToString();
                ReadPage(document);
            }
        }
    }
}