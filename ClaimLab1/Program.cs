using System;
using System.Collections.Generic;

namespace ClaimLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string menuText = @"Welcome to the grade manager!

2. Add Grade

Please select one of the above options:";

            List<double> grades = new List<double>();

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
                    ShowError($"'{input}' is not a valid integer.");
                    continue;
                }


                switch (option)
                {
                    case 2:
                        AddGrade(grades);
                        break;
                    default:
                        ShowError($"The number {option} is outside the allowed range.");
                        continue;
                }

                Pause();
            } while (true);
            
        }

        private static void ShowError(string message)
        {
            Console.Beep();
            Console.WriteLine(message);
            Pause();
        }

        static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        

        static void AddGrade(List<double> grades)
        {
            bool valid;
            do
            {
                Console.Clear();
                Console.WriteLine($"Please enter a grade for Student {grades.Count}:");

                string input = Console.ReadLine();

                try
                {
                    double grade = double.Parse(input);
                    grades.Add(grade);
                    valid = true;
                }
                catch
                {
                    ShowError($"'{input}' is not a valid grade.");
                    valid = false;
                }

            } while (!valid);

        }
    }
}
