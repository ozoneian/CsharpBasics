using System;
using System.Collections.Generic;
using System.Text;

namespace TheifAndPolice
{
    class Person
    {
        public Random Rand { get; } = new Random();
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Direction { get; set; }
        public List<Item> Inventory { get; set; }

        public Person()
        {
            int direction = Rand.Next(1, 8 + 1);
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

        public void GetPosition()
        {

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
