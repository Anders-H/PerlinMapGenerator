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
        var d = new Document
        {
            Octaves = 5,
            Seed = 68304,
            Scale = 59.0f,
            Persistence = 50.0f,
            Lacunarity = 19.0f
        };

        d.ColorLayers.Clear();
        d.ColorLayers.Add(new ColorLayer(2, "SkyToCloud01", Color.FromArgb(255, 0, 128, 255)));
        d.ColorLayers.Add(new ColorLayer(4, "SkyToCloud02", Color.FromArgb(255, 66, 160, 255)));
        d.ColorLayers.Add(new ColorLayer(6, "SkyToCloud03", Color.FromArgb(255, 151, 203, 255)));
        d.ColorLayers.Add(new ColorLayer(8, "SkyToCloud04", Color.FromArgb(255, 198, 226, 255)));
        d.ColorLayers.Add(new ColorLayer(10, "SkyToCloud05", Color.FromArgb(255, 255, 255, 255)));
        d.ColorLayers.Add(new ColorLayer(12, "SkyToCloud06", Color.FromArgb(255, 183, 219, 255)));
        d.ColorLayers.Add(new ColorLayer(14, "SkyToCloud07", Color.FromArgb(255, 94, 174, 255)));
        d.ColorLayers.Add(new ColorLayer(20, "SkyToCloud08", Color.FromArgb(255, 75, 164, 255)));
        d.ColorLayers.Add(new ColorLayer(40, "SkyToCloud09", Color.FromArgb(255, 55, 155, 255)));
        d.ColorLayers.Add(new ColorLayer(50, "SkyToCloud10", Color.FromArgb(255, 185, 220, 255)));
        d.ColorLayers.Add(new ColorLayer(60, "SkyToCloud11", Color.FromArgb(255, 200, 240, 250)));
        d.ColorLayers.Add(new ColorLayer(100, "SkyToCloud12", Color.FromArgb(255, 255, 255, 255)));
        return d;
    }

    private static Document GetHellPreset()
    {
        var d = new Document();

        return d;
    }
}