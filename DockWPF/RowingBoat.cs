using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DockWPF
{
    class RowingBoat : Boat
    {
        static Random Rand { get; set; } = new Random();
        public override SolidColorBrush BoatColor { get; set; } = new SolidColorBrush(Colors.Blue);

        public int MaxPassenger { get; set; }
        public override int Slots { get; set; } = 1;
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
        }
        public override void AddDay()
        {
            DaysDocked++;
        }
        public override string DisplayBoatInfo()
        {
            return $" {GetType().Name.ToLower()} _ {ID} _ {Weight} _ {Math.Round(MaxSpeed * 1.85200)} _ Max Passenger: {MaxPassenger}";

        }
        public override string BoatInfo()
        {
            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{MaxPassenger},{DaysDocked}";

        }
    }
}
