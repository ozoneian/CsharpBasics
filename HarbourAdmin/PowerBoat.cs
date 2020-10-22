using System;

namespace HarbourAdmin
{
    class PowerBoat : Boat
    {
        static Random Rand { get; set; } = new Random();

        public int NumberOfHorsepower { get; set; }
        public int DockSlot { get; private set; }
        private int currentDay;

        public int DaysDocked
        {
            get { return currentDay; }
            set
            {
                if (value > 3)
                {
                    Docked = false;
                }
                else
                {
                    currentDay = value;
                }
            }
        }
        public PowerBoat()
        {
            string temp = ID;
            ID = "M-" + temp;
            Weight = Rand.Next(200, 3000 + 1);
            MaxSpeed = Rand.Next(0, 60 + 1);
            NumberOfHorsepower = Rand.Next(10, 1000 + 1);
            DockSlot = 1 * 2;
        }
    }
}
