using System.Collections.Generic;
namespace petrolstation
{
    public class Facility
    {
        private Dictionary<Fuel, int> availableFuels = new Dictionary<Fuel, int>();
        public Dictionary<Fuel, int> AvailableFuels { get; }
        public Facility(List<Fuel> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                availableFuels.Add(list[i], 100);
            }
            AvailableFuels = availableFuels;
        }
        public bool ContainsFuel(Fuel fuel)
        {
            return (availableFuels.ContainsKey(fuel));
        }
    }
}