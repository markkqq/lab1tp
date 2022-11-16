using System;
namespace petrolstation
{
    public class Purchase
    {
        public Client Client { get; }
        public int Volume { get; }
        public Fuel Fuel { get; }

        public Purchase(Client client, int volume, Fuel fuel)
        {
            Client = client ?? throw new ArgumentNullException(nameof(client));
            if (volume < 0)
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