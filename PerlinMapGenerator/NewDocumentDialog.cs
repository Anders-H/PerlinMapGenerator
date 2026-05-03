#nullable enable
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PerlinMapGenerator;

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

        e.Graphics.DrawImage(_currentBitmap, Point.Empty);
    }

    private void cboPreset_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cboPreset.SelectedItem is not Preset selectedPreset)
            return;

        _currentDocument = selectedPreset.Document;
        Render();
        pictureBox1.Invalidate();
    }

    private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        Render();
        pictureBox1.Invalidate();
    }

    private void btnMutate_Click(object sender, EventArgs e)
    {
        if (_currentDocument == null || _currentBitmap == null)
            return;

        //_currentDocument.Mutate();
        Render();
        pictureBox1.Invalidate();
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
            fastBitmap.Lock(FastBitmapLockFormat.Format32bppRgb);
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
        var size = new Size(400, 400);
        // ReSharper disable once CollectionNeverUpdated.Local
        var presets = new PresetList(size.Width, size.Height);

        foreach (var preset in presets)
            cboPreset.Items.Add(preset);

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
}