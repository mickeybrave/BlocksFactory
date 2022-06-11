using BlocksFactory;
using System.Collections.Generic;
using Xunit;

namespace BlockFactory.Tests
{
    public class UnitTestInvoice
    {

        [Fact]
        public void UnitTestInvoice_Verify_Table_Test()
        {
            List<Block> blocks = new List<Block>
            {
                new Block(new Color(ColorName.Red, 1),new Shape(ShapeName.Square,  1)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Square,  1)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Triangle,  2)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Triangle,  2)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Circle,  3)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Circle,  3)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Circle,  3))
            };

            var table = @" |          | Red | Blue | Yellow | 
 |--------------------------------| 
 | Square   | 1   | -    | 1      | 
 | Triangle | -   | 2    | -      | 
 | Circle   | -   | 1    | 2      | 
";
            var res = TableParser.GetTable(blocks, new[] { " ", ColorName.Red.ToString(), ColorName.Blue.ToString(), ColorName.Yellow.ToString() });
            Assert.NotNull(res);
            Assert.Equal(table, res);
        }


        [Fact]
        public void UnitTestInvoice_Verify_Table_noHeader_Test()
        {
            List<Block> blocks = new List<Block>
            {
                new Block(new Color(ColorName.Red, 1),new Shape(ShapeName.Square,  1)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Square,  1)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Triangle,  2)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Triangle,  2)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Circle,  3)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Circle,  3)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Circle,  3))
            };

            var table = @"  Square    1  -  1  
  Triangle  -  2  -  
  Circle    -  1  2  
";
            var res = TableParser.GetTable(blocks, null);
            Assert.NotNull(res);
            Assert.Equal(table, res);
        }


        [Fact]
        public void UnitTestInvoice_Test()
        {
            var generator = new Generator();

            var customer = new Customer { CustomerName = "Mark Pearl", Address = "1 Bob Avenue, Auckland", DueDate = new System.DateTime(2019, 1, 19) };
            var order = new Order { OrderNumber = "0001" };
            List<Block> blocks = new List<Block>
            {
                new Block(new Color(ColorName.Red, 1),new Shape(ShapeName.Square,  1)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Square,  1)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Triangle,  2)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Triangle,  2)),
                new Block(new Color(ColorName.Blue, 0),new Shape(ShapeName.Circle,  3)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Circle,  3)),
                new Block(new Color(ColorName.Yellow, 0),new Shape(ShapeName.Circle,  3))
            };

            var res = generator.GenerateInvoce(order, customer, blocks);
        }
    }
}