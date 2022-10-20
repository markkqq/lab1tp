using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrolstation
{
    class FacilityGenerator
    {
        List<Fuel> Fuels { get; }
        public FacilityGenerator(List<Fuel> availablefuels)
        {
            Fuels = availablefuels;
        }
        
        public List<Fuel> GenerateFacility()
        {
            List<Fuel> startfuels = Fuels;
            List<Fuel> endfuels = new List<Fuel>();

            Random r = new Random();
            int amount = r.Next(1, 3);
            for(int i = 0; i < amount; i++)
            {
                int index = r.Next(0, startfuels.Count - 1);
                Fuel fuel = startfuels[index];
                endfuels.Add(fuel);
                startfuels.RemoveAt(index);
            }
            return endfuels;
        }
    }
}
