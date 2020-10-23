using System;

namespace HarbourAdmin
{
    class RowingBoat : Boat
    {
        static Random Rand { get; set; } = new Random();

        public int MaxPassenger { get; set; }
        public int DockSlot { get; private set; }
        private int currentDay;

        public int DaysDocked
        {
            get { return currentDay; }
            set
            {
                if (value >= 1)
                {
                    Docked = false;
                }
                else
                {
                    currentDay = value;
                }
            }
        }
        public RowingBoat()
        {
            string temp = ID;
            ID = "R-" + temp;

            Weight = Rand.Next(100, 300 + 1);
            MaxSpeed = Rand.Next(0, 3 + 1);
            MaxPassenger = Rand.Next(1, 6 + 1);
            DockSlot = 1; //0,5*2
        }
    }
}
