#nullable enable
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace PerlinMapGenerator;

public class Exporter
{
    public static void ExportBmp(Document document, string fileName)
    {
        using var bitmap = GetBitmap(document);
        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
    }

    public static void ExportPng(Document document, string fileName)
    {
        using var bitmap = GetBitmap(document);
        bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
    }

    public static void ExportJson(Document document, string fileName)
    {
        var array = GetArray(document);

        if (array == null)
            throw new SystemException("Failed to render array.");

        var s = new StringBuilder();
        s.AppendLine("{");
        var index = 0;
        s.AppendLine(@"   ""colorLayers"": [");
        foreach (var documentColorLayer in document.ColorLayers)
        {
            var n = Clean(documentColorLayer.Name);
            var c = $"{documentColorLayer.Color.R}, {documentColorLayer.Color.G}, {documentColorLayer.Color.B}";
            var comma = documentColorLayer == document.ColorLayers.Last() ? "" : ",";
            s.AppendLine($@"      {{""index"": {index}, ""name"": ""{n}"", ""color"": [{c}]}}{comma}");
            index++;
        }

        s.AppendLine("   ],");
        s.AppendLine(@"   ""mapData"": [");

        for (var y = 0; y < array.GetLength(1); y++)
        {
            s.Append("      [");

            for (var x = 0; x < array.GetLength(0); x++)
            {
                var comma = x == array.GetLength(0) - 1 ? "" : ", ";
                s.Append($"{array[x, y]}{comma}");
            }

            var rowComma = y == array.GetLength(1) - 1 ? "" : ",";
            s.AppendLine($"]{rowComma}");
        }

        s.AppendLine("   ]");
        s.AppendLine("}");
        File.WriteAllText(fileName, s.ToString());
    }

    public static void ExportCs(Document document, string fileName)
    {
        var array = GetArray(document);

        if (array == null)
            throw new SystemException("Failed to render array.");

        var s = new StringBuilder();
        s.AppendLine(@"using System.Drawing;

namespace KillPerlinExportTest;

public class PerlinNoiseMap
{
    private readonly PerlinNoiseMapColorLayer[] _layerDefinitions;
    private readonly int[,] _map;

    public PerlinNoiseMap()
    {
        _layerDefinitions =
        [");

        var index = 0;

        foreach (var documentColorLayer in document.ColorLayers)
        {
            var n = Clean(documentColorLayer.Name);
            var c = $"{documentColorLayer.Color.R}, {documentColorLayer.Color.G}, {documentColorLayer.Color.B}";
            var comma = documentColorLayer == document.ColorLayers.Last() ? "" : ",";
            s.AppendLine($@"            new(index: {index}, name: ""{n}"", color: Color.FromArgb(255, {c})){comma}");
            index++;
        }

        s.AppendLine(@"        ];

        _map = new[,]
        {");

        for (var y = 0; y < array.GetLength(1); y++)
        {
            s.Append("            {");
            
            for (var x = 0; x < array.GetLength(0); x++)
            {
                var comma = x == array.GetLength(0) - 1 ? "" : ", ";
                s.Append($"{array[x, y]}{comma}");
            }

            var rowComma = y == array.GetLength(1) - 1 ? "" : ",";
            s.AppendLine($"}}{rowComma}");
        }

        s.Append(@"        };
    }

    public class PerlinNoiseMapColorLayer
    {
        public int Index { get; }
        public string Name { get; }
        public Color Color { get; }

        public PerlinNoiseMapColorLayer(int index, string name, Color color)
        {
            Index = index;
            Name = name;
            Color = color;
        }
    }
}");

        File.WriteAllText(fileName, s.ToString());
    }

    private static string Clean(string? s)
    {
        if (s == null)
            return "";

        var result = s
            .Replace("\r\n", " ")
            .Replace("\n", " ")
            .Replace("\r", " ")
            .Replace("\t", " ")
            .Replace("\"", "")
            .Replace("'", "");

        while (result.Contains("  "))
            result = result.Replace("  ", " ");

        return result.Trim();
    }

    private static Bitmap GetBitmap(Document document)
    {
        var bitmap = new Bitmap(document.Width, document.Height);
        var fastBitmap = new FastBitmap(bitmap);
        var perlinNoiseGenerator = new PerlinNoiseGenerator();
        fastBitmap.Lock(FastBitmapLockFormat.Format32bppRgb);
        perlinNoiseGenerator.RenderToBitmap(fastBitmap, document);
        fastBitmap.Unlock();
        return bitmap;
    }

    private static int[,]? GetArray(Document document)
    {
        var perlinNoiseGenerator = new PerlinNoiseGenerator();
        var array = perlinNoiseGenerator.RenderToArray(document);
        return array;
    }
}