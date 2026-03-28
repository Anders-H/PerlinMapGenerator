#nullable enable
using System;

namespace PerlinMapGenerator;

/// <summary>
/// Enkel 2D-Perlin-implementation
/// </summary>
public class Perlin
{
    private readonly int[] _perm;

    public Perlin(int seed)
    {
        _perm = new int[512];
        var p = new int[256];
        for (var i = 0; i < 256; i++) p[i] = i;

        var rand = new Random(seed);
        for (var i = 255; i > 0; i--)
        {
            var j = rand.Next(i + 1);
            (p[i], p[j]) = (p[j], p[i]);
        }

        for (var i = 0; i < 512; i++)
            _perm[i] = p[i & 255];
    }

    public float Noise(float x, float y)
    {
        var xi = (int)Math.Floor(x) & 255;
        var yi = (int)Math.Floor(y) & 255;

        var xf = x - (float)Math.Floor(x);
        var yf = y - (float)Math.Floor(y);

        var u = Fade(xf);
        var v = Fade(yf);

        var aa = _perm[_perm[xi] + yi];
        var ab = _perm[_perm[xi] + yi + 1];
        var ba = _perm[_perm[xi + 1] + yi];
        var bb = _perm[_perm[xi + 1] + yi + 1];

        var x1 = Lerp(Grad(aa, xf, yf), Grad(ba, xf - 1, yf), u);
        var x2 = Lerp(Grad(ab, xf, yf - 1), Grad(bb, xf - 1, yf - 1), u);

        return Lerp(x1, x2, v);
    }

    private static float Fade(float t) =>
        t * t * t * (t * (t * 6 - 15) + 10);

    private static float Lerp(float a, float b, float t) =>
        a + t * (b - a);

    private static float Grad(int hash, float x, float y)
    {
        var h = hash & 7;
        var u = h < 4 ? x : y;
        var v = h < 4 ? y : x;
        return ((h & 1) == 0 ? u : -u) + ((h & 2) == 0 ? v : -v);
    }
}