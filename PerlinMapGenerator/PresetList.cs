using PerlinMapGenerator.Dialogs.ColorDialogs;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace PerlinMapGenerator;

public class PresetList : List<Preset>
{
    private int _width;
    private int _height;

    public PresetList(int width, int height)
    {
        _width = width;
        _height = height;
        Add(new Preset("Blank", GetBlankPreset()));
        Add(new Preset("Tropical Beach", GetTropicalBeachPreset()));
        Add(new Preset("Heaven", GetHeavenPreset()));
        Add(new Preset("Hell", GetHellPreset()));
    }

    private static int RandomSeed =>
        AddColorDialog.Random.Next(1, 1000001);

    private static Document GetBlankPreset()
    {
        var d = new Document();
        d.ColorLayers.Clear();
        d.ColorLayers.Add(new ColorLayer(30, "Black", Color.Black));
        d.ColorLayers.Add(new ColorLayer(100, "White", Color.White));
        d.Seed = RandomSeed;
        return d;
    }

    private static Document GetTropicalBeachPreset()
    {
        var d = new Document
        {
            Octaves = 6,
            Seed = 313374,
            Scale = 98.0f,
            Persistence = 53.9f,
            Lacunarity = 20.0f
        };

        d.ColorLayers.Clear();
        d.ColorLayers.Add(new ColorLayer(10, "Sea", Color.FromArgb(255, 0, 60, 215)));
        d.ColorLayers.Add(new ColorLayer(17, "Beach", Color.FromArgb(255, 252, 228, 67)));
        d.ColorLayers.Add(new ColorLayer(30, "Woods", Color.FromArgb(255, 0, 128, 0)));
        d.ColorLayers.Add(new ColorLayer(35, "Mountain", Color.FromArgb(255, 128, 128, 128)));
        d.ColorLayers.Add(new ColorLayer(45, "High mountain", Color.FromArgb(255, 192, 192, 192)));
        d.ColorLayers.Add(new ColorLayer(100, "Glacier", Color.FromArgb(255, 247, 247, 247)));
        return d;
    }

    private static Document GetHeavenPreset()
    {
        var d = new Document();

        return d;
    }

    private static Document GetHellPreset()
    {
        var d = new Document();

        return d;
    }
}