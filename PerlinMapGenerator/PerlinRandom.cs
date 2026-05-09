using System;

namespace PerlinMapGenerator;

public static class PerlinRandom
{
    public static readonly Random Random;

    static PerlinRandom() =>
        Random = new Random();

    public static int GetInt(int min, int max) =>
        Random.Next(min, max);

    public static int GetRgb() =>
        Random.Next(256);
}