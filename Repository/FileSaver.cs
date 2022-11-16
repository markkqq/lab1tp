using System.IO;

namespace petrolstation
{
    public class FileSaver : IFileSaver
    {
        private static int fileNumber = 0;
        public FileSaver()
        {

        }
        public void SaveFile(Purchase purchase)
        {
            while (File.Exists(string.Format(fileNumber.ToString() + ".txt")))
            {
                fileNumber++;
            }

            StreamWriter streamWriter = new StreamWriter(fileNumber.ToString() + ".txt");
            streamWriter.WriteLine(@"Клиент приобрел {0} литров {1} топлива. Заплатил {2} рублей. В кошельке осталось {3} рублей. ", purchase.Volume, purchase.Fuel.Name, purchase.Volume * purchase.Fuel.Price, purchase.Client.Wallet.Money);
            streamWriter.Close();
        }
    }
}
