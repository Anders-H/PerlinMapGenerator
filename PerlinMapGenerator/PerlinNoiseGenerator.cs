#nullable enable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PerlinMapGenerator;

public class PerlinNoiseGenerator
{
    private Document? _d;
    private List<ColorLayer>? _colors;

    public void Render(FastBitmap b, Document d)
    {
        _d = d;
        _colors = _d.ColorLayers.OrderBy(x => x.HighestValueFloat).ToList();
        
        if ((_colors?.Count ?? 0) < 2)
            return;

        var persistence = d.Persistence / 100f; // hur snabbt amplituden minskar
        var lacunarity = d.Lacunarity / 10f; // hur snabbt frekvensen ökar
        var perlin = new Perlin(d.Seed);

        for (var y = 0; y < d.Height; y++)
        {
            for (var x = 0; x < d.Width; x++)
            {
                var nx = x / d.Scale;
                var ny = y / d.Scale;

                var noiseValue = Fbm(perlin, nx, ny, d.Octaves, persistence, lacunarity);

                // Radial mask för kontinenter
                var dx = (x - d.Width / 2f) / (d.Width / 2f);
                var dy = (y - d.Height / 2f) / (d.Height / 2f);
                var dist = (float)Math.Sqrt(dx * dx + dy * dy);
                var mask = Clamp(1f - dist, 0f, 1f);

                var heightValue = noiseValue * mask;

                b.SetPixel(x, y, HeightToColor(heightValue));
            }
        }
    }

    private static float Clamp(float value, float min, float max)
    {
        if (value < min)
            return min;

        if (value > max)
            return max;

        return value;
    }

    static float Fbm(Perlin perlin, float x, float y, int octaves, float persistence, float lacunarity)
    {
        var total = 0f;
        var amplitude = 1f;
        var frequency = 1f;
        var maxValue = 0f;

        for (var i = 0; i < octaves; i++)
        {
            var n = perlin.Noise(x * frequency, y * frequency);
            n = (n + 1f) * 0.5f; // mappa från [-1,1] till [0,1]

            total += n * amplitude;
            maxValue += amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        return total / maxValue; // normalisera till [0,1]
    }

    private Color HeightToColor(float h)
    {
        if (_d == null || _colors == null)
            return Color.Green;

        foreach (var color in _colors)
        {
            if (h <= color.HighestValueFloat)
                return color.Color;
        }

        return _colors.Last().Color;
    }
}