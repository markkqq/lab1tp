using System;
using System.Collections.Generic;
namespace petrolstation
{
    public class Car
    {
        public int TankCapacity { get; }
        public int CurrentVolume { get; set; }
        public List<Fuel> FuelTypes { get; }
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
        public bool IsAllowedType(Fuel fuel)
        {
            return FuelTypes.Contains(fuel);
        }
    }
}