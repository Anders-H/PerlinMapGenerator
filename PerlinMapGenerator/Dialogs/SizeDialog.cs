#nullable enable
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PerlinMapGenerator.Dialogs;

public partial class SizeDialog : Form
{
    public Document? Document { get; set; }

    public SizeDialog()
    {
        InitializeComponent();
    }

    private void SizeDialog_Load(object sender, EventArgs e)
    {
        if (Document == null)
            throw new SystemException();

        txtWidth.Text = Document.Width.ToString();
        txtHeight.Text = Document.Height.ToString();
    }

    private void txtWidth_Validated(object sender, EventArgs e)
    {
        var result = ParseValue(txtWidth.Text, Document.Width);
        txtWidth.Text = result.ToString();
    }

    private void txtHeight_Validated(object sender, EventArgs e)
    {
        var result = ParseValue(txtHeight.Text, Document.Height);
        txtHeight.Text = result.ToString();
    }

    private int ParseValue(string text, int defaultReturn)
    {
        try
        {
            var v = int.Parse(text, NumberStyles.Any, CultureInfo.CurrentCulture);
            
            if (v < 32)
                v = 32;
            else if (v > 8192)
                v = 8192;

            return v;
        }
        catch
        {
            return defaultReturn;
        }
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (Document == null)
            throw new SystemException();

        var width = ParseValue(txtWidth.Text, Document.Width);
        var height = ParseValue(txtHeight.Text, Document.Height);
        Document.Width = width;
        Document.Height = height;
        DialogResult = DialogResult.OK;
    }
}