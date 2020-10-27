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
        public List<Boat> Boats { get; set; } = new List<Boat>(); //beeneficial when I want to manipulate objects/display/sort.
        public int TempInterval { get; set; }
        public int RejectedBoats { get; set; }
        public int AddedBoats { get; set; }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();

        }
        public void Run()
        {
            while (true)
            {
                RemoveBoat();
                GenerateBoat(10);
                DisplayDock();
                DisplayInfo();
                Console.ReadKey(true);
                NewDay();
                Console.Clear();
            }
        }

        private void DisplayDock()
        {
            Console.WriteLine("DAY: " + Day);
            int empty = 0;
            Console.WriteLine("Plats   Båttyp   ID-Nr   Vikt   Maxhastighet   Övrigt");
            foreach (var boat in Docks)
            {
                if (boat == null)
                {
                    empty++;

                }
                else
                {
                    if (empty > 0)
                    {
                        Console.WriteLine($"{(Counter - empty) / 2}-{Counter / 2}: empty"); //fullösning
                        empty = 0;
                    }
                    if (boat != Docks[Counter > 0 ? Counter - 1 : Counter] || boat == Docks[0] && Counter == 0)
                    {

                        string info = boat.DisplayBoatInfo();
                        Console.WriteLine($"{(Counter) / 2}-{(Counter + boat.Slots) / 2} {info}");

                    }
                }
                Counter++;

            }
            if (empty > 0)
            {
                Console.WriteLine($"{(Counter - empty) / 2}-{Counter / 2}: empty"); //en till fullösning
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Additional dock info: ");
            Console.WriteLine($"Number of boats currently in dock: {AddedBoats}.");
            Console.WriteLine($"Number of boats rejected (day: {Day}): {RejectedBoats}");
        }
        public void NewDay()
        {
            Counter = 0;
            RejectedBoats = 0;
            AddedBoats = 0;
            Day++;

            foreach (var boat in Boats)
            {
                if (boat != null)
                {
                    boat.AddDay();
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
            Boats
                .RemoveAll(b => b!=null && b.Docked == false);
        }

        public void GenerateBoat(int amount)
        {
            for (int boat = 0; boat < amount; boat++)
            {

                int avaliableSpace = 0;

                switch (Rand.Next(1, 5 + 1))
                {
                    case 1:
                        SailBoat s = new SailBoat();


                        for (int i = 0; i < Docks.Length; i+=2)
                        {
                            if (Docks[i] == null)
                            {
                                avaliableSpace+=2;
                                if (avaliableSpace > s.Slots)
                                {
                                    TempInterval = i - s.Slots;
                                    Array.Fill(Docks, s, TempInterval, s.Slots);
                                    Boats.Add(s);
                                    s.Docked = true;

                                    break;
                                }
                            }
                            else
                            {
                                avaliableSpace = 0;
                            }
                        }
                        _ = Boats.Contains(s) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 2:
                        RowingBoat r = new RowingBoat();


                        for (int i = 0; i < Docks.Length; i++)
                        {
                            if (Docks[i] == null)
                            {
                                
                                    Array.Fill(Docks, r, i, r.Slots);
                                    Boats.Add(r);
                                    r.Docked = true;
                                    break;
                                
                            }
                            else
                            {
                                avaliableSpace = 0;
                            }
                        }
                        _ = Boats.Contains(r) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 3:
                        PowerBoat p = new PowerBoat();


                        for (int i = 0; i < Docks.Length; i+=2)
                        {
                            if (Docks[i] == null)
                            {
                                avaliableSpace+=2;
                                if (avaliableSpace > p.Slots)
                                {
                                    TempInterval = i - p.Slots;
                                    Array.Fill(Docks, p, TempInterval, p.Slots);
                                    Boats.Add(p);
                                    p.Docked = true;
                                    break;
                                }
                            }
                            else
                            {
                                avaliableSpace = 0;
                            }
                        }
                        _ = Boats.Contains(p) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 4:
                        Catamaran k = new Catamaran();


                        for (int i = 0; i < Docks.Length; i+=2)
                        {
                            if (Docks[i] == null)
                            {
                                avaliableSpace+=2;
                                if (avaliableSpace > k.Slots)
                                {
                                    TempInterval = i - k.Slots;
                                    Array.Fill(Docks, k, TempInterval, k.Slots);
                                    Boats.Add(k);
                                    k.Docked = true;
                                    break;
                                }
                            }
                            else
                            {
                                avaliableSpace = 0;
                            }
                        }
                        _ = Boats.Contains(k) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 5:
                        CargoShip c = new CargoShip();

                        for (int i = Docks.Length -1; i > 0; i-=2)
                        {
                            if (Docks[i] == null)
                            {
                                avaliableSpace+=2;
                                if (avaliableSpace > c.Slots)
                                {
                                    TempInterval = i+1;
                                    Array.Fill(Docks, c, TempInterval, c.Slots);
                                    Boats.Add(c);
                                    c.Docked = true;

                                    break;
                                }
                            }
                            else
                            {
                                avaliableSpace = 0;
                            }
                        }
                        _ = Boats.Contains(c) ? AddedBoats++ : RejectedBoats++;

                        break;
                }


            }
        }
       
      
    }
}
