using System;
using System.Collections.Generic;
using System.Linq;

namespace petrolstation
{
    public class Generator
    {
        private IFileReader fileReader;
        Random r = new Random();
        public List<Fuel> Fuels { get; }
        public Generator(IFileReader fileReader)
        {
            this.fileReader = fileReader;
            Fuels = fileReader.ReadFuels();
        }

        public List<Facility> GenerateFacilities()
        {
            int facilitiesAmount = fileReader.ReadAmountofFacilities();
            List<Facility> facilities = new List<Facility>();
            int minValue = 1;
            int maxValue = Fuels.Count;//!!
            while (facilitiesAmount > 0)
            {
                var buf = new List<Fuel>();
                buf = Fuels.ToList();
                Random r = new Random();
                //
                int fuelsAmount = r.Next(minValue, maxValue); // ошибка
                //
                List<Fuel> addingfuels = new List<Fuel>();
                for (int i = 0; i < fuelsAmount; i++)
                {
                    int index = r.Next(0, buf.Count - 1);
                    addingfuels.Add(buf[index]);
                    buf.RemoveAt(index);
                }


                Facility facility = new Facility(addingfuels);
                facilities.Add(facility);

                facilitiesAmount--;
            }
            return facilities;
        }
        public Queue<Client> GenerateQueue()
        {
            int[] interval = fileReader.ReadAmountofClients();
            Queue<Client> clients = new Queue<Client>();
            int clientsAmount = r.Next(interval[0], interval[1]);
            for (int clientNumber = 0; clientNumber < clientsAmount; clientNumber++)
            {
                Client client = GenerateClient();
                clients.Enqueue(client);
            }
            return clients;
        }
        private Client GenerateClient()
        {
            Car car = GenerateCar();
            Wallet wallet = GenerateWallet();
            Client client = new Client(car, wallet);
            return client;
        }
        private Wallet GenerateWallet()
        {
            Wallet wallet = new Wallet(r.Next(5000, 10000));
            return wallet;
        }
        private Car GenerateCar()
        {
            List<Fuel> fuelTypes = GenerateFuelPool();

            int randomCapacity = r.Next(50, 80);
            int currentvolume = randomCapacity - r.Next(30, 40);
            Car car = new Car(randomCapacity, currentvolume, fuelTypes);
            return car;
        }
        private List<Fuel> GenerateFuelPool()
        {
            List<Fuel> startfuels = Fuels.ToList();
            List<Fuel> endfuels = new List<Fuel>();
            int amount = r.Next(1, 3);
            for (int i = 0; i < amount; i++)
            {
                int index = r.Next(0, startfuels.Count - 1);
                Fuel randomFuel = startfuels[index];
                endfuels.Add(randomFuel);
                startfuels.RemoveAt(index);
            }
            return endfuels;
        }


    }
}
