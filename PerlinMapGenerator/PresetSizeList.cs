using System.Collections.Generic;

namespace PerlinMapGenerator;

public class PresetSizeList : List<PresetSize>
{
    public PresetSizeList()
    {
        Add(new PresetSize(32, 32));
        Add(new PresetSize(100, 100));
        Add(new PresetSize(320, 320));
        Add(new PresetSize(400, 400));
        Add(new PresetSize(512, 512));
    }
}