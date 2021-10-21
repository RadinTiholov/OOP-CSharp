using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        public EggRepository()
        {
            Models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models { get; private set; }

        public void Add(IEgg model)
        {
            List<IEgg> coppiedCollection = (List<IEgg>)Models;
            coppiedCollection.Add(model);
            Models = coppiedCollection;
        }

        public IEgg FindByName(string name)
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

        public bool Remove(IEgg model)
        {
            List<IEgg> coppiedCollection = (List<IEgg>)Models;
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
