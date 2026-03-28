#nullable enable
using System;
using System.Drawing;

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
            new ColorLayer(10, "Djupvatten", Color.FromArgb(0, 0, 0, 80)),
            new ColorLayer(20, "Kust", Color.FromArgb(0, 200, 200, 60)),
            new ColorLayer(30, "Gräs", Color.FromArgb(0, 34, 139, 34)),
            new ColorLayer(60, "Kullar", Color.FromArgb(0, 130, 120, 80)),
            new ColorLayer(70, "Berg", Color.FromArgb(0, 160, 205, 200)),
            new ColorLayer(100, "Glaciär", Color.FromArgb(0, 255, 255, 255))
        ];
    }
}