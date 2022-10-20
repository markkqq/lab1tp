using System;

namespace petrolstation
{
    internal class Car
    {
        public int TankCapacity { get; }
        public Fuel FuelType { get; }

        public Car(int tankCapacity, Fuel fuelType)
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
            FuelType = fuelType ?? throw new ArgumentNullException(nameof(fuelType));
        }
    }
}