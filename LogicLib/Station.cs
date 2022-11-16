using System;
using System.Collections.Generic;

namespace petrolstation
{
    public class Station
    {
        private Cashbox _cashbox = new Cashbox();
        private IUI ui;
        private IFileSaver fileSaver;
        public List<Fuel> Fuels { get; }
        public List<Facility> Facilities { get; }
        public Queue<Client> Clients { get; }
        public void Run()
        {

            
            ui.ShowFacilities(Facilities);

            while (Clients.Count > 0)
            {
                Client currentClient = Clients.Peek();

                ui.ShowClient(currentClient);

                string fuelType = ui.CollectFuelName();
                Fuel fuel = GetFuel(fuelType);
                if (fuel == null)
                {
                    ui.Error();
                    
                }
                if (!currentClient.Car.IsAllowedType(fuel))
                {
                    continue;
                }
                else
                {
                    foreach (Facility facility in Facilities)
                    {
                        if (facility.AvailableFuels.ContainsKey(fuel))
                        {
                            if (facility.AvailableFuels[fuel] > 0)
                            {
                                var pourType = ui.CollectPourType();
                                int volume = CountVolume(facility, fuel, currentClient, pourType);
                                currentClient.Car.CurrentVolume += volume;
                                currentClient.Wallet.Money -= Convert.ToInt32(volume * fuel.Price);
                                facility.AvailableFuels[fuel] -= volume;
                                ui.Success();
                                Clients.Dequeue();

                                Purchase purchase = new Purchase(currentClient, volume, fuel);
                                _cashbox.AddPurchase(purchase);
                                fileSaver.SaveFile(purchase);
                                break;
                            }
                        }
                    }
                }
            }

        }

        private Fuel GetFuel(string fuelType)
        {
            foreach(Fuel fuel in Fuels)
            {
                if (fuelType == fuel.Name)
                {
                    return fuel;
                }
            }
            return null;
        }

        public Station(Generator generator, IUI uI, IFileSaver fileSaver)
        {
            ui = uI;
            this.fileSaver = fileSaver;
            Facilities = generator.GenerateFacilities();
            Clients = generator.GenerateQueue();
            Fuels = generator.Fuels;
        }
        private int CountVolume(Facility facility, Fuel fuel, Client client, PourType pourType)
        {
            int pourVolume;
            switch (pourType)
            {
                case PourType.DefaultPour:
                    pourVolume = ui.CollectVolume();
                    if (client.Car.CurrentVolume + pourVolume > client.Car.TankCapacity)
                    {
                        pourVolume = client.Car.TankCapacity - client.Car.CurrentVolume;
                    }
                    break;
                case PourType.SpecialPour:
                    pourVolume = client.Car.TankCapacity - client.Car.CurrentVolume;
                    break;
                default:
                    pourVolume = 0;
                    break;
            }


            int reservedVolume = facility.AvailableFuels[fuel];

            if (reservedVolume < pourVolume)
            {
                pourVolume = pourVolume - (pourVolume - reservedVolume);
            }

            int payment = Convert.ToInt32(pourVolume * fuel.Price);
            int clientMoney = client.Wallet.Money;

            if (clientMoney - payment < 0)
            {
                payment = clientMoney;
                pourVolume = payment / Convert.ToInt32(fuel.Price);
            }
            return pourVolume;
        }
        public enum PourType
        {
            DefaultPour = 1,
            SpecialPour = 2
        }
    }
}
