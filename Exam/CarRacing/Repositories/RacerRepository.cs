using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        public RacerRepository()
        {
            models = new List<IRacer>();
        }

        private List<IRacer> models;
        public IReadOnlyCollection<IRacer> Models => models.AsReadOnly();

        public void Add(IRacer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(model);
            //List<IRacer> secondList = Models.ToList();
            //secondList.Add(model);
            //Models = secondList;
        }

        public IRacer FindBy(string property)
        {
            return models.FirstOrDefault(x => x.Username == property);
        }

        public bool Remove(IRacer model)
        {
            return models.Remove(model);
            //Models = Models.ToList();
            //List<IRacer> secondList = Models.ToList();
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
