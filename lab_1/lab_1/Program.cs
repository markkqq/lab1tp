using System;
using System.Collections.Generic;
using System.IO;


namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileToRead fileToRead = new FileToRead(args[0]);
            Station station = new Station();
           
            //bool processing = true;
            
            station.ShowInfo(); 
           /* while (processing)
            {
                Console.WriteLine("Введите название топлива");
                string data = Console.ReadLine();
                foreach(Fuel fuel in station)
                {
                    if (fuel.Name == data)
                    {
                        if (fuel.ReservedVolume > 0)
                        {
                            station.Pay(fuel);
                        }
                        else
                        {
                            Console.WriteLine("В азс не осталось данного типа топлива");
                        }
                    }
                }
                
                
            }*/
            
           
            
        }
    }
    class Fuel
    {
        string _name;
        int _reservedvolume;
        public string Name
        {
            get;
            set;

        }
        public int ReservedVolume
        {
            get;
            set;
        }
        public double Price { get; set; }
        public Fuel(string name, int reservedvolume, double price)
        {
            this._name = name;
            this._reservedvolume = reservedvolume;
            this.Price = price;
        }
    }
    class Station
    {
        private List<Fuel> fuels = new List<Fuel>();
        public void AddFuel(Fuel fuel)
        {
            fuels.Add(fuel);
        }
        public void Pay(Fuel fuel)
        {

            int volume;
            Console.WriteLine("количество");
            int.TryParse(Console.ReadLine(), out volume);
            if (volume > 0 & fuel.ReservedVolume - volume >= 0)
            {
                Console.WriteLine("К оплате " + volume * fuel.Price);
                fuel.ReservedVolume -= volume;
                Console.WriteLine("В АЗС осталось" + fuel.ReservedVolume + " литров");
                PrintCheck(
                    "В " +
                    DateTime.Now.ToString() + " " +
                    "Водитель приобрел следующее топливо: " + fuel.Name + "\n" +
                    "Купил" + volume.ToString() + " литров." + "\n" +
                    "К оплате " +
                (volume * fuel.Price).ToString() + "рублей." + "\n"
                    );
            }
            else
            {
                Console.WriteLine("неправильный формат данных");
                Console.Clear();
                ShowInfo();
            }
        }
        public void PrintCheck(string s)
        {
            string path = "C:\\Users\\Андрей\\Desktop\\out.txt";
            File.AppendAllText(path, s + "\n");
        }
        public void ShowInfo()
        {
            Console.WriteLine("цены на топливо");
            foreach (Fuel fuel in fuels)
            {
                Console.WriteLine(fuel.Name + " : " + fuel.Price);
            }
        }
    }
    class FileToRead
    {
        private string _path;
        public FileToRead(string path)
        {
            _path = path;
        }
        public bool CheckErrors()
        {
            bool result = true;
            StreamReader sr = new StreamReader(_path);
            string stringtoread = String.Empty;
            while (stringtoread != null & result)
            {
                try
                {
                    string s = stringtoread = sr.ReadLine();
                    int i = int.Parse(sr.ReadLine());
                    double d = double.Parse(sr.ReadLine());
                    if (i < 0 || d < 0)
                    {
                        result = false;
                    }
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }
        public void ReadFile(string _path)
        {
            if (CheckErrors())
            {
                
            }
        }
    }
}