using System;
using System.Linq;

namespace ArraysLists
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nameOfWeatherStations = new string[5];

            for (int i = 0; i < nameOfWeatherStations.Length; i++)
            {
                Console.WriteLine($"Input the name of weatherstation {i+1}: ");
                nameOfWeatherStations[i] = Console.ReadLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = nameOfWeatherStations.Length - 1; i > -1; i--)
            {
                Console.WriteLine(nameOfWeatherStations[i]);
            }
            //Array.Sort(nameOfWeatherStations);
            //foreach (var item in nameOfWeatherStations)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
