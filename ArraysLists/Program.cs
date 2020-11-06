using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysLists
{
    class Program
    {
        string[] WeatherStations = new string[5];
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            
        }
        public void Run()
        {
            NameInput();
            ReverseOutput();
            OrderAlpha();
            ChangeName();
            GetData();
            Console.ReadKey();
        }
        public void NameInput()
        {
            for (int i = 0; i < WeatherStations.Length; i++)
            {
                NameValidation(i);
            }
        }

        private void NameValidation(int i)
        {
            string input;
            do
            {
                Console.WriteLine($"Input the name of weatherstation {i + 1}: ");
                input = Console.ReadLine();

            } while (string.IsNullOrWhiteSpace(input) || input.Length < 3);
            WeatherStations[i] = input;
        }

        public void ReverseOutput()
        {
            for (int i = WeatherStations.Length; i > 0; i--)
            {
                Console.WriteLine($"Name: {WeatherStations[i-1]}");
            }
        }
        public void OrderAlpha()
        {
            Array.Sort(WeatherStations);
        }
        public void ChangeName()
        {
            CurrentWeatherStations();
            bool success;
            do
            {
                Console.WriteLine("Input the number of the name you want to change: ");

                success = int.TryParse(Console.ReadLine(), out int result);
                if (result - 1 < WeatherStations.Length && result>=0 && success)
                {
                    NameValidation(result - 1);
                }
                else
                    success = false;

            } while (!success);

        }

        private void CurrentWeatherStations()
        {
            int num = 0;

            foreach (var name in WeatherStations)
            {
                Console.WriteLine($"{num + 1}. {name}");
                num++;
            }
        }
        public void GetData()
        {
            CurrentWeatherStations();
            bool success;
            do
            {
                Console.WriteLine("Input the number of the weatherstation to recieve data from: ");

                success = int.TryParse(Console.ReadLine(), out int result);
                if (result - 1 < WeatherStations.Length && result >= 0 && success)
                {
                    InputData(result-1);
                }
                else
                    success = false;

            } while (!success);

        }
        public void InputData(int name)
        {
            Console.Clear();
            Console.WriteLine($"Collect data from: {WeatherStations[name]}.");
            bool success;
            do
            {
                Console.WriteLine("How many data-collections has been done?: ");
                success = int.TryParse(Console.ReadLine(), out int result);
                if (result > 2)
                {
                    int[] temperature = new int[result];
                    for (int i = 0; i < temperature.Length; i++)
                    {
                        bool validTemp;
                        do
                        {

                        Console.WriteLine($"Input the temperature of measurement [{i + 1}] : ");
                        validTemp = int.TryParse(Console.ReadLine(), out int temp);
                        temperature[i] = temp;

                        } while (!validTemp);

                    }
                    double average = CalcAverage(temperature);
                    Console.WriteLine($"The average temperature at {WeatherStations[name]}: {average} celsius.");
                }
                else
                    success = false;


            } while (!success);


        }
        public double CalcAverage(int[] data)
        {
            var q = data
                .Average();
            return q;
        }
    }
}
