using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class CheckSaving
    {
        public void SaveCheck(GasolinePayment payment)
        {

            string s = string.Format("В {0} Водитель приобрел следующее топливо: {1}, Купил {2} Литров данного типа топлива. К оплате {3}", DateTime.Now, string.Empty, string.Empty, string.Empty);
            string path = Directory.GetCurrentDirectory();
            File.AppendAllText(path, s);

        }
    }
}
