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
                /*Menu.LoadTariffs(args[0]);
                Menu.ShowTariffs();*/
                Station.RunStation();
            }
            else
            {
                Console.WriteLine("запуск невозможен");
            }
        }
    }
}