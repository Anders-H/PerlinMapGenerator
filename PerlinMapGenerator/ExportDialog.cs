#nullable enable
using System;
using System.Windows.Forms;

namespace PerlinMapGenerator;

public partial class ExportDialog : Form
{
    public ExportFormat Format { get; private set; }

    public ExportDialog()
    {
        Format = ExportFormat.Bmp;
        InitializeComponent();
    }

    private void ExportDialog_Load(object sender, EventArgs e)
    {
        radioBmp.Checked = true;
    }

    private void btnOk_Click(object sender, EventArgs e)
    {
        if (radioBmp.Checked)
        {
            Format = ExportFormat.Bmp;
        }
        else if (radioPng.Checked)
        {
            Format = ExportFormat.Png;
        }
        else if (radioJson.Checked)
        {
            Format = ExportFormat.Json;
        }
        else if (radioCs.Checked)
        {
            Format = ExportFormat.Cs;
        }
        else
        {
            throw new SystemException("This is a bug. No radio button is selected.");
        }

        DialogResult = DialogResult.OK;
    }
}