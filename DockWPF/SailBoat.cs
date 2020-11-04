using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DockWPF
{
    class SailBoat : Boat
    {
        static Random Rand { get; set; } = new Random();
        public int LengthInFeet { get; set; }
        public override int Slots { get; set; } = 2 * 2;
        public override SolidColorBrush BoatColor { get; set; } = new SolidColorBrush(Colors.Yellow);


        private int currentDay;

        public int DaysDocked
        {
            get { return currentDay; }
            set
            {
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
            LengthInFeet = Rand.Next(10, 60 + 1);
            Weight = Rand.Next(800, 6000 + 1);
            string temp = ID;
            ID = "S-" + temp;
            MaxSpeed = Rand.Next(0, 12 + 1);
        }
        public override void AddDay()
        {
            DaysDocked++;
        }
        public override string DisplayBoatInfo()
        {
            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Length: {Math.Round(LengthInFeet * 0.3048)} m";
        }
        public override string BoatInfo()
        {
            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{LengthInFeet},{DaysDocked}";

        }
    }
}