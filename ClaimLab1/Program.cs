using System;
using System.Collections.Generic;

namespace ClaimLab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string menuText = @"Welcome to the grade manager!

1. Show Grades
2. Add Grade
3. Show Average Grade

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
                    case 1:
                        ShowGrades(grades);
                        break;
                    case 2:
                        AddGrade(grades);
                        break;
                    case 3:
                        ShowAverageGrade(grades);
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

        
        static void ShowGrades(List<double> grades)
        {
            Console.Clear();

            if (grades.Count == 0)
            {
                Console.WriteLine("There are no grades to display.");
            }

            for (int s = 0; s < grades.Count; s++) 
            {
                Console.WriteLine($"Student {s}:\t{grades[s]}");
            }
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

        static void ShowAverageGrade(List<double> grades)
        {
            Console.Clear();

            if (grades.Count > 0)
            {
                double sum = 0;
                foreach (double grade in grades)
                {
                    sum += grade;
                }

                double avg = sum / grades.Count;

                Console.WriteLine($"Average Grade: {avg}");
            }
            else
            {
                Console.WriteLine("There are no grades to display.");
            }
        }
    }
}
