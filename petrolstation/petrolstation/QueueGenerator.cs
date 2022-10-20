using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petrolstation
{
    class QueueGenerator
    {
        Random r = new Random();
        public List<Fuel> Fuels { get; }
        public QueueGenerator(List<Fuel> fuels)
        {
            Fuels = fuels;
        }
        public Queue<Client> GenerateQueue()
        {
            Queue<Client> clients = new Queue<Client>();
            int clientsAmount = r.Next(2, 5);
            for(int clientNumber = 0; clientNumber < clientsAmount; clientNumber++)
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
            Client client = new Client(car,wallet);
            return client;
        }
        private Wallet GenerateWallet()
        {
            Wallet wallet = new Wallet(r.Next(5000, 10000));
            return wallet;
        }
        private Car GenerateCar()
        {
            List<Fuel> fuelTypes = CreateFuelPool();
            
            int randomCapacity = r.Next(50, 80);
            int currentvolume = randomCapacity-r.Next(30,40);
            Car car = new Car(randomCapacity,currentvolume,fuelTypes);
            return car;
        }
        private List<Fuel> CreateFuelPool()
        {
            List<Fuel> startfuels = Fuels;
            List<Fuel> endfuels = new List<Fuel>();
            int amount = r.Next(1, 3);
            for(int i = 0; i < amount; i++)
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
