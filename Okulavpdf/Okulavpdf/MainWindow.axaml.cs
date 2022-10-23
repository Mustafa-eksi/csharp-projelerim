using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using MuPDFCore.MuPDFRenderer;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using MuPDFCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq;

namespace Okulavpdf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private MuPDFContext Context;
        private MuPDFDocument Document;
        int page = 1;
        private void WindowOpened(object sender, EventArgs e)
        {
            //Render the initial PDF and initialise the PDFRenderer with it.
            //MemoryStream ms = RenderInitialPDF();
            Context = new MuPDFContext();
            MemoryStream ms = new MemoryStream();
            Document = new MuPDFDocument(Context, ref ms, InputFileTypes.PDF);
        }
    }
}
