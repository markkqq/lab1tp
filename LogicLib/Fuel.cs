using System;

namespace petrolstation
{
    public class Fuel
    {
        public Fuel(string name, double price)
        {
            Name = name
                ?? throw new ArgumentNullException(nameof(name));
            if (price >= 0)
            {
                Price = price;
            }
            else
            {
                throw new ArgumentException("Цена топлива за литр должна быть положительной",
                                            nameof(price));
            }
        }
        public Fuel()
        {

        }

        public string Name { get; }
        public double Price { get; }
    }
}