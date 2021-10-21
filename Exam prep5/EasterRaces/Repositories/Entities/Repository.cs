using EasterRaces.Repositories.Contracts;
using System.Collections.Generic;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {
        public Repository()
        {
            models = new List<T>();
        }
        private List<T> models; 
        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return (IReadOnlyCollection<T>)models;
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
