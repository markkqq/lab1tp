using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
namespace lab_1
{
    class Station
    {
        private static Dictionary<Fuel,double> _fuels = new Dictionary<Fuel, double>();
        public static Dictionary<Fuel,double> GetFuels
        {
            get { return Station._fuels; }
        }
        public static void AddFuel(Fuel fuel)
        {
            _fuels.Add(fuel,100);
        }
        public static void RunStation()
        {
            bool processing = true;
            while (processing)
            {
                Customer customer = new Customer();
                customer.CreateCustomer();
                string order = Console.ReadLine();
                foreach (KeyValuePair<Fuel,double> fuel in Station.GetFuels)
                {
                    if (order == fuel.Key.ToString())
                    {
                        try
                        {
                            Console.WriteLine("�������� ����� ��������");
                            Console.WriteLine("������ ������ ��� - 1 ������ ������������ ���������� ������ - 2");
                            /*switch (ChooseMode())
                            {
                                case ConsoleKey.D1:
                                    {
                                        //SpecialPour(fuel,customer);
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
                           Console.Write("���������� ������ ");*/
                            
                            
                            /* GasolinePayment payment = new GasolinePayment(fuel);
                            payment.Pay();
                           */

                        }
                        catch
                        {
                            Console.WriteLine("������������ ����");
                        }
                    }
                }
                Menu.ShowTariffs();
            }
        }
        private bool CheckVolume(Fuel fuel, int volume)
        {
            if ( volume>0 & _fuels[fuel] - volume <0 & _fuels[fuel] > 0) return true;
            else return false;
        }
        private double ChangeVolume(Fuel fuel, double volume)
        {
            Console.WriteLine("� ���������, � ��� �������� ������ {0} ������ �������. ������ ����������? Y/N", _fuels[fuel]);
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
