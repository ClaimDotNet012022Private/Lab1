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
4. Show Best Grade
5. Show Worst Grade
6. Remove Grade
7. Edit Grade
8. Exit Application

Please select one of the above options:";

            List<double> grades = new List<double>();

            bool shouldContinue = true;
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
                    case 4:
                        ShowBestGrade(grades);
                        break;
                    case 5:
                        ShowWorstGrade(grades);
                        break;
                    case 6:
                        RemoveGrade(grades);
                        break;
                    case 7: 
                        EditGrade(grades);
                        break;
                    case 8:
                        shouldContinue = false;
                        Console.Write("Exiting. ");
                        break;
                    default:
                        ShowError($"The number {option} is outside the allowed range.");
                        continue;
                }

                Pause();
            } while (shouldContinue);
            
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

        static void ShowBestGrade(List<double> grades)
        {
            Console.Clear();

            if (grades.Count > 0)
            {
                double max = double.MinValue;
                foreach (double grade in grades)
                {
                    max = Math.Max(max, grade);
                }

                Console.WriteLine($"Best Grade: {max}");
            }
            else
            {
                Console.WriteLine("There are no grades to display.");
            }
        }

        static void ShowWorstGrade(List<double> grades)
        {
            Console.Clear();

            if (grades.Count > 0)
            {
                double min = double.MaxValue;
                foreach (double grade in grades)
                {
                    min = Math.Min(min, grade);
                }

                Console.WriteLine($"Worst Grade: {min}");
            }
            else
            {
                Console.WriteLine("There are no grades to display.");
            }
        }


        static void RemoveGrade(List<double> grades)
        {
            if (grades.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("There are no grades to remove.");
                return;
            }

            bool valid;
            do
            {
                ShowGrades(grades);

                Console.WriteLine("Enter the student ID for the grade to remove:");

                string input = Console.ReadLine();
                int studentId = 0;
                try
                {
                    studentId = int.Parse(input);
                    grades.RemoveAt(studentId);
                    valid = true;
                }
                catch(FormatException)
                {
                    ShowError($"'{input}' is not a valid ID number.");
                    valid = false;
                }
                catch(ArgumentOutOfRangeException)
                {
                    ShowError($"There is no student with ID number {studentId}");
                    valid = false;
                }

            } while (!valid);

        }

        static void EditGrade(List<double> grades)
        {
            if (grades.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("There are no grades to edit.");
                return;
            }

            bool valid;
            do
            {
                ShowGrades(grades);

                Console.WriteLine("Enter the student ID for the grade to edit:");

                string input = Console.ReadLine();
                int studentId = 0;
                try
                {
                    studentId = int.Parse(input);

                    valid = EditGradeForStudent(grades, studentId);
                }
                catch (FormatException)
                {
                    ShowError($"'{input}' is not a valid ID number.");
                    valid = false;
                }
                

            } while (!valid);

        }

        static bool EditGradeForStudent(List<double> grades, int studentId)
        {
            bool didSucceed = false;

            string input = "";
            try
            {
                Console.WriteLine($"Current grade for student {studentId}: {grades[studentId]}");
                Console.WriteLine("Enter the new grade:");
                input = Console.ReadLine();

                double newGrade = double.Parse(input);
                grades[studentId] = newGrade;
                didSucceed = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                ShowError($"There is no student with ID number {studentId}");
                didSucceed = false;
            }
            catch (FormatException)
            {
                ShowError($"'{input}' is not a valid grade.");
                didSucceed = false;
            }


            return didSucceed;
        }

    }
}
