using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        public CarRepository()
        {
            models = new List<ICar>();
        }

        private List<ICar> models;
        public IReadOnlyCollection<ICar> Models => models.AsReadOnly();

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);
            //}
            //List<ICar> secondList = Models.ToList();
            //secondList.Add(model);
            //Models = secondList;
        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
            //Models = Models.ToList();
            //List<ICar> secondList = Models.ToList();
            //bool isRemoved = secondList.Remove(model);
            //if (isRemoved)
            //{
            //    Models = secondList;
            //    return isRemoved;
            //}
            //return isRemoved;
            
        }
    }
}
