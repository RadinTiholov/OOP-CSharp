namespace INStock.Contracts
{
    using System.Collections.Generic;

    public interface IProductStock : IEnumerable<IProductStock>
    {
        int Count { get; }

        IProductStock this[int index] { get; set; }

        bool Contains(IProduct product);

        void Add(IProduct product);

        bool Remove(IProductStock product);

        IProductStock Find(int index);

        IProductStock FindByLabel(string label);

        IProductStock FindMostExpensiveProduct();

        IEnumerable<IProductStock> FindAllInRange(double lo, double hi);

        IEnumerable<IProductStock> FindAllByPrice(double price);

        IEnumerable<IProductStock> FindAllByQuantity(int quantity);
    }
}
