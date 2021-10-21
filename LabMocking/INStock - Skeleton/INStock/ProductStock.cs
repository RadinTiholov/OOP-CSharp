using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        public ProductStock()
        {
            products = new List<IProduct>();
        }
        private readonly List<IProduct> products;
        public IProductStock this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => products.Count;

        public void Add(IProduct product)
        {
            if (products.Contains(product))
            {
                throw new InvalidOperationException("The product already exists.");
            }
            products.Add(product);
        }

        public bool Contains(IProduct product)
        {
            if (products.Any(x => x.Label == product.Label))
            {
                return true;
            }
            return false;
        }

        public IProductStock Find(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProductStock> FindAllByPrice(double price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProductStock> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProductStock> FindAllInRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IProductStock FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProductStock FindMostExpensiveProduct()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProductStock> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProductStock product)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
