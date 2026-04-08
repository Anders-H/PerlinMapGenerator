#nullable enable
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PerlinMapGenerator.Dialogs.ColorDialogs;

public partial class EditColorDialog : Form
{
    public ColorLayer? ColorLayer { get; set; }

    public EditColorDialog()
    {
        InitializeComponent();
    }

    private void EditColorDialog_Load(object sender, EventArgs e)
    {
        if (ColorLayer == null)
            throw new SystemException();

        Text = $@"Edit Color ({ColorLayer.ColorString}) - {ColorLayer.Name} at <= {ColorLayer.HighestValue}";
        txtName.Text = ColorLayer.EncodeStepName(ColorLayer.Name);
        var color = ColorLayer.Color;
        txtColor.Text = $@"{color.R:n0}, {color.G:n0}, {color.B:n0}";
        btnColor.BackColor = color;
        btnColor.Tag = color;
        btnColor.ForeColor = color.GetBrightness() < 0.5f ? System.Drawing.Color.White : System.Drawing.Color.Black;
        trbHighestValue.Value = ColorLayer.HighestValue;
        lblHighestValue.Text = trbHighestValue.Value.ToString("n0");
    }

    private void trbHighestValue_ValueChanged(object sender, EventArgs e) =>
        lblHighestValue.Text = trbHighestValue.Value.ToString("n0");

    private void trbHighestValue_Scroll(object sender, EventArgs e) =>
        trbHighestValue_ValueChanged(sender, e);

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

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (ColorLayer == null)
            throw new SystemException();

        var name = ColorLayer.EncodeStepName(txtName.Text);

        if (string.IsNullOrWhiteSpace(name))
        {
            txtName.Focus();
            MessageBox.Show(this, @"Please enter a name for this color layer.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        ColorLayer.Name = name;
        ColorLayer.Color = (System.Drawing.Color)btnColor.Tag;
        ColorLayer.HighestValue = trbHighestValue.Value;
        DialogResult = DialogResult.OK;
    }

    private void txtName_Validating(object sender, System.ComponentModel.CancelEventArgs e) =>
        txtName.Text = ColorLayer.EncodeStepName(txtName.Text);
}