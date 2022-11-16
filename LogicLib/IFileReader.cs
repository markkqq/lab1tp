using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrolstation
{
    public interface IFileReader
    {
        public List<Fuel> ReadFuels();
        public int ReadAmountofFacilities();
        public int[] ReadAmountofClients();
    }
}
