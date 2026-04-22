#nullable enable
using System.Drawing;

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

    }

    public static void ExportCs(Document document, string fileName)
    {

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
}