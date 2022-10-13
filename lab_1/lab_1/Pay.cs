using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab_1
{
    class GasolinePayment
    {
        private Fuel _fuel;
        private double _price;
        private int _volume;
        private string _name;
        public GasolinePayment(Fuel fuel, int volume)
        {
            this._price = fuel.Price;
            this._volume = volume;
            
        }
        
    }
}
