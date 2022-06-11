using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksFactory
{
    public enum ShapeName
    {
        Square,
        Triangle,
        Circle
    }

    public enum ColorName
    {
        Red,
        Blue,
        Yellow
    }

    public interface IPrice
    {
        int GetPrice();
    }
    public class Color : IPrice
    {
        private readonly ColorName _shapeColor;
        private readonly int _price;
        public Color(ColorName shapeColor, int price)
        {
            this._shapeColor = shapeColor;
            this._price = price;
        }
        public int GetPrice()
        {
            return _price;
        }
        public ColorName ShapeColor { get { return _shapeColor; } }
    }
    public class Shape : IPrice
    {
        private readonly ShapeName _shapeName;
        private readonly int _price;
        public Shape(ShapeName shapeName, int price)
        {
            this._shapeName = shapeName;
            this._price = price;
        }
        public int GetPrice()
        {
            return _price;
        }
        public ShapeName ShapeName { get { return _shapeName; } }
    }

    public class Block : IPrice
    {
        private readonly Color _color;
        private readonly Shape _shape;

        public Block(Color color, Shape shape)
        {
            this._color = color;
            this._shape = shape;
        }
        public ColorName BlockColor { get { return _color.ShapeColor; } }
        public ShapeName ShapeName { get { return _shape.ShapeName; } }

        public int GetPrice()
        {
            return _color.GetPrice() + _shape.GetPrice();
        }
    }
}
