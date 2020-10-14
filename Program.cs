using System;

namespace DailyBattles
{
    class Program
    {

        private DailyBattles Battle = new DailyBattles();
        static void Main(string[] args)
        {
            Console.WriteLine("Starting console application...");
            StartUp.Run();
            Console.WriteLine("Attempting to load DailyBattles files...");
            try
            {
                
            }
            catch (Exception e)
            {
                Console.WriteLine("WARNING: Couldn't load files. Check that all files are present or reinstall the extension.");
            }
        }

    }
}
