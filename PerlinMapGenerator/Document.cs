#nullable enable
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using IniParser;

namespace PerlinMapGenerator;

public class Document
{
    public int Width { get; set; }
    public int Height { get; set; }
    public float Scale { get; set; }
    public int Octaves { get; set; }
    public float Persistence { get; set; }
    public float Lacunarity { get; set; }
    public int Seed { get; set; }
    public ColorLayerList ColorLayers { get; }

    public Document()
    {
        Width = 320;
        Height = 320;
        Scale = 100f;
        Octaves = 5;
        Persistence = 50;
        Lacunarity = 20;
        Seed = 10000;

        ColorLayers =
        [
            new ColorLayer(10, "Djupvatten", Color.FromArgb(255, 0, 0, 80)),
            new ColorLayer(20, "Kust", Color.FromArgb(255, 200, 200, 60)),
            new ColorLayer(30, "Gräs", Color.FromArgb(255, 34, 139, 34)),
            new ColorLayer(60, "Kullar", Color.FromArgb(255, 130, 120, 80)),
            new ColorLayer(70, "Berg", Color.FromArgb(255, 160, 205, 200)),
            new ColorLayer(100, "Glaciär", Color.FromArgb(255, 255, 255, 255))
        ];
    }

    public void SortColorLayers() =>
        ColorLayers.SortColorLayers();

    public void Save(string filePath)
    {
        var raw = new StringBuilder();
        raw.AppendLine("[File Version]");
        raw.AppendLine("File Type = Perlin Map File (WinSoft)");
        raw.AppendLine("Version = 1.0");
        raw.AppendLine("[Perlin Settings]");
        raw.AppendLine($"Width = {Width}");
        raw.AppendLine($"Height = {Height}");
        raw.AppendLine($"Octaves = {Octaves}");
        raw.AppendLine($"Seed = {Seed}");
        raw.AppendLine($"Scale = {Scale.ToString("n1", CultureInfo.InvariantCulture)}");
        raw.AppendLine($"Persistence = {Persistence.ToString("n1", CultureInfo.InvariantCulture)}");
        raw.AppendLine($"Lacunarity = {Lacunarity.ToString("n1", CultureInfo.InvariantCulture)}");
        raw.AppendLine("[Color Layers]");
        var colorIndex = 0;

        foreach (var colorLayer in ColorLayers)
        {
            var n = ColorLayer.EncodeStepName(colorLayer.Name);
            raw.AppendLine($"Color{colorIndex:0000} = {n}|{colorLayer.HighestValue}|{colorLayer.ColorString}");
            colorIndex++;
        }

        var parser = new Parser(raw.ToString());

        if (parser.TryParse(out var message, out var iniFile))
        {
            var data = iniFile.Render();
            File.WriteAllText(filePath, data);
        }
        else
        {
            throw new SystemException($"Failed to construct data file: {message}");
        }
    }
}