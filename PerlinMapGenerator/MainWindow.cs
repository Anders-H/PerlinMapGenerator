#nullable enable
using PerlinMapGenerator.Dialogs;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace PerlinMapGenerator;

public partial class MainWindow : Form
{
    private Bitmap? _bitmap;
    private readonly Document _document;
    private double _zoomFactor;

    public MainWindow()
    {
        _document = new Document();
        _zoomFactor = 1.0;
        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        SetPictureBoxSize();
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

        if (_document.ColorLayers.Count < 2)
        {
            lblStatus.Text = @"Render failed: Too few colors registered.";
            return;
        }

        var exception = "";

        try
        {
            _bitmap = new Bitmap(_document.Width, _document.Height);
            var fastBitmap = new FastBitmap(_bitmap);
            var perlinNoiseGenerator = new PerlinNoiseGenerator();
            fastBitmap.Lock(FastBitmapLockFormat.Format32bppRgb);
            perlinNoiseGenerator.Render(fastBitmap, _document);
            fastBitmap.Unlock();
        }
        catch (Exception ex)
        {
            exception = $" (with {ex.GetType().Name}: {ex.Message})";
        }

        lblStatus.Text = $@"Render finished at {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}{exception}.";
    }

    private void MainWindow_Resize(object sender, EventArgs e) =>
        picMap.Invalidate();

    private void panel1_Resize(object sender, EventArgs e) =>
        SetPictureBoxSize();

    private void MainWindow_Shown(object sender, EventArgs e) =>
        Refresh();

    private void SetPictureBoxSize()
    {
        picMap.Width = (int)(_document.Width * _zoomFactor);
        picMap.Height = (int)(_document.Height * _zoomFactor);
        picMap.Left = (panel1.Width / 2) - (picMap.Width / 2);
        picMap.Top = (panel1.Height / 2) - (picMap.Height / 2);
    }

    private void picMap_Paint(object sender, PaintEventArgs e)
    {
        if (_bitmap == null)
            Render();

        if (_bitmap == null)
            return;

        e.Graphics.InterpolationMode = _zoomFactor < 0.9
            ? InterpolationMode.HighQualityBicubic
            : InterpolationMode.NearestNeighbor;

        if (_zoomFactor is > 0.9 and < 1.1)
            e.Graphics.DrawImage(_bitmap, 0, 0);
        else
            e.Graphics.DrawImage(_bitmap, 0, 0, picMap.Width, picMap.Height);
    }

    private void imageSizeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new SizeDialog();
        x.Document = _document;

        if (x.ShowDialog(this) == DialogResult.OK)
        {
            SetPictureBoxSize();
            ApplyChanges();
        }
    }

    private void ApplyChanges()
    {
        Render();
        picMap.Invalidate();
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
        x.Document = _document;
        x.ApplyDelegate = ApplyChanges;
        
        if (x.ShowDialog(this) == DialogResult.OK)
            ApplyChanges();
    }

    private void btnMapAttributes_Click(object sender, EventArgs e) =>
        mapAttributesToolStripMenuItem_Click(sender, e);

    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
#if !DEBUG
        if (e.CloseReason != CloseReason.UserClosing)
            return;

        if (MessageBox.Show(this, @"Are you sure you want to quit?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            e.Cancel = true;
#endif
    }

    private void toolStripZoom25_Click(object sender, EventArgs e)
    {
        btnZoomIn.Enabled = true;
        btnZoomOut.Enabled = false;
        toolStripZoom25.Checked = true;
        toolStripZoom50.Checked = false;
        toolStripZoom100.Checked = false;
        toolStripZoom200.Checked = false;
        _zoomFactor = 0.25;
        SetPictureBoxSize();
        picMap.Invalidate();
    }

    private void toolStripZoom50_Click(object sender, EventArgs e)
    {
        btnZoomIn.Enabled = true;
        btnZoomOut.Enabled = true;
        toolStripZoom25.Checked = false;
        toolStripZoom50.Checked = true;
        toolStripZoom100.Checked = false;
        toolStripZoom200.Checked = false;
        _zoomFactor = 0.5;
        SetPictureBoxSize();
        picMap.Invalidate();
    }

    private void toolStripZoom100_Click(object sender, EventArgs e)
    {
        btnZoomIn.Enabled = true;
        btnZoomOut.Enabled = true;
        toolStripZoom25.Checked = false;
        toolStripZoom50.Checked = false;
        toolStripZoom100.Checked = true;
        toolStripZoom200.Checked = false;
        _zoomFactor = 1.0;
        SetPictureBoxSize();
        picMap.Invalidate();
    }

    private void toolStripZoom200_Click(object sender, EventArgs e)
    {
        btnZoomIn.Enabled = false;
        btnZoomOut.Enabled = true;
        toolStripZoom25.Checked = false;
        toolStripZoom50.Checked = false;
        toolStripZoom100.Checked = false;
        toolStripZoom200.Checked = true;
        _zoomFactor = 2.0;
        SetPictureBoxSize();
        picMap.Invalidate();
    }

    private void btnZoomOut_Click(object sender, EventArgs e)
    {
        if (toolStripZoom50.Checked)
            toolStripZoom25_Click(sender, e);
        else if (toolStripZoom100.Checked)
            toolStripZoom50_Click(sender, e);
        else if (toolStripZoom200.Checked)
            toolStripZoom100_Click(sender, e);
    }

    private void btnZoomIn_Click(object sender, EventArgs e)
    {
        if (toolStripZoom25.Checked)
            toolStripZoom50_Click(sender, e);
        else if (toolStripZoom50.Checked)
            toolStripZoom100_Click(sender, e);
        else if (toolStripZoom100.Checked)
            toolStripZoom200_Click(sender, e);
    }
}