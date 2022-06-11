using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksFactory
{
    public static class ShapeProcessor
    {
        public static string GenerateStringShapeCounterFormatted(IEnumerable<Block> shapes, ColorName colorName, ShapeName shapeName)
        {
            var count = shapes.Count(c => c.BlockColor == colorName && c.ShapeName == shapeName);
            return count == 0 ? "-" : count.ToString();
        }
    }
}
