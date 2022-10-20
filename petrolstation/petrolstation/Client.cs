namespace petrolstation
{
    internal class Client
    {
        public Wallet Wallet { get; }
        public Car Car { get; }
        public Client(Car car, Wallet wallet)
        {
            Car = car;
            Wallet = wallet;
        }
    }
}