using System;

namespace ClaimLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string menuText = @"Welcome to the grade manager!

Please select one of the above options:";


            do
            {
                Console.Clear();
                Console.WriteLine(menuText);
                string input = Console.ReadLine();

                int option;
                try
                {
                    option = int.Parse(input); 
                }
                catch (Exception)
                {
                    Console.Beep();
                    Console.WriteLine($"'{input}' is not a valid integer.");
                    Pause();
                    continue;
                }


                switch(option)
                {
                    default:
                        Console.Beep();
                        Console.WriteLine($"The number {option} is outside the allowed range.");
                        break;
                }

                Pause();
            } while (true);
            
        }


        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        
    }
}
