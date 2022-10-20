using System;
using System.Collections.Generic;
namespace petrolstation
{
    internal class Car
    {
        public int TankCapacity { get; }
        public int CurrentVolume { get; }
        public List<Fuel> FuelTypes { get; }
        Random r = new Random();
        public Car(
            int tankCapacity,
            int currentVolume,
            List<Fuel> fuelTypes)
        {
            if (tankCapacity <= 0)
            {
                throw new ArgumentException("Объем бака должен выражаться положительным числом",
                                            nameof(tankCapacity));
            }
            else
            {
                TankCapacity = tankCapacity;   
            }
            CurrentVolume = currentVolume;
            FuelTypes = fuelTypes ?? throw new ArgumentNullException(nameof(fuelTypes));
        }
    }
}