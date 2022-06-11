using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocksFactory
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"Name: {CustomerName} Address: {Address} Due Date: {DueDate.ToString("dd MMMM yyyy")}";
        }
    }

    public class Order
    {
        public string OrderNumber { get; set; }

        public override string ToString()
        {
            return $"Oreder #: {OrderNumber}";
        }
    }
}
