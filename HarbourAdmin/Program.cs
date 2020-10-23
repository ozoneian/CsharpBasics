using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace HarbourAdmin
{
    partial class Program
    {
        static Random Rand { get; set; } = new Random();

        public int Counter { get; set; } = 0;
        public int Day { get; set; } = 0;
        public Boat[] BoatsInBay { get; set; } = new Boat[64*2];
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
                Day++;

                GenerateBoat(5);
                Console.WriteLine("DAY: " + Day);
                foreach (var boat in BoatsInBay)
                {
                    Counter++;
                    if (boat == null)
                    {
                        Console.WriteLine("Båtplats " + Counter + ": empty!");
                    }
                    else
                    {
                        Console.WriteLine($"Båtplats {Counter}: {boat.GetType().Name} ID: {boat.ID} maxspeed: {boat.MaxSpeed} vikt: {boat.Weight}. ");
                    }
                 }
                Counter = 0;

                Console.ReadKey(true);
                Console.Clear();
            }
        //        SailBoat s = new SailBoat();
        //        BoatsInBay.SetValue(s, 0);
        //        BoatsInBay.SetValue(s, 1);
        //        BoatsInBay.SetValue(s, 2);
        //        BoatsInBay.SetValue(s, 3);
        //        s.Docked = true;

        //        RowingBoat r = new RowingBoat();
        //        Array.Fill(BoatsInBay, r, 4, 1);
        //    r.Docked = true;

        //        CargoShip c = new CargoShip();
        //        Array.Fill(BoatsInBay, c, 6, c.DockSlot);
        //    c.Docked = true;
        //        RowingBoat r2 = new RowingBoat();
        //        BoatsInBay.SetValue(r2, Array.FindIndex(BoatsInBay, i => i == null));
        //    r2.Docked = true;

           
              
           // All(i => i != -1)

            //foreach (var item in q)
            //{
            //    Console.WriteLine(item);
            //}

            //int[] numbers = { 0, 30, 20, 15, 90, 85, 40, 75 };

            //IEnumerable<int> query = 
            //    numbers.Where((number, index) => number <= index * 10);

            //foreach (int number in query)
            //{
            //    Console.WriteLine(number);
            //}
            //Console.ReadKey();
            //while (true)
            //{
                

            //    Console.WriteLine($"DAY: {Day}");
            //    for (int i = 0; i < BoatsInBay.Length; i += 2)
            //    {
            //        Counter++;
            //        Console.WriteLine($"Båtplats {Counter}: {BoatsInBay.GetValue(i)} ");
            //    }
            //    Counter = 0;

            //   s.DaysDocked++;
            //    r2.DaysDocked++;
            //    c.DaysDocked++;
            //    r.DaysDocked++;
            //    Day++;

            //    int[] result = BoatsInBay
            //         .Select((b, i) => b != null && b.Docked == false ? i : -1)
            //                  .Where(i => i != -1)
            //                  .ToArray();

            //    foreach (var item in result)
            //    {
            //        BoatsInBay.SetValue(null, item);
            //    }
            }
        
        public void GenerateBoat(int amount)
        {
            for (int j = 0; j < amount; j++)
            {

                int test = 0;

                switch (Rand.Next(1, 5 + 1))
                {
                    case 1:
                        SailBoat s = new SailBoat();


                        for (int i = 0; i < BoatsInBay.Length; i++)
                        {
                            if (BoatsInBay[i] == null)
                            {
                                test++;
                                if (test > s.DockSlot)
                                {
                                    TempInterval = i - s.DockSlot;
                                    Array.Fill(BoatsInBay, s, TempInterval, s.DockSlot);
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


                        for (int i = 0; i < BoatsInBay.Length; i++)
                        {
                            if (BoatsInBay[i] == null)
                            {
                                test++;
                                if (test > r.DockSlot)
                                {
                                    TempInterval = i - r.DockSlot;
                                    Array.Fill(BoatsInBay, r, TempInterval, r.DockSlot);
                                    r.Docked = true;
                                    break;
                                }
                            }
                            else
                            {
                                test = 0;
                            }
                        }

                        break;

                    case 3:
                        PowerBoat p = new PowerBoat();


                        for (int i = 0; i < BoatsInBay.Length; i++)
                        {
                            if (BoatsInBay[i] == null)
                            {
                                test++;
                                if (test > p.DockSlot)
                                {
                                    TempInterval = i - p.DockSlot;
                                    Array.Fill(BoatsInBay, p, TempInterval, p.DockSlot);
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


                        for (int i = 0; i < BoatsInBay.Length; i++)
                        {
                            if (BoatsInBay[i] == null)
                            {
                                test++;
                                if (test > k.DockSlot)
                                {
                                    TempInterval = i - k.DockSlot;
                                    Array.Fill(BoatsInBay, k, TempInterval, k.DockSlot);
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


                        for (int i = 0; i < BoatsInBay.Length; i++)
                        {
                            if (BoatsInBay[i] == null)
                            {
                                test++;
                                if (test > c.DockSlot)
                                {
                                    TempInterval = i - c.DockSlot;
                                    Array.Fill(BoatsInBay, c, TempInterval, c.DockSlot);
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
