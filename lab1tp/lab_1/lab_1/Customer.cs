using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    class Customer
    {
        public int TankCapacity
        {
            get;set;
        }
        public int WalletCapacity
        {
            get;set;
        }
        public void CreateCustomer()
        {
            Random r = new Random();
            this.TankCapacity = r.Next(100, 150);
            this.TankCapacity -= r.Next(50, 75);
            this.WalletCapacity = r.Next(5000, 15000);
        }

    }
}
