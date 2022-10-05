using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class GasolinePouring
    {
        private int _volume;
        private Customer _customer;
        public GasolinePouring(int volume)
        {
            this._volume = volume;

        }
        public Fuel Pour(Fuel fuel)
        {
            GasolinePouring pouring = new GasolinePouring(_volume);
            fuel.ReservedVolume -= _volume;
            return fuel;
        }

    }
}
