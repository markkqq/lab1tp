using System;

namespace lab_1
{
    struct Fuel
    {
        public string Name
        {
            get;
            set;
        }
        
        public double Price 
        { 
            get; 
            set; 
        }
        public Fuel(string name, double price)
        {
            this.Name = name;
            
            this.Price = price;
        }
    }
}