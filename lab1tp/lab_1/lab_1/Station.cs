using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
namespace lab_1
{
    class Station
    {
        private List<Fuel> _fuels = new List<Fuel>();
        public List<Fuel> GetFuels
        {
            get { return this._fuels; }
        }
        public void ShowTariffs()
        {
            if (_fuels.Count > 0)
            {
                Console.WriteLine("цены на топливо");
                foreach (Fuel fuel in _fuels)
                {
                    Console.WriteLine("Тип топлива : {0}, Цена : {1}, Осталось литров : {2}", fuel.Name, fuel.Price, fuel.ReservedVolume);
                }
            }
        }
        public void LoadTariffs(string path)
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
                        Fuel fuel = new Fuel(name, reservedvolume, price);
                        _fuels.Add(fuel);
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
        public void RunStation()
        {
            bool processing = true;
            while (processing)
            {
                Customer customer = new Customer();
                customer.CreateCustomer();
                string order = Console.ReadLine();
                foreach (Fuel fuel in this.GetFuels)
                {
                    if (order == fuel.Name)
                    {
                        try
                        {
                            Console.WriteLine("Выберите режим заправки");
                            Console.WriteLine("Залить полный бак - 1 Залить произвольное количество литров - 2");
                            switch (ChooseMode())
                            {
                                case ConsoleKey.D1:
                                    {
                                        SpecialPour(fuel,customer);
                                        break;
                                    }
                                case ConsoleKey.D2:
                                    {
                                        DefalutPour(fuel);
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                           Console.Write("Количество литров ");
                            
                            
                            /* GasolinePayment payment = new GasolinePayment(fuel);
                            payment.Pay();
                           */

                        }
                        catch
                        {
                            Console.WriteLine("Некорректный ввод");
                        }
                    }
                }
                this.ShowTariffs();
            }
        }
        private bool CheckVolume(Fuel fuel, int volume)
        {
            if ( volume>0 & fuel.ReservedVolume - volume <0 & fuel.ReservedVolume > 0) return true;

            else return false;
        }
        private int ChangeVolume(Fuel fuel, int volume)
        {
            Console.WriteLine("К сожалению, в АЗС осталось только {0} литров топлива. Залить оставшееся? Y/N", fuel.ReservedVolume);
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("");
                volume = volume - (volume - fuel.ReservedVolume);
            }
            else if (Console.ReadKey().Key == ConsoleKey.N)
            {
                Console.WriteLine();
                volume = 0;
            }
            
            return volume;
        }
        private ConsoleKey ChooseMode()
        {
            ConsoleKey consoleKey = Console.ReadKey().Key;
            return consoleKey;
        }
 
    }
}
