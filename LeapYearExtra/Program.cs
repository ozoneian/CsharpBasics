using System;
using System.IO;
using System.Linq;

namespace LeapYearExtra
{
    class Program
    {
        
        static void Main(string[] args)
        {
            EnterYears();
        }
        static void EnterYears()
        {
            Console.WriteLine("Please a number of years seperated by ' ': ");
            string ofYears = Console.ReadLine();
            string[] years = ofYears.Split(" ");
            //string currentFile = @"D:\C# and .NET\Foundational course C#\Exercises\LeapYearExtra\LeapYearExtra.csproj";

            //if (File.ReadAllLines(currentFile).Contains(ofYears))
            //{
            //    Console.WriteLine("Match");
            //}
            //else
            //{
            //    Console.WriteLine("No match");
            //}
            //Console.ReadKey(true);

            DrawLeapYear(years);
        }
        static void DrawLeapYear(string[] getYears)
        {

            foreach (string year in getYears)
            {
                int isLeapYear = int.Parse(year);

                if ((isLeapYear % 4 == 0 && isLeapYear % 100 !=0) || isLeapYear %400==0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(year + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(year + " ");
                }
                Console.ResetColor();
            }
        }
    }
}
