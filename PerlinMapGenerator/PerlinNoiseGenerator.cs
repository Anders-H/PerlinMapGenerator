#nullable enable
using System;
using System.Drawing;

namespace PerlinMapGenerator;

public class PerlinNoiseGenerator
{
    public void Render(FastBitmap b, Document d)
    {
        int seed = 12345;
        float persistence = d.Persistence / 100f; // hur snabbt amplituden minskar
        float lacunarity = d.Lacunarity / 10f; // hur snabbt frekvensen ökar

        Perlin perlin = new Perlin(d.Seed);

        for (int y = 0; y < d.Height; y++)
        {
            for (int x = 0; x < d.Width; x++)
            {
                float nx = x / d.Scale;
                float ny = y / d.Scale;

                float noiseValue = FBM(perlin, nx, ny, d.Octaves, persistence, lacunarity);

                // Radial mask för kontinenter
                float dx = (x - d.Width / 2f) / (d.Width / 2f);
                float dy = (y - d.Height / 2f) / (d.Height / 2f);
                float dist = (float)Math.Sqrt(dx * dx + dy * dy);
                float mask = Clamp(1f - dist, 0f, 1f);

                float heightValue = noiseValue * mask;

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

    static float FBM(Perlin perlin, float x, float y, int octaves, float persistence, float lacunarity)
    {
        float total = 0f;
        float amplitude = 1f;
        float frequency = 1f;
        float maxValue = 0f;

        for (int i = 0; i < octaves; i++)
        {
            float n = perlin.Noise(x * frequency, y * frequency);
            n = (n + 1f) * 0.5f; // mappa från [-1,1] till [0,1]

            total += n * amplitude;
            maxValue += amplitude;

            amplitude *= persistence;
            frequency *= lacunarity;
        }

        return total / maxValue; // normalisera till [0,1]
    }

    static Color HeightToColor(float h)
    {
        if (h < 0.25f)
            return Color.FromArgb(0, 0, 80);        // djupvatten
        
        if (h < 0.35f)
            return Color.FromArgb(0, 80, 160);      // kust
        
        if (h < 0.6f)
            return Color.FromArgb(34, 139, 34);     // gräs
        
        if (h < 0.8f)
            return Color.FromArgb(139, 126, 102);   // kullar

        return Color.FromArgb(245, 245, 245);                  // berg
    }
}

/// <summary>
/// Enkel 2D-Perlin-implementation
/// </summary>
public class Perlin
{
    private readonly int[] perm;

    public Perlin(int seed)
    {
        perm = new int[512];
        int[] p = new int[256];
        for (int i = 0; i < 256; i++) p[i] = i;

        Random rand = new Random(seed);
        for (int i = 255; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (p[i], p[j]) = (p[j], p[i]);
        }

        for (int i = 0; i < 512; i++)
            perm[i] = p[i & 255];
    }

    public float Noise(float x, float y)
    {
        int xi = (int)Math.Floor(x) & 255;
        int yi = (int)Math.Floor(y) & 255;

        float xf = x - (float)Math.Floor(x);
        float yf = y - (float)Math.Floor(y);

        float u = Fade(xf);
        float v = Fade(yf);

        int aa = perm[perm[xi] + yi];
        int ab = perm[perm[xi] + yi + 1];
        int ba = perm[perm[xi + 1] + yi];
        int bb = perm[perm[xi + 1] + yi + 1];

        float x1 = Lerp(Grad(aa, xf, yf), Grad(ba, xf - 1, yf), u);
        float x2 = Lerp(Grad(ab, xf, yf - 1), Grad(bb, xf - 1, yf - 1), u);

        return Lerp(x1, x2, v);
    }

    private static float Fade(float t) => t * t * t * (t * (t * 6 - 15) + 10);
    private static float Lerp(float a, float b, float t) => a + t * (b - a);
    private static float Grad(int hash, float x, float y)
    {
        int h = hash & 7;
        float u = h < 4 ? x : y;
        float v = h < 4 ? y : x;
        return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
    }
}