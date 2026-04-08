#nullable enable
using System.Windows.Forms;

namespace PerlinMapGenerator;

public partial class ExportDialog : Form
{
    public Document? Document { get; set; }

    public ExportDialog()
    {
        InitializeComponent();
    }
}