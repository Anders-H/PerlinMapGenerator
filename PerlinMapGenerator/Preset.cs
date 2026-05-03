namespace PerlinMapGenerator;

public class Preset
{
    public string Name { get; set; }
    public Document Document { get; set; }

    public Preset() : this("", new Document())
    {
    }

    public Preset(string name, Document document)
    {
        Name = name;
        Document = document;
    }

    public override string ToString() =>
        Name;
}