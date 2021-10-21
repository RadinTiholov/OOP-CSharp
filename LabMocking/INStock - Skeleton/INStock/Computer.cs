using System;
using System.Collections.Generic;
using System.Text;
using INStock.Contracts;
using System.Diagnostics.CodeAnalysis;

namespace INStock
{
    public class Computer : IProduct
    {
        public Computer(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }
        public string Label { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }

        public int CompareTo([AllowNull] IProduct other)
        {
            throw new NotImplementedException();
        }
    }
}
