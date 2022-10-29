using MuPDFCore;
using MuPDFCore.MuPDFRenderer;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;
using Avalonia.Media;
using Color = System.Drawing.Color;
using Brush = System.Drawing.Brush;
using Brushes = System.Drawing.Brushes;

namespace Okulpdf
{
    public partial class Form1 : Form
    {
        int page = 0;
        double zoom = 1;
        string documentpath = "C:\\Users\\musta\\yabanci_seyahatnamelere_gore_osmanlida_hayvan.pdf";
        int vslider_old = 0;
        int hslider_old = 0;
        MuPDFCore.Rectangle r;
        
        public Form1()
        {
            InitializeComponent();
        }
        MuPDFContext ctx = new();
        public MuPDFDocument document;
        
        private void ReadPage(MuPDFDocument d, bool reset = false)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            
            if (reset)
            {
                r.X0 = 0;
                r.Y0 = 0;
                r.X1 = (int)d.Pages[page].Bounds.Width;
                r.Y1 = (int)d.Pages[page].Bounds.Height;
            }
            
            //pictureBox1.Image = null;
            //DateTime btimes = DateTime.Now;
            byte[] bytes = d.Render(page, r, zoom, PixelFormats.RGBA);
            //DateTime atimes = DateTime.Now;
            //MessageBox.Show("Süre: " + (atimes - btimes));
            float x = r.X0 * (float)zoom;
            float y = r.Y0 * (float)zoom;
            float x2 = r.X1 * (float)zoom;
            float y2 = r.Y1 * (float)zoom;
            RoundedRectangle roundedRectangle = new MuPDFCore.Rectangle(x, y, x2, y2).Round();
            int w = roundedRectangle.Width;
            int h = roundedRectangle.Height;
            //MessageBox.Show("bytes length: " + bytes.Length + ", w*h*4: "+(w*h*4).ToString() + ", (bytes.length/4)/h ve width" + (bytes.Length / 4) / h + " ve " + r.Width );
            Bitmap bitmap = new Bitmap(w, h, PixelFormat.Format32bppPArgb);
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            int wb = w * 4;
            int i = 0;
            for (int j = 0; j < w; j++)
            {
                int jb = j * 4;
                for (int k = 0; k < h; k++)
                {
                    int pos = wb*k + j*4;
                    int a = bytes[pos + 3];
                    //int r = bytes[pos];
                    //int b = bytes[pos + 1];
                    //int g = bytes[pos + 2];
                    bitmap.SetPixel(j, k, Color.FromArgb(a, 0, 0, 0));
                    i += 4;
                }
            }
            //Graphics grap = Graphics.FromImage(bitmap);
            graphics.Clear(Color.FromArgb(255, 255, 255, 255));
            graphics.DrawImage(bitmap, 1, 1, bitmap.Width, bitmap.Height);
            
            //pictureBox1.Image = bitmap;
        }
        /*private void OldReadPage(MuPDFDocument d, bool reset=false)
        {
            if(reset)
            {
                r.X0 = 0;
                r.Y0 = 0;
                r.X1 = d.Pages[page].Bounds.Width;
                r.Y1 = d.Pages[page].Bounds.Height;
            }
            pictureBox1.Image = null;
            d.SaveImage(page, r, zoom, PixelFormats.RGBA, pathout+"output"+page.ToString()+ i.ToString() + ".png", RasterOutputFileTypes.PNG);
            
            pictureBox1.Image = Image.FromFile(pathout + "output" + page.ToString() + i.ToString() + ".png");
            i++;
        }*/
        private void OpenDocument(string path)
        {
            document = new(ctx, path);
            ReadPage(document, true);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            OpenDocument(documentpath);
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = this.Width - 60;
            pictureBox1.Height = this.Height - 60;
            hScrollBar1.SetBounds(10, this.Height - 50, this.Width - 50, hScrollBar1.Height);
            vScrollBar1.SetBounds(this.Width-50, 10, vScrollBar1.Width, this.Height-50);

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

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //MessageBox.Show("slider: " + vScrollBar1.Value.ToString());
            if(vslider_old - vScrollBar1.Value > 20)
            {
                r.Y0 -= vScrollBar1.Value;
                r.Y1 -= vScrollBar1.Value;
            }
            else if(vslider_old - vScrollBar1.Value < -20)
            {
                r.Y0 += vScrollBar1.Value;
                r.Y1 += vScrollBar1.Value;
            }
            vslider_old = vScrollBar1.Value;
            ReadPage(document);
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (hslider_old - hScrollBar1.Value > 20)
            {
                r.X0 -= hScrollBar1.Value;
                r.X1 -= hScrollBar1.Value;
            }
            else if (hslider_old - hScrollBar1.Value < -20)
            {
                r.X0 += hScrollBar1.Value;
                r.X1 += hScrollBar1.Value;
            }
            hslider_old = hScrollBar1.Value;
            ReadPage(document);
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