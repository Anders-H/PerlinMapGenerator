#nullable enable
using System;
using System.Windows.Forms;

namespace PerlinMapGenerator.Dialogs.ColorDialogs;

public partial class AddColorDialog : Form
{
    private static readonly Random Random;
    public ColorLayer? NewColorLayer { get; private set; }

    static AddColorDialog()
    {
        Random ??= new Random();
    }

    public AddColorDialog()
    {
        InitializeComponent();
    }

    private void AddColorDialog_Load(object sender, EventArgs e)
    {
        txtName.Text = @"New layer";
        var color = System.Drawing.Color.FromArgb(255, Random.Next(256), Random.Next(256), Random.Next(256));
        txtColor.Text = $@"{color.R:n0}, {color.G:n0}, {color.B:n0}";
        btnColor.BackColor = color;
        btnColor.Tag = color;
        btnColor.ForeColor = color.GetBrightness() < 0.5f ? System.Drawing.Color.White : System.Drawing.Color.Black;
        trbHighestValue.Value = Random.Next(10, 91);
        lblHighestValue.Text = trbHighestValue.Value.ToString("n0");
    }

    private void trbHighestValue_ValueChanged(object sender, EventArgs e) =>
        lblHighestValue.Text = trbHighestValue.Value.ToString("n0");

    private void trbHighestValue_Scroll(object sender, EventArgs e) =>
        trbHighestValue_ValueChanged(sender, e);

    private void btnOk_Click(object sender, EventArgs e)
    {
        NewColorLayer = new ColorLayer(trbHighestValue.Value, txtName.Text.Trim(), (System.Drawing.Color)btnColor.Tag);
        DialogResult = DialogResult.OK;
    }
}