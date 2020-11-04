using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DockWPF
{
    class Catamaran : Boat
    {
        static Random Rand { get; set; } = new Random();
        public override SolidColorBrush BoatColor { get; set; } = new SolidColorBrush(Colors.Pink);

        public int Beds { get; set; }
        public override int Slots { get; set; } = 3 * 2;

        private int currentDay;

        public int DaysDocked
        {
            get { return currentDay; }
            set
            {
                if (value >= 3)
                {
                    Docked = false;
                }
                else
                {
                    currentDay = value;
                }
            }
        }
        public Catamaran()
        {
            string temp = ID;
            ID = "K-" + temp;
            Weight = Rand.Next(1200, 8000 + 1);
            MaxSpeed = Rand.Next(0, 12 + 1);
            Beds = Rand.Next(1, 4 + 1);
        }
        public override void AddDay()
        {
            DaysDocked++;
        }
        public override string DisplayBoatInfo()
        {
            return $" {GetType().Name.ToLower()} _ {ID} _ {Weight} _ {Math.Round(MaxSpeed * 1.85200)} _ Beds: {Beds}";


        }
        public override string BoatInfo()
        {
            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{Beds},{DaysDocked}";

        }
    }
}
