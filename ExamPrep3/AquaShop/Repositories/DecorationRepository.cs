using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        public DecorationRepository()
        {
            Models = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models { get; private set; }

        public void Add(IDecoration model)
        {
            Models.ToList().Add(model);
            Models = (IReadOnlyCollection<IDecoration>)Models;
        }

        public IDecoration FindByType(string type)
        {
            return Models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IDecoration model)
        {
            List<IDecoration> secondCollection = Models.ToList();
            if (secondCollection.Contains(model))
            {
                secondCollection.Remove(model);
                Models = secondCollection;
                return true;
            }
            return false;
        }
    }
}
