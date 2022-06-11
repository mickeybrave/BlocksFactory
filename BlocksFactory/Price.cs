using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksFactory
{
    public enum Shape
    {
        Square,
        Triangle,
        Circle
    }

    public enum Color
    {
        Red,
        Blue,
        Yellow
    }

    public class Price
    {
    }

    public abstract class BlockBase
    {
        public abstract int GetPrice();
        public abstract Color BlockColor { get; }
    }

    public interface IPrice
    {
        int GetPrice();
    }
    public abstract class ColorBase : IPrice
    {
        private readonly Color _color;
        public ColorBase(Color color)
        {
            this._color = color;
        }
        public abstract int GetPrice();
        public Color BlockColor { get { return _color; } }
    }
    public class Red : ColorBase
    {
        private readonly int _price;
        public Red(Color color, int price) : base(color)
        {
            this._price = price;
        }
        public override int GetPrice()
        {
            return _price;
        }
    }

    public class Block : BlockBase
    {
        private readonly ColorBase _colorBase;
        private readonly int _shapePrice;

        public Block(ColorBase colorBase, int shapePrice)
        {
            this._colorBase = colorBase;
            this._shapePrice = shapePrice;
        }
        public override Color BlockColor { get { return _colorBase.BlockColor; } }

        public override int GetPrice()
        {
            return _colorBase.GetPrice() + _shapePrice;
        }
    }
}
