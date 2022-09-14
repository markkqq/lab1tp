using System;
using System.Collections.Generic;
using System.IO;
namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("C:\\Users\\Андрей\\source\\repos\\lab1tp\\lab_1\\1.txt");
            List<Fuel> station = new List<Fuel>();
            string stringtoread = sr.ReadLine();
            while (stringtoread != null)
            {
                Fuel newfuel = new Fuel(
                    stringtoread,
                    int.Parse(sr.ReadLine()),
                    Convert.ToDouble(sr.ReadLine())
                    );
                station.Add(newfuel);
                stringtoread = sr.ReadLine();
            }
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
                    PrintCheck(
                        "В "+ 
                        DateTime.Now.ToString()+ " "+
                        "Водитель приобрел следующее топливо: "+fuel.Name+"\n"+
                        "Купил"+volume.ToString()+" литров."+"\n"+
                        "К оплате "+
                    (volume*fuel.Price).ToString()+"рублей."+"\n"
                        );
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
                string path = "C:\\Users\\Андрей\\Desktop\\out.txt";
                File.AppendAllText(path,s+"\n");
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