using System;
using System.Collections.Generic;
namespace petrolstation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                FileReader fileReader = new FileReader(args);
                QueueGenerator queueGenerator = new QueueGenerator(fileReader.ReadFuels());
                FacilityGenerator facilityGenerator = new FacilityGenerator(fileReader.ReadFuels());
                List<Facility> facilities = new List<Facility>();
                Station station = new Station();
                Facility facility = new Facility(fileReader.ReadFuels());
                Facility facility1 = new Facility(fileReader.ReadFuels());
                facilities.Add(facility);
                facilities.Add(facility1);
                station.AddFacilities(facilities);
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
}
