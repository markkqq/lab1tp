using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrolstation
{
    class Station
    {
        List<Facility> facilities = new List<Facility>();
        public Queue<Client> Clients { get; }
        Cashbox cashbox = new Cashbox();
        public void Run()
        {

        }
        public void AddFacilities(List<Facility>facilities)
        {
            for(int i = 0; i < facilities.Count; i++)
            {
                facilities.Add(facilities[i]);
            }
        }
    }
}
