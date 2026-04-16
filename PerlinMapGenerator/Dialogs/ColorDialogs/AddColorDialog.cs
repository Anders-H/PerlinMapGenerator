#nullable enable
using System;
using System.Windows.Forms;

namespace PerlinMapGenerator.Dialogs.ColorDialogs;

public partial class AddColorDialog : Form
{
    public static readonly Random Random;
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
        var name = ColorLayer.EncodeStepName(txtName.Text);

        if (string.IsNullOrWhiteSpace(name))
        {
            txtName.Focus();
            MessageBox.Show(this, @"Please enter a name for this color layer.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        NewColorLayer = new ColorLayer(trbHighestValue.Value, name, (System.Drawing.Color)btnColor.Tag);
        DialogResult = DialogResult.OK;
    }

    private void btnColor_Click(object sender, EventArgs e)
    {
        using var x = new ColorDialog();
        x.Color = (System.Drawing.Color)btnColor.Tag;

        if (x.ShowDialog(this) != DialogResult.OK)
            return;

        btnColor.Tag = x.Color;
        btnColor.BackColor = x.Color;
        btnColor.ForeColor = x.Color.GetBrightness() < 0.5f ? System.Drawing.Color.White : System.Drawing.Color.Black;
        txtColor.Text = $@"{x.Color.R:n0}, {x.Color.G:n0}, {x.Color.B:n0}";
    }

    private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
        txtName.Text = ColorLayer.EncodeStepName(txtName.Text);
}