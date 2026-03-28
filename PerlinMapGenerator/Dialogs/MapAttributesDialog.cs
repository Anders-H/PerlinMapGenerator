#nullable enable
using System;
using System.Windows.Forms;

namespace PerlinMapGenerator.Dialogs;

public partial class MapAttributesDialog : Form
{
    public Document? Document { get; set; }
    public Action? ApplyDelegate { get; set; }

    public MapAttributesDialog()
    {
        InitializeComponent();
    }

    private void MapAttributesDialog_Load(object sender, EventArgs e)
    {
        if (Document == null || ApplyDelegate == null)
            throw new SystemException();

        trbScale.Value = (int)Document.Scale;
        trbOctaves.Value = Document.Octaves;
        trbPersistence.Value = (int)Document.Persistence;
        trbLacunarity.Value = (int)Document.Lacunarity;
        trbSeed.Value = Document.Seed;

        lblScale.Text = Document.Scale.ToString("n0");
        lblOctaves.Text = Document.Octaves.ToString("n0");
        lblPersistence.Text = (Document.Persistence / 100f).ToString("n2");
        lblLacunarity.Text = (Document.Lacunarity / 10f).ToString("n1");
        lblSeed.Text = Document.Seed.ToString("n0");
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        CopyToDocument();
        ApplyDelegate?.Invoke();
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        CopyToDocument();
        DialogResult = DialogResult.OK;
    }

    private void CopyToDocument()
    {
        if (Document == null)
            throw new SystemException();

        Document.Scale = trbScale.Value;
        Document.Octaves = trbOctaves.Value;
        Document.Persistence = trbPersistence.Value;
        Document.Lacunarity = trbLacunarity.Value;
        Document.Seed = trbSeed.Value;
    }

    private void trbScale_Scroll(object sender, EventArgs e) =>
        lblScale.Text = trbScale.Value.ToString("n0");

    private void trbScale_ValueChanged(object sender, EventArgs e) =>
        trbScale_Scroll(sender, e);

    private void trbOctaves_Scroll(object sender, EventArgs e) =>
        lblOctaves.Text = trbOctaves.Value.ToString("n0");

    private void trbOctaves_ValueChanged(object sender, EventArgs e) =>
        trbOctaves_Scroll(sender, e);

    private void trbPersistence_Scroll(object sender, EventArgs e) =>
        lblPersistence.Text = (trbPersistence.Value / 100f).ToString("n2");

    private void trbPersistence_ValueChanged(object sender, EventArgs e) =>
        trbPersistence_Scroll(sender,  e);

    private void trbLacunarity_Scroll(object sender, EventArgs e) =>
        lblLacunarity.Text = (trbLacunarity.Value / 10f).ToString("n1");

    private void trbLacunarity_ValueChanged(object sender, EventArgs e) =>
        trbLacunarity_Scroll(sender, e);

    private void trbSeed_Scroll(object sender, EventArgs e) =>
        lblSeed.Text = trbSeed.Value.ToString("n0");

    private void trbSeed_ValueChanged(object sender, EventArgs e) =>
        trbSeed_Scroll(sender, e);
}