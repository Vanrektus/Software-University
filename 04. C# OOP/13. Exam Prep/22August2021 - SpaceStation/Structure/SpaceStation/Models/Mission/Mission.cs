using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        // ??? Potential bug ???
        // TODO: Finish it
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (IAstronaut currentAstronaut in astronauts)
            {
                while (currentAstronaut.CanBreath && planet.Items.Count > 0)
                {
                    string item = planet.Items.FirstOrDefault();

                    if (item != null)
                    {
                        currentAstronaut.Bag.Items.Add(item);
                        planet.Items.Remove(item);
                        currentAstronaut.Breath();
                    }
                }
            }
        }
    }
}
