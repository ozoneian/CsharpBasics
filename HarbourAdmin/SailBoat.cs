using System;

namespace HarbourAdmin
{
    class SailBoat : Boat
    {
        static Random Rand { get; set; } = new Random();
        public int LengthInFeet { get; set; }
        public int DockSlot { get; private set; }
        private int currentDay;

        public int DaysDocked
        {
            get { return currentDay; }
            set {
                if (value >= 4)
                {
                    Docked = false;
                }
                else
                {
                    currentDay = value;
                }
            }
        }


        public SailBoat()
        {
            LengthInFeet = Rand.Next(10,60+1);
            Weight = Rand.Next(800,6000+1);
            string temp = ID;
            ID = "S-" + temp;
            MaxSpeed = Rand.Next(0,12+1);
            DockSlot = 2 * 2;
        }
        public override void AddDay()
        {
            DaysDocked++;
        }
    }
}
