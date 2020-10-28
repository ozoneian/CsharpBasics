using System;

namespace HarbourAdmin
{
    class CargoShip : Boat
    {
        static Random Rand { get; set; } = new Random();

        public int CargoContainers { get; set; }
        public override int Slots { get; set; } = 4*2;

        private int currentDay;

        public int DaysDocked
        {
            get { return currentDay; }
            set
            {
                if (value >= 6)
                {
                    Docked = false;
                }
                else
                {
                    currentDay = value;
                }
            }
        }

        public CargoShip()
        {
            string temp = ID;
            ID = "L-" + temp;
            Weight = Rand.Next(3000, 20000 + 1);
            MaxSpeed = Rand.Next(0, 20 + 1);
            CargoContainers = Rand.Next(0, 500 + 1);
        }
        public override void AddDay()
        {
            DaysDocked++;
        }
        public override string DisplayBoatInfo()
        {
            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Containers: {CargoContainers}";


        }
        public override string BoatInfo()
        {
            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{CargoContainers},{DaysDocked}";

        }
    }
}
