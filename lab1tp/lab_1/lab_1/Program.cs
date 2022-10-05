using System;
using System.Collections.Generic;
using System.IO;


namespace lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Station station = new Station();
            station.LoadTariffs(args[0]);
            station.ShowTariffs();
            station.RunStation();
        }
    }
}