using System;

namespace lab_1
{
    class Fuel
    {
        public string Name
        {
            get;
            set;

        }
        public int ReservedVolume
        {
            get;
            set;
        }
        public double Price 
        { 
            get; 
            set; 
        }
        public Fuel(string name, int reservedvolume, double price)
        {
            this.Name = name;
            this.ReservedVolume = reservedvolume;
            this.Price = price;
        }
    }
}