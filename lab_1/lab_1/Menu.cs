using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_1
{
    class Menu
    {
        public static void LoadTariffs(string path)
        {
            bool result = true;
            StreamReader sr = new StreamReader(path);
            var file = File.ReadAllText(path);
            while (file != null & result != false)
            {
                try
                {
                    string name = sr.ReadLine();
                    int reservedvolume = int.Parse(sr.ReadLine());
                    double price = double.Parse(sr.ReadLine());
                    if (reservedvolume < 0 || price < 0)
                    {
                        Console.WriteLine("Ошибка");
                        break;
                    }
                    else
                    {
                        Fuel fuel = new Fuel(name, price);
                        Station.AddFuel(fuel);
                    }
                }
                catch
                {
                    result = false;
                    break;
                }
                file = File.ReadAllText(path);
            }
        }
        public static void ShowTariffs()
        {

            if (Station.GetFuels.Count > 0)
            {
                Console.WriteLine("цены на топливо");
                foreach (KeyValuePair<Fuel,double> fuels in Station.GetFuels)
                {
                    Console.WriteLine("Тип топлива : {0}, Цена : {1}, Осталось литров : {2}", fuels.Key.Name, fuels.Key.Price, fuels.Value);
                }
            }

        }
    }
}
