#nullable enable
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using IniParser;

namespace PerlinMapGenerator;

public class Document
{
    private const string ExpectedFileType = "Perlin Map File (WinSoft)";
    private const string ExpectedVersion = "1.0";
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

    public void Set(Document document)
    {
        Width = document.Width;
        Height = document.Height;
        Scale = document.Scale;
        Octaves = document.Octaves;
        Persistence = document.Persistence;
        Lacunarity = document.Lacunarity;
        Seed = document.Seed;
        ColorLayers.Clear();

        foreach (var layer in document.ColorLayers)
            ColorLayers.Add(new ColorLayer(layer));
    }

    public void SortColorLayers() =>
        ColorLayers.SortColorLayers();

    public void Save(string filePath)
    {
        var raw = new StringBuilder();
        raw.AppendLine("[File Version]");
        raw.AppendLine($"File Type = {ExpectedFileType}");
        raw.AppendLine($"Version = {ExpectedVersion}");
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

    public static Document? Load(string filePath, out string message)
    {
        message = "";
        var fileContents = File.ReadAllText(filePath);
        var parser = new Parser(fileContents);
        var success = parser.TryParse(out var parserMessage, out var iniFile);

        if (!success)
        {
            message = parserMessage;
            return null;
        }

        var fileType = iniFile.GetValue("File Version", "File Type");
        var version = iniFile.GetValue("File Version", "Version");

        if (fileType == null || version == null)
        {
            message = "Invalid file type (code 11).";
            return null;
        }

        if (fileType.SettingValue != ExpectedFileType || version.SettingValue != ExpectedVersion)
        {
            message = "Invalid file type (code 12).";
            return null;
        }

        var widthString = iniFile.GetValue("Perlin Settings", "Width")?.SettingValue ?? "";
        var heightString = iniFile.GetValue("Perlin Settings", "Height")?.SettingValue ?? "";
        var octavesString = iniFile.GetValue("Perlin Settings", "Octaves")?.SettingValue ?? "";
        var seedString = iniFile.GetValue("Perlin Settings", "Seed")?.SettingValue ?? "";
        var scaleString = iniFile.GetValue("Perlin Settings", "Scale")?.SettingValue ?? "";
        var persistenceString = iniFile.GetValue("Perlin Settings", "Persistence")?.SettingValue ?? "";
        var lacunarityString = iniFile.GetValue("Perlin Settings", "Lacunarity")?.SettingValue ?? "";

        if (!(int.TryParse(widthString, out var width) && int.TryParse(heightString, out var height) && int.TryParse(octavesString, out var octaves) && int.TryParse(seedString, out var seed) && float.TryParse(scaleString, NumberStyles.Float, CultureInfo.InvariantCulture, out var scale) && float.TryParse(persistenceString, NumberStyles.Float, CultureInfo.InvariantCulture, out var persistence) && float.TryParse(lacunarityString, NumberStyles.Float, CultureInfo.InvariantCulture, out var lacunarity)))
        {
            message = "Failed to parse one or more Perlin settings (code 13).";
            return null;
        }

        var colors = iniFile.GetValuesOnly("Color Layers");

        if (colors.Count < 2)
        {
            message = "Failed to parse color layers (code 14).";
            return null;
        }

        var document = new Document
        {
            Width = width,
            Height = height,
            Octaves = octaves,
            Seed = seed,
            Scale = scale,
            Persistence = persistence,
            Lacunarity = lacunarity
        };

        document.ColorLayers.Clear();

        foreach (var color in colors.Where(color => !string.IsNullOrWhiteSpace(color)))
        {
            var colorLayer = ColorLayer.Parse(color);

            if (colorLayer == null)
            {
                message = "Failed to parse color layers (code 15).";
                return null;
            }

            document.ColorLayers.Add(colorLayer);
        }

        return !document.Check(out message) ? null : document;
    }

    private bool Check(out string message)
    {
        message = "";

        if (Width is < 32 or > 512)
        {
            message = "Width must be 32 to 512.";
            return false;
        }

        if (Height is < 32 or > 512)
        {
            message = "Height must be 32 to 512.";
            return false;
        }

        if (Scale is < 10 or > 150)
        {
            message = "Scale must be 10 to 150.";
            return false;
        }

        if (Octaves is < 1 or > 20)
        {
            message = "Octaves must be 1 to 20.";
            return false;
        }

        if (Persistence is < 1f or > 100f)
        {
            message = "Persistence must be 1.0 to 100.0.";
            return false;
        }

        if (Lacunarity is < 1f or > 50f)
        {
            message = "Lacunarity must be 1.0 to 50.0.";
            return false;
        }

        if (ColorLayers.Count < 2)
        {
            message = "At least two color layers are required.";
            return false;
        }

        return true;
    }
}