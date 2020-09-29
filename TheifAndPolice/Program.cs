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
                DrawCitySize(height, width, Person.CreatePeople(height,width));
               
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
                Console.WriteLine($" {people[i].GetType().Name} direction: {people[i].Direction} inventory: {people[i].Inventory} posX: {people[i].PositionX} posY: {people[i].PositionY}");
            }
        }
        
    }
}
