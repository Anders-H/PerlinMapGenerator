namespace PerlinMapGenerator;

public class PresetSize
{
    public int Width { get; }
    public int Height { get; }

    public PresetSize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public override string ToString() =>
        $"{Width} x {Height}";
}