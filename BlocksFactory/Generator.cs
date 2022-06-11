using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksFactory
{
    public class Generator
    {



        public (Customer, List<Block>) SetValues()
        {
            Console.Write("Please input your Name:");
            string name = Console.ReadLine();

            Console.Write("Please input your Address:");
            string address = Console.ReadLine();

            Console.Write("Please input your Due Date:");
            DateTime dueDate = Convert.ToDateTime(Console.ReadLine());

            var customer = new Customer { CustomerName = name, Address = address, DueDate = dueDate };

            List<Block> allBlocks = new List<Block>();

            foreach (var shape in Configuration.GetShapes())
            {
                foreach (var color in Configuration.GetShapeColors())
                {
                    Console.Write($"Please input the number of {color} {shape}s:");
                    var stringNumRedSqueres = Console.ReadLine();
                    var numRedSqueres = Convert.ToInt32(String.IsNullOrEmpty(stringNumRedSqueres) ? 0 : stringNumRedSqueres);
                    for (int i = 0; i < numRedSqueres; i++)
                    {
                        allBlocks.Add(new Block(new Color(color, Configuration.ColorPrice[color]), new Shape(shape, Configuration.ShapesPrice[shape])));
                    }
                }
            }


            return (customer, allBlocks);
        }

        public string GenerateInvoce(Order order, Customer customer, IEnumerable<Block> shapes)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Your invoice report has been generated:/n");
            stringBuilder.AppendLine(customer.ToString() + order.ToString());

            var tableShapes = TableParser.GetTable(shapes);

            var tableNoHeaders = TableParserNoHeader.GetTable(shapes);

            return "";
        }
    }
}
