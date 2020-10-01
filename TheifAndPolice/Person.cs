using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheifAndPolice
{
    public class Person
    {
        public Random Rand { get; } = new Random();
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Direction { get; set; }
        public virtual char Symbol { get; set; }
        public List<Item> Inventory { get; set; }
        public bool InPrison { get; set; }


        public Person()
        {
            int direction = Rand.Next(1, 8 + 1); //hopefully a random int(created when object is) between 1,8 that will permanetly decide which switch case to be used for movement.
            Direction = direction;

        }

        public void Move(int height, int width) //rand direction int(1-8) determines the objects direction and movement forever.
        {
            switch (Direction)
            {
                case 1:
                    PositionX--;
                    PositionY--;
                    if (PositionX < 1)
                    {
                        PositionX = width - 1;
                    }
                    if (PositionY < 1)
                    {
                        PositionY = height - 1;
                    }
                    break;
                case 2:

                    PositionX++;
                    PositionY++;
                    if (PositionX > width-1)
                    {
                        PositionX = 1;
                    }
                    if (PositionY > height-1)
                    {
                        PositionY = 1;
                    }
                    break;
                case 3:
                    PositionX--;
                    PositionY++;
                    if (PositionX < 1)
                    {
                        PositionX = width - 1;
                    }
                    if (PositionY > height-1)
                    {
                        PositionY = 1;
                    }
                    break;
                case 4:
                    PositionX++;
                    PositionY--;
                    if (PositionX > width-1)
                    {
                        PositionX = 1;
                    }
                    if (PositionY < 1)
                    {
                        PositionY = height - 1;
                    }
                    break;
                case 5:
                    PositionX--;
                    if (PositionX < 1)
                    {
                        PositionX = width - 1;
                    }
                    break;
                case 6:
                    PositionY--;
                    if (PositionY < 1)
                    {
                        PositionY = height - 1;
                    }
                    break;
                case 7:
                    PositionX++;
                    if (PositionX > width-1)
                    {
                        PositionX = 1;
                    }
                    break;
                case 8:
                    PositionY++;
                    if (PositionY > height- 1)
                    {
                        PositionY = 1;
                    }
                    break;

            }
        }
        public static List<Person> CreatePeople(int height, int width)
        {
            int numberOfPeople = 2; //just a random number added for simplification conmtrols the amount of citizen,police,thieves where the amount of each type is equal.
            Random rnd = new Random();
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                Thief thief = new Thief
                {
                    PositionX = rnd.Next(0 + 1, width - 1), //rand initial position
                    PositionY = rnd.Next(0 + 1, height - 1),
                    Inventory = new List<Item>(),
                    InPrison = false

                };
                people.Add(thief);
                
                Citizen citizen = new Citizen
                {

                    PositionX = rnd.Next(0 + 1, width - 1),
                    PositionY = rnd.Next(0 + 1, height - 1),
                    Inventory = new List<Item>()
                    
                    {
                        Item.Phone,
                        Item.Watch,
                        Item.Money,
                        Item.Keys,
                    }
             
                };
                people.Add(citizen);
                
                Police police = new Police
                {
                    PositionX = rnd.Next(0 + 1, width - 1),
                    PositionY = rnd.Next(0 + 1, height - 1),
                    Inventory = new List<Item>()

                };
                //no cond that prevents objects to generate with the same x,ycoord
                people.Add(police);

            }
                 return people;


        }
    
    }
    public class Thief : Person
    {
        public override char Symbol { get; set; } = 'T';
    }
    class Citizen : Person
    {
        public override char Symbol { get; set; } = 'C';

    }
    class Police : Person
    {
        public override char Symbol { get; set; } = 'P';

    }
}