using System;
using System.Collections.Generic;
using System.IO;

namespace petrolstation
{
    public class FileReader : IFileReader
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

            string file = File.ReadAllText(Args[0]);

            if (file == null)
            {
                throw new ArgumentNullException("Файл пустой",
                                                nameof(file));
            }
            else
            {
                string line = streamReader.ReadLine();
                do
                {

                    try
                    {
                        string name = line;
                        line = streamReader.ReadLine();
                        double price = double.Parse(line);
                        if (price < 0)
                        {
                            throw new Exception();
                        }
                        else
                        {
                            Fuel fuel = new Fuel(name, price);
                            fuels.Add(fuel);
                            line = streamReader.ReadLine();
                        }

                    }
                    catch
                    {

                    }
                } while (line != null);
            }
            return fuels;
        }
        public int ReadAmountofFacilities()
        {
            int amount;
            StreamReader sr = new StreamReader(Args[1]);
            string line = sr.ReadLine();
            if (!int.TryParse(line, out amount))
            {
                throw new Exception("Неверный формат");
            }
            if (amount < 0)
            {
                throw new Exception("Количество колонок должно быть выражено положительным числом");
            }
            return amount;
        }
        public int[] ReadAmountofClients()
        {
            int[] clientsinterval = new int[2];
            StreamReader sr = new StreamReader(Args[2]);
            if (!int.TryParse(sr.ReadLine(), out clientsinterval[0]) | !int.TryParse(sr.ReadLine(), out clientsinterval[1]))
            {
                throw new Exception();
            }
            if (clientsinterval[0] < 0 | clientsinterval[1] < 0)
            {
                throw new Exception();
            }
            if (clientsinterval[0] > clientsinterval[1])
            {
                int buf = clientsinterval[0];
                clientsinterval[0] = clientsinterval[1];
                clientsinterval[1] = buf;
            }
            return clientsinterval;
        }
    }
}
