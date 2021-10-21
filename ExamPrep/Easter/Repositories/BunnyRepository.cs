using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System.Collections.Generic;

namespace Easter.Repositories
{
    class BunnyRepository : IRepository<IBunny>
    {
        public BunnyRepository()
        {
            Models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models { get; private set; }

        public void Add(IBunny model)
        {
            List<IBunny> coppiedCollection = (List<IBunny>)Models;
            coppiedCollection.Add(model);
            Models = coppiedCollection;
        }

        public IBunny FindByName(string name)
        {
            foreach (var model in Models)
            {
                if (model.Name == name)
                {
                    return model;
                }
            }
            return null;
        }

        public bool Remove(IBunny model)
        {
            List<IBunny> coppiedCollection = (List<IBunny>)Models;
            if (coppiedCollection.Contains(model))
            {
                coppiedCollection.Remove(model);
                Models = coppiedCollection;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
