#nullable enable
using PerlinMapGenerator.Dialogs.ColorDialogs;
using System.Drawing;
using System.Globalization;

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
        if (string.IsNullOrWhiteSpace(color))
            return null;

        if (color.IndexOf('|') < 0)
            return null;

        var parts = color.Split('|');

        if (parts.Length < 3)
            return null;

        var name = parts[0].Trim();
        var highestValueString = parts[1].Trim();
        var highestValue = 0;
        var colorString = parts[2].Trim();

        if (int.TryParse(highestValueString, NumberStyles.Any, CultureInfo.InvariantCulture, out var highestValueInt))
            highestValue = highestValueInt;

        if (highestValue < 1)
            highestValue = 1;
        else if (highestValue > 100)
            highestValue = 100;

        if (colorString.IndexOf(',') < 0)
            return null;

        var colorPartsString = colorString.Split(',');

        if (colorPartsString.Length != 3)
            return null;

        if (!int.TryParse(colorPartsString[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var red))
            red = AddColorDialog.Random.Next(0, 256);

        if (!int.TryParse(colorPartsString[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var green))
            green = AddColorDialog.Random.Next(0, 256);

        if (!int.TryParse(colorPartsString[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var blue))
            blue = AddColorDialog.Random.Next(0, 256);

        if (red < 0)
            red = 0;
        else if (red > 255)
            red = 255;

        if (green < 0)
            green = 0;
        else if (green > 255)
            green = 255;

        if (blue < 0)
            blue = 0;
        else if (blue > 255)
            blue = 255;

        return new ColorLayer(highestValue, name, Color.FromArgb(red, green, blue));
    }
}