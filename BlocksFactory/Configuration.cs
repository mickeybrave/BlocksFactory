namespace BlocksFactory
{
    public static class Configuration
    {
        public static List<ColorName> GetShapeColors()
        {
            return Enum.GetValues(typeof(ColorName)).Cast<ColorName>().ToList();
        }

        public static List<ShapeName> GetShapes()
        {
            return Enum.GetValues(typeof(ShapeName)).Cast<ShapeName>().ToList();
        }

        public static readonly Dictionary<ShapeName, int> ShapesPrice = new Dictionary<ShapeName, int>
        {
            {ShapeName.Square , 1 },
            {ShapeName.Triangle, 2 },
            {ShapeName.Circle, 3 },
        };

        public static readonly Dictionary<ColorName, int> ColorPrice = new Dictionary<ColorName, int>
        {
            {ColorName.Red , 1 },
            {ColorName.Yellow, 0 },
            {ColorName.Blue, 0 },
        };
    }
}
