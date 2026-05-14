using PerlinMapGenerator.Dialogs.ColorDialogs;
using System.Collections.Generic;
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
        Add(new Preset("Gradient", GetGradientPreset()));
        Add(new Preset("Polkagris", GetPolkagrisPreset()));
    }

    private static int RandomSeed =>
        PerlinRandom.GetInt(1, 1000001);

    private static Document GetBlankPreset()
    {
        var d = new Document();
        d.ColorLayers.Clear();
        d.ColorLayers.Add(new ColorLayer(30, "Black", Color.Black, 0));
        d.ColorLayers.Add(new ColorLayer(100, "White", Color.White, 1));
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
        d.ColorLayers.Add(new ColorLayer(10, "Sea", Color.FromArgb(255, 0, 60, 215), 0));
        d.ColorLayers.Add(new ColorLayer(17, "Beach", Color.FromArgb(255, 252, 228, 67), 1));
        d.ColorLayers.Add(new ColorLayer(30, "Woods", Color.FromArgb(255, 0, 128, 0), 2));
        d.ColorLayers.Add(new ColorLayer(35, "Mountain", Color.FromArgb(255, 128, 128, 128), 3));
        d.ColorLayers.Add(new ColorLayer(45, "High mountain", Color.FromArgb(255, 192, 192, 192), 4));
        d.ColorLayers.Add(new ColorLayer(100, "Glacier", Color.FromArgb(255, 247, 247, 247), 5));
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
        d.ColorLayers.Add(new ColorLayer(2, "SkyToCloud01", Color.FromArgb(255, 0, 128, 255), 0));
        d.ColorLayers.Add(new ColorLayer(4, "SkyToCloud02", Color.FromArgb(255, 66, 160, 255), 1));
        d.ColorLayers.Add(new ColorLayer(6, "SkyToCloud03", Color.FromArgb(255, 151, 203, 255), 2));
        d.ColorLayers.Add(new ColorLayer(8, "SkyToCloud04", Color.FromArgb(255, 198, 226, 255), 3));
        d.ColorLayers.Add(new ColorLayer(10, "SkyToCloud05", Color.FromArgb(255, 255, 255, 255), 4));
        d.ColorLayers.Add(new ColorLayer(12, "SkyToCloud06", Color.FromArgb(255, 183, 219, 255), 5));
        d.ColorLayers.Add(new ColorLayer(14, "SkyToCloud07", Color.FromArgb(255, 94, 174, 255), 6));
        d.ColorLayers.Add(new ColorLayer(20, "SkyToCloud08", Color.FromArgb(255, 75, 164, 255), 7));
        d.ColorLayers.Add(new ColorLayer(40, "SkyToCloud09", Color.FromArgb(255, 55, 155, 255), 8));
        d.ColorLayers.Add(new ColorLayer(50, "SkyToCloud10", Color.FromArgb(255, 185, 220, 255), 9));
        d.ColorLayers.Add(new ColorLayer(60, "SkyToCloud11", Color.FromArgb(255, 200, 240, 250), 10));
        d.ColorLayers.Add(new ColorLayer(100, "SkyToCloud12", Color.FromArgb(255, 255, 255, 255), 11));
        return d;
    }

    private static Document GetHellPreset()
    {
        var d = new Document
        {
            Octaves = 7,
            Seed = 389222,
            Scale = 54.0f,
            Persistence = 45.0f,
            Lacunarity = 21.0f
        };

        d.ColorLayers.Clear();
        d.ColorLayers.Add(new ColorLayer(10, "Pumice01", Color.FromArgb(255, 10, 10, 10), 0));
        d.ColorLayers.Add(new ColorLayer(20, "Pumice02", Color.FromArgb(255, 20, 20, 20), 1));
        d.ColorLayers.Add(new ColorLayer(30, "Pumice03", Color.FromArgb(255, 30, 30, 30), 2));
        d.ColorLayers.Add(new ColorLayer(35, "Pumice04", Color.FromArgb(255, 40, 40, 40), 3));
        d.ColorLayers.Add(new ColorLayer(40, "Pumice05", Color.FromArgb(255, 50, 50, 50), 4));
        d.ColorLayers.Add(new ColorLayer(46, "Lava01", Color.FromArgb(255, 255, 0, 0), 5));
        d.ColorLayers.Add(new ColorLayer(50, "Lava02" , Color.FromArgb(255, 255, 190, 10), 6));
        d.ColorLayers.Add(new ColorLayer(64, "Lava 01 Again", Color.FromArgb(255, 255, 0, 0), 7));
        d.ColorLayers.Add(new ColorLayer(68, "Pumice05 Again", Color.FromArgb(255, 50, 50, 50), 8));
        d.ColorLayers.Add(new ColorLayer(100, "Pumice04 Again", Color.FromArgb(255, 40, 40, 40), 9));
        return d;
    }

    private static Document GetGradientPreset()
    {
        var d = new Document
        {
            Octaves = 9,
            Seed = 141717,
            Scale = 35.0f,
            Persistence = 47.0f,
            Lacunarity = 19.0f
        };

        d.ColorLayers.Clear();
        var grayValue = 4;

        for (var i = 2; i <= 100; i += 2)
        {
            var index = d.ColorLayers.Count;
            d.ColorLayers.Add(new ColorLayer(i, $"Gray {i}", Color.FromArgb(255, grayValue, grayValue, grayValue), index));
            grayValue += 4;
        }

        return d;
    }

    private static Document GetPolkagrisPreset()
    {
        var d = new Document
        {
            Octaves = 6,
            Seed = 560879,
            Scale = 61.0f,
            Persistence = 35.0f,
            Lacunarity = 14.0f
        };

        d.ColorLayers.Clear();
        var isRed = false;

        for (var i = 4; i <= 100; i += 4)
        {
            var index = d.ColorLayers.Count;
            d.ColorLayers.Add(new ColorLayer(i, isRed ? "Red" : "White", isRed ? Color.FromArgb(255, 255, 0, 0) : Color.FromArgb(255, 255, 255, 255), index));
            isRed = !isRed;
        }

        return d;
    }
}