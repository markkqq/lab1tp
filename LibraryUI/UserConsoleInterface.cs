using System;
using System.Collections.Generic;
using static petrolstation.Station;

namespace petrolstation
{
    public class UserConsoleInterface : IUI
    {
        public void ShowFacilities(List<Facility> facilities)
        {

            for (int i = 0; i < facilities.Count; i++)
            {
                Dictionary<Fuel, int> availableFuels = facilities[i].AvailableFuels;
                Console.WriteLine(@"Колонка номер {0} - имеются следующие виды топлива на данной станции", i);
                Console.WriteLine('\n');
                foreach (KeyValuePair<Fuel, int> keyValuePair in availableFuels)
                {
                    Fuel key = keyValuePair.Key;
                    int reservedVolume = keyValuePair.Value;
                    Console.WriteLine(@"Топливо вида {0} - цена {1} рублей, На данной колонке осталось {2} литров данного типа топлива", key.Name, key.Price, reservedVolume);

                }
                Console.WriteLine('\n');
            }
        }
        public void ShowClient(Client client)
        {
            Console.WriteLine(@"Приехал новый клиент! Вместимость бака у данного клиента: {0} литров. На данный момент в баке {1} литров. ", client.Car.TankCapacity, client.Car.CurrentVolume);
            Console.WriteLine("Виды топлива, которые принимает автомобиль клиента: ");
            foreach (Fuel fuelType in client.Car.FuelTypes)
            {
                Console.WriteLine(fuelType.Name);
            }
        }
        public char CollectPourType()
        {
            Console.WriteLine("Выберите тип покупки топлива: 1 - Ввести свое число литров 2 - Заправить полный бак");
            string s = (Console.ReadLine());
            return Enum.Parse(typeof(PourType), s);
            Console.WriteLine();
            return s[0];
        }

        public string CollectFuelName()
        {
            Console.WriteLine("Введи тип топлива, который хотите приобрести");
            string fuelType = Console.ReadLine();
            return fuelType;
        }
        public int CollectVolume()
        {
            Console.WriteLine("Введите объем топлива, который хотите приобрести");
            int volume;
            try
            {
                volume = int.Parse(Console.ReadLine());
                return volume;
            }
            catch
            {
                Console.WriteLine("Введено некорректно");
            }
            return 0;
        }
        public void Success()
        {
            Console.WriteLine("Успешно");
        }
        public void Error()
        {
            Console.WriteLine("Ошибка");
        }
    }
}
