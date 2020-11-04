using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DockWPF
{
    class PowerBoat : Boat
    {
        static Random Rand { get; set; } = new Random();

        public int NumberOfHorsepower { get; set; }
        public override int Slots { get; set; } = 1 * 2;
        public override SolidColorBrush BoatColor { get; set; } = new SolidColorBrush(Colors.Green);


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
        public PowerBoat()
        {
            string temp = ID;
            ID = "M-" + temp;
            Weight = Rand.Next(200, 3000 + 1);
            MaxSpeed = Rand.Next(0, 60 + 1);
            NumberOfHorsepower = Rand.Next(10, 1000 + 1);
        }
        public override void AddDay()
        {
            DaysDocked++;
        }
        public override string DisplayBoatInfo()
        {
            return $" {GetType().Name.ToLower()} _ {ID} _ {Weight} _ {Math.Round(MaxSpeed * 1.85200)} _ Horsepower: {NumberOfHorsepower} hk";


        }
        public override string BoatInfo()
        {
            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{NumberOfHorsepower},{DaysDocked}";

        }
    }
}
