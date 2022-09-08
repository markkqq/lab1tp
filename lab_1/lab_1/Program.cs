using System;
using System.Collections.Generic;
using System.IO;
namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Fuel> station = new List<Fuel>();
            Fuel fuel1 = new Fuel("92", 100, 44);
            Fuel fuel2 = new Fuel("95", 100, 48);
            Fuel fuel3 = new Fuel("98", 100, 56);
            Fuel fuel4 = new Fuel("100", 100, 58);
            Fuel fuel5 = new Fuel("дт", 100, 55);
            station.Add(fuel1);
            station.Add(fuel2);
            station.Add(fuel3);
            station.Add(fuel4);
            station.Add(fuel5);
            bool processing = true;
            
            ShowInfo();
            while (processing)
            {
                Console.WriteLine("Введите название топлива");
                string data = Console.ReadLine();
                foreach(Fuel fuel in station)
                {
                    if (fuel.Name == data)
                    {
                        if (fuel.ReservedVolume > 0)
                        {
                            Pay(fuel);
                        }
                        else
                        {
                            Console.WriteLine("В азс не осталось данного типа топлива");
                        }
                    }
                }
                
                
            }
            void Pay(Fuel fuel)
            {
                int volume;
                Console.WriteLine("количество");
                int.TryParse(Console.ReadLine(),out volume);
                if (volume > 0 & fuel.ReservedVolume-volume>=0)
                {
                    Console.WriteLine("К оплате "+volume * fuel.Price);
                    fuel.ReservedVolume -= volume;
                    Console.WriteLine("В АЗС осталось"+fuel.ReservedVolume+" литров");
                    PrintCheck((volume*fuel.Price).ToString());
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
                foreach (Fuel fuel in station)
                {
                    Console.WriteLine(fuel.Name + " : " + fuel.Price);
                }
            }
            void PrintCheck(string s)
            {
                StreamWriter sw = new StreamWriter("C:\\Users\\DeminMS\\out.txt");
                sw.WriteLine(s);
                sw.Close();
                
                
            }
        }
    }
    class Fuel
    {
        string _name;
        int _reservedvolume;
        double _price;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }

        }
        public int ReservedVolume
        {
            get { return this._reservedvolume; }
            set { this._reservedvolume = value; }
        }
        public double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }
        public Fuel(string name, int reservedvolume, double price)
        {
            this._name = name;
            this._reservedvolume = reservedvolume;
            this._price = price;
        }
    }
    
}