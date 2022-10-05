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
        private int _volume;
        public GasolinePayment(Fuel fuel, int volume)
        {
            this._fuel = fuel;
            this._volume = volume;
        }
        public void Pay()
        {
            Console.WriteLine("К оплате " + _volume * _fuel.Price);

            PrintCheck();
            
        }
        private void PrintCheck()
        {
            string s = string.Format("В {0} Водитель приобрел следующее топливо: {1}, Купил {2} Литров данного типа топлива. К оплате {3}", DateTime.Now, _fuel.Name,_volume.ToString(), (_volume * _fuel.Price).ToString());
            Console.WriteLine(s);
            string path = "C:\\Users\\Андрей\\Desktop\\out.txt";
            File.AppendAllText(path, s);
        }
    }
}
