#nullable enable
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PerlinMapGenerator;

public class ColorLayerList : List<ColorLayer>
{
    public Color GetColorForIntValue(int value)
    {
        for (var i = 0; i < Count; i++)
        {
            var colorLayer = this[i];

            if (value <= colorLayer.HighestValue)
                return colorLayer.Color;
        }

        if (value <= 50)
            return Count > 0 ? this[0].Color : Color.Magenta;

        return Count > 0 ? this.Last().Color : Color.Aqua;

    }
}