#nullable enable
using System.Drawing;

namespace PerlinMapGenerator;

public class ColorLayer
{
    public int HighestValue { get; set; }
    public float HighestValueFloat { get; }
    public string Name { get; set; }
    public Color Color { get; set; }

    public ColorLayer(int highestValue, string name, Color color)
    {
        HighestValue = highestValue;
        HighestValueFloat = HighestValue / 100f;
        Name = name;
        Color = color;
    }

    public ColorLayer(ColorLayer original)
    {
        HighestValue = original.HighestValue;
        HighestValueFloat = HighestValue / 100f;
        Name = original.Name;
        Color = original.Color;
    }

    public override string ToString() =>
        $"{Name}: {HighestValueFloat:n2}";

    public string ColorString =>
        $@"{Color.R:n0}, {Color.G:n0}, {Color.B:n0}";

    public static string EncodeStepName(string name) =>
        name.Replace("|", "").Replace(";", "").Replace("=", "").Replace(",", "").Replace("  ", " ").Replace("[", "").Replace("]", "").Trim();

    public static ColorLayer? Parse(string color)
    {

    }
}