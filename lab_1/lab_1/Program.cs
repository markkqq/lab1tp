using System;
using System.Collections.Generic;
namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, double> station = new Dictionary<string, double>();

            station.Add("92", 44);
            station.Add("95", 46);
            station.Add("98", 50);
            station.Add("100", 58);
            station.Add("дт", 55);
            bool processing = true;

            ShowInfo();
            while (processing)
            {
                Console.WriteLine("Введите название топлива");
                string data = Console.ReadLine();
                data = data.ToLower();
                if (station.ContainsKey(data))
                {
                    Pay(data);
                }
                if (!station.ContainsKey(data))
                {
                    Console.Clear();
                    ShowInfo();
                }
                if (data == "выход")
                {
                    processing = !processing;
                }
            }
            void Pay(string fuel)
            {
                int volume;
                Console.WriteLine("количество");
                int.TryParse(Console.ReadLine(),out volume);
                if (volume > 0)
                {
                    Console.WriteLine("К оплате "+volume * station[fuel]);
                }
                else
                {
                    Console.WriteLine("неправильный формат данных");
                    Console.Clear();
                    ShowInfo();
                }
            }
            void ShowInfo()
            {
                Console.WriteLine("цены на топливо");
                foreach (KeyValuePair<string, double> fuel in station)
                {
                    Console.WriteLine(fuel.Key + " : " + fuel.Value);
                }
            }
        }
    }
}