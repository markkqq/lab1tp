using System;
using System.Collections.Generic;
namespace petrolstation
{
    internal class Purchase
    {
        public DateTime Date { get; }
        public Client Client { get; }
        public int Volume { get; }
        public Fuel Fuel { get; }

        public Purchase(DateTime date, Client client, int volume, Fuel fuel)
        {
            Date = date;
            Client = client ?? throw new ArgumentNullException(nameof(client));
            if(volume<0)
            {
                throw new ArgumentException("Объем купленного топлива не может быть отрицательным числом", nameof(volume));
            }
            else
            {
                Volume = volume;
            }
            Volume = volume;
            Fuel = fuel ?? throw new ArgumentNullException(nameof(fuel));
        }

    }
}