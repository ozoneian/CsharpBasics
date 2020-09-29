using System;
using System.Collections.Generic;
using System.Text;

namespace TheifAndPolice
{
    public class Person
    {
        public Random Rand { get; } = new Random();
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Direction { get; set; }

        public virtual List<Item> Inventory { get; } = new List<Item>();

        public Person()
        {
            int direction = Rand.Next(1, 8 + 1); //hopefully a random int(created when object is) between 1,8 that will permanetly decide which switch case to be used for movement.
            Direction = direction;

        }

        public void Move()
        {
            switch (Direction)
            {
                case 1:
                    PositionX--;
                    PositionY--;
                    break;
                case 2:
                    PositionX++;
                    PositionY++;
                    break;
                case 3:
                    PositionX--;
                    PositionY++;

                    break;
                case 4:
                    PositionX++;
                    PositionY--;
                    break;
                case 5:
                    PositionX--;
                    break;
                case 6:
                    PositionY--;
                    break;
                case 7:
                    PositionX++;
                    break;
                case 8:
                    PositionY++;
                    break;

            }
        }
        public static List<Person> CreatePeople(int height, int width)
        {
            int numberOfPeople = 5; //just a random number added for simplification conmtrols the amount of citizen,police,thieves where the amount of each type is equal.
            Random rnd = new Random();
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                Thief thief = new Thief
                {
                    PositionX = rnd.Next(0 + 1, width - 1), //rand initial position
                    PositionY = rnd.Next(0 + 1, height - 1)

                };
                Citizen citizen = new Citizen
                {

                    PositionX = rnd.Next(0 + 1, width - 1),
                    PositionY = rnd.Next(0 + 1, height - 1)

                };
                Police police = new Police
                {
                    PositionX = rnd.Next(0 + 1, width - 1),
                    PositionY = rnd.Next(0 + 1, height - 1)
                };

                people.Add(thief);
                people.Add(citizen);
                people.Add(police);

            }




            return people;


        }

    }
    class Thief : Person
    {

    }
    class Citizen : Person
    {

    }
    class Police : Person
    {

    }
}