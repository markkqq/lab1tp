using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrolstation
{
    public interface IUI
    {
        public void ShowFacilities(List<Facility> facilities);
        public void ShowClient(Client client);
        public char CollectPourType();
        public string CollectFuelName();
        public int CollectVolume();
        public void Success();
        public void Error();
    }
}
