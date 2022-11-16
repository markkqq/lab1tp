using System.Collections.Generic;

namespace petrolstation
{
    internal class Cashbox
    {
        List<Purchase> purchases = new List<Purchase>();
        public void AddPurchase(Purchase p)
        {
            purchases.Add(p);
        }
    }
}