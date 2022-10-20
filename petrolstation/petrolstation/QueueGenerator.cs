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
            Fuel randomFuel = Fuels[r.Next(0, Fuels.Count - 1)];
            int randomCapacity = r.Next(30, 80);
            Car car = new Car(randomCapacity,randomFuel);
            return car;
        }
        
    }
}
