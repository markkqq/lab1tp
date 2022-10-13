using System;
using System.Collections.Generic;
using System.IO;


namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                Station station = new Station();
                station.LoadFuels(args[0]);
                station.RunStation();
            }
            else
            {
                Console.WriteLine("запуск невозможен");
            }
        }
    }
}