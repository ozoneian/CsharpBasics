using System;

namespace LeapYear
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCalcGetYear();
        }
     
        static void RunCalcGetYear()
        {
            bool runYearCalculator = true;
            while (runYearCalculator)
            {
                Console.WriteLine("Please enter a year: ");
                int yearToDetermine = int.Parse(Console.ReadLine());
                if (yearToDetermine==0)
                {
                    runYearCalculator = false;
                    Console.WriteLine("Closing application... press any key to exit.");
                }
                else
                {
                    Console.Write($"Year {yearToDetermine}");
                    IsLeapYear(yearToDetermine);
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static void IsLeapYear(int year)
        {
            if (year % 4==0)
            {
                if (year%100==0)
                {
                    if (year%400==0)
                    {
                        IsALeapYear();
                    }
                    else
                    {
                        NotAleapYear();
                    }
                }
                else
                {
                    IsALeapYear();
                }

            }
            else
            {
                NotAleapYear();
            }
        }
        static void NotAleapYear()
        {
            Console.Write($" is not a leap year (it has 365 days).");
        }
        static void IsALeapYear()
        {
            Console.Write($" is a leap year (it has 366 days).");

        }
    }
}
