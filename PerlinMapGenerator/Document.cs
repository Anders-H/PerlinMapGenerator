#nullable enable
using System;

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

    public Document()
    {
        Width = 320;
        Height = 320;
        Scale = 100f;
        Octaves = 5;
        Persistence = 50;
        Lacunarity = 20;
        Seed = 10000;
    }
}