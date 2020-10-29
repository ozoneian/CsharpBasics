using System;
using System.Collections.Generic;
using System.IO;
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
        public string Data { get; set; }
        public string DataPath { get; private set; } = "Boats.txt";
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
            

        }
        public void ReadDockData()
        {
            Data = File.ReadAllText(DataPath);
            string[] split = Data.Split('\n' );


            foreach (var item in split)
            {
                if (item==split[0])
                {
                    string[] counters = item.Split('-');
                    Day = int.Parse(counters[0]);
                    RejectedBoats = int.Parse(counters[1]);
                    AddedBoats = int.Parse(counters[2]);
                }
                else
                {
                    string[] boats = item.Split(',');

                    if (boats[0].ToLower() == "sailboat" && !Array.Exists(Docks, b => b!=null && b.ID == boats[1]))
                    {
                        SailBoat sail = new SailBoat()
                        {
                            ID = boats[1],
                            Weight = int.Parse(boats[2]),
                            MaxSpeed = int.Parse(boats[3]),
                            LengthInFeet = int.Parse(boats[4]),
                            DaysDocked = int.Parse(boats[5])
                        };
                        sail.Docked = true;
                        Array.Fill(Docks, sail, Counter, sail.Slots);
                        Boats.Add(sail);
                    }
                    if (boats[0].ToLower() == "rowingboat" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
                    {
                        RowingBoat row = new RowingBoat()
                        {
                            ID = boats[1],
                            Weight = int.Parse(boats[2]),
                            MaxSpeed = int.Parse(boats[3]),
                            MaxPassenger = int.Parse(boats[4]),
                            DaysDocked = int.Parse(boats[5])
                        };
                        row.Docked = true;

                        Array.Fill(Docks, row, Counter, row.Slots);
                        Boats.Add(row);
                    }
                    if (boats[0].ToLower() == "powerboat" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
                    {
                        PowerBoat power = new PowerBoat()
                        {
                            ID = boats[1],
                            Weight = int.Parse(boats[2]),
                            MaxSpeed = int.Parse(boats[3]),
                            NumberOfHorsepower = int.Parse(boats[4]),
                            DaysDocked = int.Parse(boats[5])
                        };
                        power.Docked = true;

                        Array.Fill(Docks, power, Counter, power.Slots);
                        Boats.Add(power);
                    }
                    if (boats[0].ToLower() == "catamaran" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
                    {
                        Catamaran catamaran = new Catamaran()
                        {
                            ID = boats[1],
                            Weight = int.Parse(boats[2]),
                            MaxSpeed = int.Parse(boats[3]),
                            Beds = int.Parse(boats[4]),
                            DaysDocked = int.Parse(boats[5])
                        };
                        catamaran.Docked = true;

                        Array.Fill(Docks, catamaran, Counter, catamaran.Slots);
                        Boats.Add(catamaran);
                    }
                    if (boats[0].ToLower() == "cargoship" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
                    {
                        CargoShip cargo = new CargoShip()
                        {
                            ID = boats[1],
                            Weight = int.Parse(boats[2]),
                            MaxSpeed = int.Parse(boats[3]),
                            CargoContainers = int.Parse(boats[4]),
                            DaysDocked = int.Parse(boats[5])
                        };
                        cargo.Docked = true;

                        Array.Fill(Docks, cargo, Counter, cargo.Slots);
                        Boats.Add(cargo);
                    }

                    Counter++;

                }
            }
            Counter = 0;
            
        }
        public void WriteDockData()
        {
            File.WriteAllText(DataPath, string.Empty);
            using StreamWriter sw = new StreamWriter(DataPath, true);
            sw.WriteLine($"{Day}-{RejectedBoats}-{AddedBoats}-");
            foreach (var s in Docks)
            {
                if (s==null)
                {
                    sw.WriteLine("null");
                }
                else
                {
                    sw.WriteLine(s.BoatInfo());
                }
            }
            sw.Close();
            Console.ReadKey();
        }
        public void Run()
        {
            ReadDockData();
            Console.WriteLine("Press any key to simulate a day or press 'q' to exit! ");
            ConsoleKeyInfo input;
            input = Console.ReadKey(true);
            File.WriteAllText(DataPath, string.Empty);
            while (input.Key!=ConsoleKey.Q)
            {
                RemoveBoat();
                GenerateBoat(10);
                DisplayDock();
                DisplayInfo();
                input = Console.ReadKey(true);
                NewDay();
                Console.Clear();
            }
            WriteDockData();
            Console.WriteLine("exiting");
            Console.ReadKey(true);
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
            Console.WriteLine();

            int row = Boats
                .OfType<RowingBoat>()
                .Count();
            int pow = Boats
                .OfType<PowerBoat>()
                .Count();
            int sail = Boats
                .OfType<SailBoat>()
                .Count();
            int cata = Boats
                .OfType<Catamaran>()
                .Count();
            int carg = Boats
                .OfType<CargoShip>()
                .Count();

            var weight = Boats
                .GroupBy(b => b.Weight)
                .Sum(b => b.Key);

            var speed = Boats
                .GroupBy(b => b.MaxSpeed)
                .Sum(b => b.Key);

            var emptySlot = Docks
                .Count(b => b == null);

            int speedInKMH = speed / Boats.Count();
            Console.WriteLine("Number of boats: ");
            Console.WriteLine($"Rowingboat: {row}");
            Console.WriteLine($"Powerboat: {pow}");
            Console.WriteLine($"Sailboat: {sail}");
            Console.WriteLine($"Catamaran: {cata}");
            Console.WriteLine($"Cargoship: {carg}");
            Console.WriteLine($"Total weight in dock: {weight} kg");
            Console.WriteLine($"Average maximum speed in dock: {(speedInKMH * 1.85200)} km/h");
            Console.WriteLine($"Empty slots in dock: {emptySlot/2}");
            Console.WriteLine($"Number of total boats added: {AddedBoats}");
            Console.WriteLine($"Number of total boats rejected: {RejectedBoats}");

            
        }
        public void NewDay()
        {
            Counter = 0;
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
