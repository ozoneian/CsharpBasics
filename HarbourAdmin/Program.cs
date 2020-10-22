using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HarbourAdmin
{
    class Program
    {
        public int Counter { get; set; } = 0;
        public Boat[] BoatsInBay { get; set; } = new Boat[64*2];
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();

        }
        public void Run()
        {
            SailBoat s = new SailBoat();
            BoatsInBay.SetValue(s, 0);
            BoatsInBay.SetValue(s, 1);
            BoatsInBay.SetValue(s, 2);
            BoatsInBay.SetValue(s, 3);

            RowingBoat r = new RowingBoat();
            Array.Fill(BoatsInBay, r, 4, 1);

            CargoShip c = new CargoShip();
            Array.Fill(BoatsInBay, c, 6, c.DockSlot);

            RowingBoat r2 = new RowingBoat();

            BoatsInBay.SetValue(r2, Array.FindIndex(BoatsInBay, i => i == null));


            for (int i = 0; i < BoatsInBay.Length; i+=2)
            {
                Counter++;
                Console.WriteLine($"Båtplats {Counter}: {BoatsInBay.GetValue(i)} ");
            }
            Console.ReadKey(true);

            int[] result = BoatsInBay
                 .Select((b, i) => b!=null && b.Docked==false? i : -1)
                          .Where(x => x != -1)
                          .ToArray();

            foreach (var item in result)
            {
                Console.WriteLine(item);
                BoatsInBay.SetValue(null, item);
            }
            Console.ReadKey(true);
        }
    }
}
