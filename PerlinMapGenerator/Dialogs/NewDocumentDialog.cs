#nullable enable
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PerlinMapGenerator.Dialogs;

public partial class NewDocumentDialog : Form
{
    private Document? _currentDocument;
    private Bitmap? _currentBitmap;

    public NewDocumentDialog()
    {
        InitializeComponent();
    }

    public Document Document =>
        _currentDocument ?? new Document();

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if (_currentDocument == null || _currentBitmap == null)
            return;

        if (_currentBitmap.Width > pictureBox1.ClientRectangle.Width || _currentBitmap.Height > pictureBox1.ClientRectangle.Height)
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        }
        else
        {
            e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        }

        e.Graphics.DrawImage(_currentBitmap, 0, 0, pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
    }

    private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboPreset.SelectedItem is not Preset selectedPreset)
            return;

        _currentDocument = selectedPreset.Document;
        Render();
        pictureBox1.Invalidate();
        UpdateListView();
    }

    private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_currentDocument == null)
            return;

        if (cboSize.SelectedItem is not PresetSize selectedSize)
            return;

        _currentDocument.Width = selectedSize.Width;
        _currentDocument.Height = selectedSize.Height;
        Render();
        pictureBox1.Invalidate();
        UpdateListView();
    }

    private void btnMutate_Click(object sender, EventArgs e)
    {
        if (_currentDocument == null || _currentBitmap == null)
            return;

        _currentDocument.Mutate();
        Render();
        pictureBox1.Invalidate();
        UpdateListView();
    }

    private void Render()
    {
        if (_currentDocument == null)
            return;

        if (_currentBitmap != null)
        {
            try
            {
                _currentBitmap.Dispose();
            }
            catch
            {
                // ignored
            }

            _currentBitmap = null;
        }

        if (_currentDocument!.ColorLayers.Count < 2)
            _currentDocument = new Document();
        
        try
        {
            _currentBitmap = new Bitmap(_currentDocument.Width, _currentDocument.Height);
            var fastBitmap = new FastBitmap(_currentBitmap);
            var perlinNoiseGenerator = new PerlinNoiseGenerator();
            fastBitmap.Lock(FastBitmapLockFormat.Format32BppRgb);
            perlinNoiseGenerator.RenderToBitmap(fastBitmap, _currentDocument);
            fastBitmap.Unlock();
        }
        catch
        {
            _currentDocument = new Document();
        }
    }

    private void NewDocumentDialog_Shown(object sender, EventArgs e)
    {
        Refresh();
        // ReSharper disable once CollectionNeverUpdated.Local
        var presets = new PresetList();

        foreach (var preset in presets)
            cboPreset.Items.Add(preset);

        // ReSharper disable once CollectionNeverUpdated.Local
        var sizes = new PresetSizeList();

        foreach (var sizePreset in sizes)
            cboSize.Items.Add(sizePreset);

        cboSize.SelectedIndex = 3;
        cboPreset.SelectedIndex = 0;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (_currentDocument == null)
            throw new SystemException("Confusion!!!");

        if (_currentDocument.ColorLayers.Count < 2)
        {
            MessageBox.Show(this, @"You need at least 2 color layers to create a document.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (_currentDocument.ColorLayers.Last().HighestValue < 100)
        {
            MessageBox.Show(this, @"The last color layer must have a highest value of 100.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult = DialogResult.OK;
    }

    private void UpdateListView()
    {
        listView1.Items.Clear();
        var item = listView1.Items.Add("Width");
        item.SubItems.Add(Width.ToString("n0"));
        item = listView1.Items.Add("Height");
        item.SubItems.Add(Height.ToString("n0"));
        item = listView1.Items.Add("Octaves");
        item.SubItems.Add((_currentDocument?.Octaves ?? 0).ToString("n1"));
        item = listView1.Items.Add("Seed");
        item.SubItems.Add((_currentDocument?.Seed ?? 0).ToString("n0"));
        item = listView1.Items.Add("Scale");
        item.SubItems.Add((_currentDocument?.Scale ?? 0).ToString("n1"));
        item = listView1.Items.Add("Persistence");
        item.SubItems.Add((_currentDocument?.Persistence ?? 0).ToString("n1"));
        item = listView1.Items.Add("Lacunarity");
        item.SubItems.Add((_currentDocument?.Lacunarity ?? 0).ToString("n1"));
    }
}