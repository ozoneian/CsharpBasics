using System;

namespace BusStopWPF
{
    public class Passenger
    {
        public Random Rand { get; set; } = new Random();
        public int GetOn { get; set; }

        public int GetOff { get; set; }

        public Passenger()
        {
            GetOn = Rand.Next(0, 4 + 1);
            bool same = true;
            while (same)
            {
                int temp = Rand.Next(0, 4 + 1);

                if (temp != GetOn)
                {
                    same = false;
                    GetOff = temp;
                }
            }
            
        }
    }
}
