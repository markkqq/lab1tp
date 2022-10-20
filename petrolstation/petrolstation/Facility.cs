using System.Collections.Generic;
namespace petrolstation
{
    internal class Facility
    {
        public Dictionary<Fuel, int> Fuels { get; }
        public Facility(List<Fuel> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                Fuels.Add(list[i], 100);
            }
        }
    }
}