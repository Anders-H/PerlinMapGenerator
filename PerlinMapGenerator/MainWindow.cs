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
    private string? _filename;
    private Bitmap? _bitmap;
    private Document _document;
    private double _zoomFactor;

    public MainWindow()
    {
        _filename = null;
        _document = new Document();
        _zoomFactor = 1.0;
        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        SetPictureBoxSize();
        UpdateWindowTitle();
    }

    private void UpdateWindowTitle() =>
        Text = string.IsNullOrWhiteSpace(_filename)
            ? @"Perlin Map Generator"
            : $"Perlin Map Generator - [{_filename}]";

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

    private void btnImageSize_Click(object sender, EventArgs e) =>
        imageSizeToolStripMenuItem_Click(sender, e);

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version.ToString().Split('.');
        MessageBox.Show(this, $@"Perlin Map Generator version {version[0]}.{version[1]} written by Anders Hesselbom. For rendering, the FastBitmap class by Luiz Fernando is used.", @"About", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void editColorsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new ColorsDialog();
        x.Document = _document;
        x.ApplyDelegate = ApplyChanges;

        if (x.ShowDialog(this) == DialogResult.OK)
            ApplyChanges();
    }

    private void btnEditColors_Click(object sender, EventArgs e) =>
        editColorsToolStripMenuItem_Click(sender, e);

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(this, @"Are you sure you want to create a new map? All unsaved progress will be lost.", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            return;

        _document = new Document();
        toolStripZoom100_Click(sender, e);
        SetPictureBoxSize();
        Render();
        picMap.Invalidate();
        UpdateWindowTitle();
    }

    private void btnNew_Click(object sender, EventArgs e) =>
        newToolStripMenuItem_Click(sender, e);

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show(this, @"Are you sure you want to open a map? All unsaved progress will be lost.", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            return;

        var x = new OpenFileDialog();
        x.Title = @"Open map";
        x.Filter = @"Perlin Map files (*.pmap)|*.pmap|All files (*.*)|*.*";

        if (x.ShowDialog(this) != DialogResult.OK)
                return;

        var filename = x.FileName;
        Document? document = null;
        string? message = null;

        try
        {
            document = Document.Load(filename, out message);
        }
        catch (Exception exception)
        {
            MessageBox.Show(this, exception.Message, @"Load failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (document == null)
        {
            MessageBox.Show(this, @"Failed to load map. The file you selected is not a correct map file.", @"Load failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (MessageBox.Show(this, $@"Are you sure you want to open a map? All unsaved progress will be lost. {message}".Trim(), Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            return;

        _document = document!;
        toolStripZoom100_Click(sender, e);
        SetPictureBoxSize();
        Render();
        picMap.Invalidate();
        UpdateWindowTitle();
    }

    private void btnOpen_Click(object sender, EventArgs e) =>
        openToolStripMenuItem_Click(sender, e);

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_filename))
        {
            saveAsToolStripMenuItem_Click(sender, e);
            return;
        }

        Save(_filename!);
    }

    private void btnSave_Click(object sender, EventArgs e) =>
        saveToolStripMenuItem_Click(sender, e);

    private void Save(string filename)
    {
        try
        {
            _document.Save(filename);
            _filename = filename;
            UpdateWindowTitle();
            lblStatus.Text = $@"Saved map to {filename} at {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}.";
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, @$"Failed to save file as {filename}: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = $@"Failed to save map to {filename} at {DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}.";
        }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new SaveFileDialog();
        x.Title = @"Save map as";
        x.Filter = @"Perlin Map files (*.pmap)|*.pmap|All files (*.*)|*.*";

        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            _document.Save(x.FileName);
            _filename = x.FileName;
            UpdateWindowTitle();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, @$"Failed to save file as {x.FileName}: {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void exportToolStripMenuItem_Click(object sender, EventArgs e)
    {
        using var x = new ExportDialog();

        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        var format = x.Format;

        switch (format)
        {
            case ExportFormat.Bmp:
                // Export as BMP
                break;
            case ExportFormat.Png:
                // Export as PNG
                break;
            case ExportFormat.Json:
                // Export as JSON
                break;
            case ExportFormat.Cs:
                // Export as C#
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) =>
        Close();
}