namespace petrolstation
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                UserConsoleInterface userConsoleInterface = new();
                FileReader fileReader = new FileReader(args);
                FileSaver fileSaver = new FileSaver();
                Generator generator = new Generator(fileReader);
                Station station = new Station(generator, userConsoleInterface, fileSaver);
                station.Run();

            }
            else
            {

            }
        }
    }
    
}
