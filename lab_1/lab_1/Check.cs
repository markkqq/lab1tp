using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Check
    {

        public void ShowCheck(string path)
        {
            string s = File.ReadAllText(path);
            Console.WriteLine(s);
        }
        public void PrintCheck(GasolinePayment payment)
        {
            string s = string.Format("В {0} Водитель приобрел следующее топливо: {1}, Купил {2} Литров данного типа топлива. К оплате {3}", DateTime.Now, payment.Name, _volume.ToString(), (_volume * _fuel.Price).ToString());
            
            //string path = Directory.GetCurrentDirectory();
            //File.AppendAllText(path, s);
        }

    }
}
