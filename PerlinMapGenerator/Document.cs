#nullable enable
namespace PerlinMapGenerator;

public class Document
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Document()
    {
        Width = 320;
        Height = 320;
    }
}