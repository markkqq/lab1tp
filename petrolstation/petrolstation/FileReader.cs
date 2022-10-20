using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace petrolstation
{
    class FileReader
    {
        public string[] Args { get; }
        public FileReader(string[] args)
        {
            Args = args;
        }
        public List<Fuel> ReadFuels()
        {
            List<Fuel> fuels = new List<Fuel>();
            StreamReader streamReader = new StreamReader(Args[0]);

            string line = streamReader.ReadLine();

            if (line == null)
            {
                throw new ArgumentNullException("Файл пустой", nameof(line));
            }
            else
            {
                while (line != null)
                {
                    string name = line;
                    line = streamReader.ReadLine();
                    try
                    {
                        double price = double.Parse(line);
                        if(price<0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Fuel fuel = new Fuel(name, price);
                            fuels.Add(fuel);
                        }
                        
                    }
                    catch
                    {
                        
                    }
                }
            }
            return fuels;
        }
    }
}
