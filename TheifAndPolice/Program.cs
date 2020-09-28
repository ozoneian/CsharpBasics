using System;
using System.Collections.Generic;
using System.Globalization;

namespace TheifAndPolice
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int height = 20;
                int width = 40;
                DrawCitySize(height, width, CreatePeople(height, width));
               
                Console.ReadKey(true);
            }
        }
        static void DrawCitySize(int height, int width, List<Person> people)
        {
            char[,] array2d = new char[height, width];

            for (int i = 0; i < array2d.GetLength(0); i++)
            {
                for (int j = 0; j < array2d.GetLength(1); j++)
                {
                    if (j == 0 || i == 0 || j == array2d.GetLength(1) - 1 || i == array2d.GetLength(0) - 1)
                    {
                        array2d[i, j] = '*';
                        Console.Write(array2d[i, j]);
                        
                    }
                    
                    else
                        Console.Write(array2d[i, j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < people.Count; i++)
            {
                Console.WriteLine($" {people[i]} direction: {people[i].Direction} inventory: {people[i].Inventory} posX: {people[i].PositionX} posY: {people[i].PositionY}" );
            }
        }
        static List<Person> CreatePeople(int height, int width)
        {
            int numberOfPeople = 5;
            Random rnd = new Random();
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                Thief thief = new Thief
                {
                    PositionX = rnd.Next(0, width),
                    PositionY = rnd.Next(0, height)
                };
                Citizen citizen = new Citizen
                {
                    PositionX = rnd.Next(0, width),
                    PositionY = rnd.Next(0, height)
                };
                Police police = new Police
                {
                    PositionX = rnd.Next(0, width),
                    PositionY = rnd.Next(0, height)
                };

                people.Add(thief);
                people.Add(citizen);
                people.Add(police);

            }
            return people;


        }
    }
}
