#nullable enable
using PerlinMapGenerator.Dialogs;
using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace PerlinMapGenerator;

public partial class MainWindow : Form
{
    private Bitmap? _bitmap;
    private readonly Document _document;

    public MainWindow()
    {
        _document = new Document();
        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
    }

    private void Render()
    {
        if (_bitmap != null)
        {
            try
            {
                _bitmap.Dispose();
            }
            catch
            {
                // ignored
            }

            _bitmap = null;
        }

        try
        {
            picMap.Width = _document.Width;
            picMap.Height = _document.Height;
            picMap.Left = (panel1.Width / 2) - (_document.Width / 2);
            picMap.Top = (panel1.Height / 2) - (_document.Height / 2);
            _bitmap = new Bitmap(_document.Width, _document.Height);
            var fastBitmap = new FastBitmap(_bitmap);
            var perlinNoiseGenerator = new PerlinNoiseGenerator();
            fastBitmap.Lock(FastBitmapLockFormat.Format32bppRgb);
            perlinNoiseGenerator.Render(fastBitmap, _document);
            fastBitmap.Unlock();
        }
        catch
        {
            // ignored
        }
    }

    private void MainWindow_Resize(object sender, EventArgs e)
    {
        picMap.Invalidate();
    }

    private void MainWindow_Shown(object sender, EventArgs e)
    {
        Refresh();
    }

    private void picMap_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.White);
        e.Graphics.DrawLine(Pens.Red, 0, 0, 100, 100);
        
        if (_bitmap == null)
            Render();

        if (_bitmap != null)
            e.Graphics.DrawImage(_bitmap, 0, 0);
    }

    private void imageSizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new SizeDialog();
        x.Document = _document;

        if (x.ShowDialog(this) == DialogResult.OK)
        {
            Render();
            picMap.Invalidate();
        }
    }

    private void toolStripButton1_Click(object sender, EventArgs e) =>
        imageSizeToolStripMenuItem_Click(sender, e);

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
        MessageBox.Show(this, $@"Perlin Map Generator version {version[0]}.{version[1]} written by Anders Hesselbom.", @"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void mapAttributesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new MapAttributesDialog();
    }

    private void btnMapAttributes_Click(object sender, EventArgs e) =>
        mapAttributesToolStripMenuItem_Click(sender, e);
}