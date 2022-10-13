using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
namespace lab_1
{
    class Station
    {
        private Dictionary<Fuel,double> _fuels = new Dictionary<Fuel, double>();
        public Dictionary<Fuel,double> Fuels
        {
            get { return this._fuels; }
            set { this._fuels = value; }
        }
        
        public void RunStation()
        {
            bool processing = true;
            while (processing)
            {
                Customer customer = new Customer();
                customer.CreateCustomer();
                string order = Console.ReadLine();
                foreach (KeyValuePair<Fuel,double> fuel in _fuels)
                {
                    if (order == fuel.Key.ToString())
                    {
                        try
                        {
                            Console.WriteLine("Выберите режим заправки");
                            Console.WriteLine("Залить полный бак - 1 Залить произвольное количество литров - 2");
                            /*switch (ChooseMode())
                            {
                                case ConsoleKey.D1:
                                    {
                                        SpecialPour(fuel,customer);
                                        break;
                                    }
                                case ConsoleKey.D2:
                                    {
                                        //DefalutPour(fuel);
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                           Console.Write("Количество литров ");*/
                            
                            
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
                
            }
        }
        public void LoadFuels(string path)
        {
            Dictionary<Fuel, double> fuels = new Dictionary<Fuel, double>();
            StreamReader sr = new StreamReader(path);
            var file = File.ReadAllText(path);
            while (file != null)
            {
                try
                {
                    string name = sr.ReadLine();
                    double price = double.Parse(sr.ReadLine());
                    if (price < 0)
                    {
                        break;
                    }
                    else
                    {
                        Fuel fuel = new Fuel(name, price);
                        fuels.Add(fuel, 100);
                    }
                }
                catch
                {
                    break;
                }
                file = File.ReadAllText(path);
            }
            this.Fuels = fuels;
        }
        private bool CheckVolume(Fuel fuel, int volume)
        {
            if ( volume>0 & _fuels[fuel] - volume <0 & _fuels[fuel] > 0) return true;
            else return false;
        }
        private double ChangeVolume(Fuel fuel, double volume)
        {
            Console.WriteLine("К сожалению, в АЗС осталось только {0} литров топлива. Залить оставшееся? Y/N", _fuels[fuel]);
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("");
                volume = volume - (volume - _fuels[fuel]);
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
