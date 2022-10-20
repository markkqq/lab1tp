using System.Collections.Generic;
namespace petrolstation
{
    internal class Facility
    {
        public Dictionary<Fuel, int> AvailableFuels { get; }
        public Facility(List<Fuel> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                AvailableFuels.Add(list[i], 100);
            }
        }
    }
}