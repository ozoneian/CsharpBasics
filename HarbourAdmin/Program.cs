using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace HarbourAdmin
{
    partial class Program
    {
        static Random Rand { get; set; } = new Random();

        public int Counter { get; set; } = 0;
        public int Day { get; set; } = 1;
        public Boat[] Docks { get; set; } = new Boat[64*2];
        public int TempInterval { get; set; }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();

        }
        public void Run()
        {
            while (true)
            {
                
                GenerateBoat(10);
                Console.WriteLine("DAY: " + Day);
                foreach (var boat in Docks)
                {
                    if (boat == null)
                    {
                        Console.WriteLine("Båtplats " + Counter + ": empty!");
                    }
                    else
                    {
                        Console.WriteLine($"Båtplats {Counter}: {boat.GetType().Name} ID: {boat.ID} maxspeed: {boat.MaxSpeed} vikt: {boat.Weight}. ");
                    }
                    Counter++;

                }
                Counter = 0;

                DisplayHarbour();
                NewDay();

                Console.ReadKey(true);
                Console.Clear();
                RemoveBoat();

            }
        }
        public void DisplayHarbour()
        {
            var boatsInDock = Docks
                .Where(b => b != null)
                .GroupBy(b => b.ID)
                .Count();

            Console.WriteLine(boatsInDock);


            Console.ReadKey(true);
        }
        public void NewDay()
        {
            Day++;

          

            foreach (var boat in Docks)
            {
                if (boat!=null)
                {
                    boat.AddDay(); //adds one day per object references very bad.. but logical ofc
                }
            }
        }
        public void RemoveBoat()
        {
            int[] result = Docks
                      .Select((b, i) => b != null && b.Docked == false ? i : -1)
                      .Where(i => i != -1)
                      .ToArray();

                foreach (var item in result)
                {
                    Docks.SetValue(null, item);
                }
        }

        public void GenerateBoat(int amount)
        {
            for (int boat = 0; boat < amount; boat++)
            {

                int test = 0;

                switch (Rand.Next(1, 5 + 1))
                {
                    case 1:
                        SailBoat s = new SailBoat();


                        for (int i = 0; i < Docks.Length; i+=2)
                        {
                            if (Docks[i] == null)
                            {
                                test+=2;
                                if (test > s.DockSlot)
                                {
                                    TempInterval = i - s.DockSlot;
                                    Array.Fill(Docks, s, TempInterval, s.DockSlot);
                                    s.Docked = true;

                                    break;
                                }
                            }
                            else
                            {
                                test = 0;
                            }
                        }


                        break;

                    case 2:
                        RowingBoat r = new RowingBoat();


                        for (int i = 0; i < Docks.Length; i++)
                        {
                            if (Docks[i] == null)
                            {
                                
                                    Array.Fill(Docks, r, i, r.DockSlot);
                                    r.Docked = true;
                                    break;
                                
                            }
                            else
                            {
                                test = 0;
                            }
                        }

                        break;

                    case 3:
                        PowerBoat p = new PowerBoat();


                        for (int i = 0; i < Docks.Length; i+=2)
                        {
                            if (Docks[i] == null)
                            {
                                test+=2;
                                if (test > p.DockSlot)
                                {
                                    TempInterval = i - p.DockSlot;
                                    Array.Fill(Docks, p, TempInterval, p.DockSlot);
                                    p.Docked = true;
                                    break;
                                }
                            }
                            else
                            {
                                test = 0;
                            }
                        }

                        break;

                    case 4:
                        Catamaran k = new Catamaran();


                        for (int i = 0; i < Docks.Length; i+=2)
                        {
                            if (Docks[i] == null)
                            {
                                test+=2;
                                if (test > k.DockSlot)
                                {
                                    TempInterval = i - k.DockSlot;
                                    Array.Fill(Docks, k, TempInterval, k.DockSlot);
                                    k.Docked = true;
                                    break;
                                }
                            }
                            else
                            {
                                test = 0;
                            }
                        }

                        break;

                    case 5:
                        CargoShip c = new CargoShip();

                        for (int i = Docks.Length -1; i > 0; i-=2)
                        {
                            if (Docks[i] == null)
                            {
                                test+=2;
                                if (test > c.DockSlot)
                                {
                                    TempInterval = i+1;
                                    Array.Fill(Docks, c, TempInterval, c.DockSlot);
                                    c.Docked = true;

                                    break;
                                }
                            }
                            else
                            {
                                test = 0;
                            }
                        }
                        break;
                }


            }
        }
       
      
    }
}
