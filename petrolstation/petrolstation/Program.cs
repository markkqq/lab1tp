using System;

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
                Station station = new Station();
                

            }
            else
            {
                
            }
        }
    }
}
