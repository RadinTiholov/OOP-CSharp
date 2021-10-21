using Easter.Models.Bunnies.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System.Linq;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public void Color(IEgg egg, IBunny bunny)
        {
            int i = 0;
            while (!egg.IsDone() || bunny.Energy > 0 && bunny.Dyes.Any())
            {
                if (bunny.Energy > 0 && !egg.IsDone())
                {
                    if (bunny.Dyes.Any())
                    {
                        egg.GetColored();
                    }
                }
                if (bunny.Dyes.ToList()[i].IsFinished())
                {
                    if (bunny.Dyes.Any())
                    {
                        i++;
                    }
                }
            }
        }
    }
}
