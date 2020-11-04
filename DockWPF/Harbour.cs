using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DockWPF
{
    class Harbour
    {
        public Random Rand { get; set; } = new Random();
        public Boat[] DockOne { get; set; } = new Boat[32 * 2];
        public Boat[] DockTwo { get; set; } = new Boat[32 * 2];
        public int Day { get; set; } = 1;
        public int Counter { get; set; } = 0;
        public List<Boat> Boats { get; set; } = new List<Boat>(); //beeneficial when I want to manipulate objects/display/sort.
        public int RejectedBoats { get; set; }
        public int AddedBoats { get; set; }
        public const string DataPath = "BoatsInHarbour.txt";

        public void RunHarbour()
        {
           

            //using System;
            //using System.Collections.Generic;
            //using System.IO;
            //using System.Linq;
            //using System.Runtime.CompilerServices;
            //using System.Security.Cryptography;
            //using System.Security.Cryptography.X509Certificates;

            //namespace HarbourAdmin
            //{
            //    partial class Program
            //    {
            //        static Random Rand { get; set; } = new Random();

            //        public int Counter { get; set; } = 0;
            //        public int Day { get; set; } = 1;
            //        public Boat[] Docks { get; set; } = new Boat[64 * 2];

            //        static void Main(string[] args)
            //        {
            //            Program p = new Program();
            //            p.Run();
            //        }

            //        }
            //       
            //        public void Run()
            //        {
            //            ReadDockData();
            //            Console.WriteLine("Press any key to simulate a day, press 'c' to clear harbour or press 'q' to exit! ");
            //            ConsoleKeyInfo input;
            //            input = Console.ReadKey(true);
            //            if (input.Key != ConsoleKey.C)
            //            {
            //                File.WriteAllText(DataPath, string.Empty);

            //            }
            //            while (input.Key != ConsoleKey.Q)
            //            {
            //                RemoveBoat();
            //                GenerateBoat(10);
            //                DisplayDock();
            //                DisplayInfo();
            //                input = Console.ReadKey(true);
            //                NewDay();
            //                Console.Clear();
            //            }
            //            WriteDockData();
            //            Console.WriteLine("exiting");
            //            Console.ReadKey(true);
            //        }

            //        private void DisplayDock()
            //        {
            //            Console.WriteLine("DAY: " + Day);
            //            int empty = 0;
            //            Console.WriteLine("Plats   Båttyp   ID-Nr   Vikt   Maxhastighet   Övrigt");
            //            foreach (var boat in Docks)
            //            {
            //                if (boat == null)
            //                {
            //                    empty++;

            //                }
            //                else
            //                {
            //                    if (empty > 0)
            //                    {
            //                        Console.WriteLine($"{(Counter - empty) / 2}-{Counter / 2}: empty"); //fullösning
            //                        empty = 0;
            //                    }
            //                    if (boat != Docks[Counter > 0 ? Counter - 1 : Counter] || boat == Docks[0] && Counter == 0)
            //                    {

            //                        string info = boat.DisplayBoatInfo();
            //                        Console.WriteLine($"{(Counter) / 2}-{(Counter + boat.Slots) / 2} {info}");

            //                    }
            //                }
            //                Counter++;

            //            }
            //            if (empty > 0)
            //            {
            //                Console.WriteLine($"{(Counter - empty) / 2}-{Counter / 2}: empty"); //en till fullösning
            //            }
            //        }

            //        public void DisplayInfo()
            //        {
            //            Console.WriteLine("Additional dock info: ");
            //            Console.WriteLine();

            //            int row = Boats
            //                .OfType<RowingBoat>()
            //                .Count();
            //            int pow = Boats
            //                .OfType<PowerBoat>()
            //                .Count();
            //            int sail = Boats
            //                .OfType<SailBoat>()
            //                .Count();
            //            int cata = Boats
            //                .OfType<Catamaran>()
            //                .Count();
            //            int carg = Boats
            //                .OfType<CargoShip>()
            //                .Count();

            //            var weight = Boats
            //                .GroupBy(b => b.Weight)
            //                .Sum(b => b.Key);

            //            var speed = Boats
            //                .GroupBy(b => b.MaxSpeed)
            //                .Sum(b => b.Key);

            //            var emptySlot = Docks
            //                .Count(b => b == null);

            //            int speedInKMH = speed / Boats.Count();
            //            Console.WriteLine("Number of boats: ");
            //            Console.WriteLine($"Rowingboat: {row}");
            //            Console.WriteLine($"Powerboat: {pow}");
            //            Console.WriteLine($"Sailboat: {sail}");
            //            Console.WriteLine($"Catamaran: {cata}");
            //            Console.WriteLine($"Cargoship: {carg}");
            //            Console.WriteLine($"Total weight in dock: {weight} kg");
            //            Console.WriteLine($"Average maximum speed in dock: {(speedInKMH * 1.85200)} km/h");
            //            Console.WriteLine($"Empty slots in dock: {emptySlot / 2}");
            //            Console.WriteLine($"Number of total boats added: {AddedBoats}");
            //            Console.WriteLine($"Number of total boats rejected: {RejectedBoats}");


            //        }
            //        public void NewDay()
            //        {
            //        }
            




            //    }
            //}
        }
        public void UpdateHarbour() //per/day
        {

            Counter = 0;
            Day++;

            foreach (var boat in Boats)
            {
                boat.AddDay();
            }
        }
        public void RemoveBoat()
        {
            int[] resultDockOne = DockOne
                      .Select((b, i) => b != null && b.Docked == false ? i : -1)
                      .Where(i => i != -1)
                      .ToArray();
            int[] resultDockTwo = DockTwo
                      .Select((b, i) => b != null && b.Docked == false ? i : -1)
                      .Where(i => i != -1)
                      .ToArray();

            foreach (var item in resultDockOne)
            {
                DockOne.SetValue(null, item);
            }
            foreach (var item in resultDockTwo)
            {
                DockTwo.SetValue(null, item);

            }

            Boats
                .RemoveAll(b => b != null && b.Docked == false);
        }
        public void ReadDockData()
        {
            string data = File.ReadAllText(DataPath);

            if (data == "")
            {
                Console.WriteLine("Harbour hasn't been opened yet...");
            }
            else
            {
                string[] dockSplit = data.Split('_');
                string[] dockOne = dockSplit[0].Split('\n' , StringSplitOptions.RemoveEmptyEntries);
                string[] removeShit = dockSplit[1].Split('\n', StringSplitOptions.RemoveEmptyEntries);
                string[] dockTwo = removeShit.Skip(1)
                    .ToArray();

                foreach (var item in dockOne)
                {
                    if (item == dockOne[0])
                    {
                        string[] counters = item.Split('-');
                        Day = int.Parse(counters[0]);
                        RejectedBoats = int.Parse(counters[1]);
                        AddedBoats = int.Parse(counters[2]);
                    }
                    else
                    {
                        string[] boats = item.Split(',');

                        if (boats[0].ToLower() == "sailboat" && !Array.Exists(DockOne, b => b != null && b.ID == boats[1]))
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
                            Array.Fill(DockOne, sail, Counter, sail.Slots);
                            Boats.Add(sail);
                        }
                        if (boats[0].ToLower() == "rowingboat" && !Array.Exists(DockOne, b => b != null && b.ID == boats[1]))
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

                            Array.Fill(DockOne, row, Counter, row.Slots);
                            Boats.Add(row);
                        }
                        if (boats[0].ToLower() == "powerboat" && !Array.Exists(DockOne, b => b != null && b.ID == boats[1]))
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

                            Array.Fill(DockOne, power, Counter, power.Slots);
                            Boats.Add(power);
                        }
                        if (boats[0].ToLower() == "catamaran" && !Array.Exists(DockOne, b => b != null && b.ID == boats[1]))
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

                            Array.Fill(DockOne, catamaran, Counter, catamaran.Slots);
                            Boats.Add(catamaran);
                        }
                        if (boats[0].ToLower() == "cargoship" && !Array.Exists(DockOne, b => b != null && b.ID == boats[1]))
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

                            Array.Fill(DockOne, cargo, Counter, cargo.Slots);
                            Boats.Add(cargo);
                        }

                        Counter++;

                    }
                }
                Counter = 0;
                foreach (var item in dockTwo)
                {
                    string[] boats = item.Split(',');

                    if (boats[0].ToLower() == "sailboat" && !Array.Exists(DockTwo, b => b != null && b.ID == boats[1]))
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
                        Array.Fill(DockTwo, sail, Counter, sail.Slots);
                        Boats.Add(sail);
                    }
                    if (boats[0].ToLower() == "rowingboat" && !Array.Exists(DockTwo, b => b != null && b.ID == boats[1]))
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

                        Array.Fill(DockTwo, row, Counter, row.Slots);
                        Boats.Add(row);
                    }
                    if (boats[0].ToLower() == "powerboat" && !Array.Exists(DockTwo, b => b != null && b.ID == boats[1]))
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

                        Array.Fill(DockTwo, power, Counter, power.Slots);
                        Boats.Add(power);
                    }
                    if (boats[0].ToLower() == "catamaran" && !Array.Exists(DockTwo, b => b != null && b.ID == boats[1]))
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

                        Array.Fill(DockTwo, catamaran, Counter, catamaran.Slots);
                        Boats.Add(catamaran);
                    }
                    if (boats[0].ToLower() == "cargoship" && !Array.Exists(DockTwo, b => b != null && b.ID == boats[1]))
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

                        Array.Fill(DockTwo, cargo, Counter, cargo.Slots);
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
            foreach (var s in DockOne)
            {
                if (s == null)
                {
                    sw.WriteLine("null");
                }
                else
                {
                    sw.WriteLine(s.BoatInfo());
                }
            }
            sw.WriteLine("_");
            foreach (var s in DockTwo)
            {
                if (s == null)
                {
                    sw.WriteLine("null");
                }
                else
                {
                    sw.WriteLine(s.BoatInfo());
                }
            }
            sw.Close();
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


                        for (int i = 0; i < DockTwo.Length; i += 2)
                        {
                            if (DockTwo[i] == null)
                            {
                                avaliableSpace += 2;
                                if (avaliableSpace > s.Slots)
                                {
                                    Array.Fill(DockTwo, s, i - s.Slots, s.Slots);
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
                        avaliableSpace = 0;
                        if (s.Docked==false)
                        {
                            for (int i = 0; i < DockOne.Length; i += 2)
                            {
                                if (DockOne[i] == null)
                                {
                                    avaliableSpace += 2;
                                    if (avaliableSpace > s.Slots)
                                    {
                                        Array.Fill(DockOne, s, i - s.Slots, s.Slots);
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
                        }
                        _ = Boats.Contains(s) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 2:
                        RowingBoat r = new RowingBoat();


                        for (int i = 0; i < DockOne.Length; i++)
                        {
                            if (DockOne[i] == null)
                            {

                                Array.Fill(DockOne, r, i, r.Slots);
                                Boats.Add(r);
                                r.Docked = true;
                                break;

                            }
                            else
                            {
                                avaliableSpace = 0;
                            }
                        }
                        avaliableSpace = 0;
                        if (r.Docked==false)
                        {
                            for (int i = 0; i < DockTwo.Length; i++)
                            {
                                if (DockTwo[i] == null)
                                {

                                    Array.Fill(DockTwo, r, i, r.Slots);
                                    Boats.Add(r);
                                    r.Docked = true;
                                    break;

                                }
                                else
                                {
                                    avaliableSpace = 0;
                                }
                            }
                        }
                        _ = Boats.Contains(r) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 3:
                        PowerBoat p = new PowerBoat();


                        for (int i = 0; i < DockOne.Length; i += 2)
                        {
                            if (DockOne[i] == null)
                            {
                                avaliableSpace += 2;
                                if (avaliableSpace > p.Slots)
                                {
                                    Array.Fill(DockOne, p, i - p.Slots, p.Slots);
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
                        avaliableSpace = 0;
                        if (p.Docked==false)
                        {
                            for (int i = 0; i < DockTwo.Length; i += 2)
                            {
                                if (DockTwo[i] == null)
                                {
                                    avaliableSpace += 2;
                                    if (avaliableSpace > p.Slots)
                                    {
                                        Array.Fill(DockTwo, p, i - p.Slots, p.Slots);
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
                        }
                        _ = Boats.Contains(p) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 4:
                        Catamaran k = new Catamaran();


                        for (int i = 0; i < DockOne.Length; i += 2)
                        {
                            if (DockOne[i] == null)
                            {
                                avaliableSpace += 2;
                                if (avaliableSpace > k.Slots)
                                {
                                    Array.Fill(DockOne, k, i - k.Slots, k.Slots);
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
                        if (k.Docked==false)
                        {
                            avaliableSpace = 0;
                            for (int i = 0; i < DockTwo.Length; i += 2)
                            {
                                if (DockTwo[i] == null)
                                {
                                    avaliableSpace += 2;
                                    if (avaliableSpace > k.Slots)
                                    {
                                        Array.Fill(DockTwo, k, i - k.Slots, k.Slots);
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
                        }
                        _ = Boats.Contains(k) ? AddedBoats++ : RejectedBoats++;


                        break;

                    case 5:
                        CargoShip c = new CargoShip();

                        for (int i = DockTwo.Length - 1; i > 0; i -= 2)
                        {
                            if (DockTwo[i] == null)
                            {
                                avaliableSpace += 2;
                                if (avaliableSpace > c.Slots)
                                {
                                    Array.Fill(DockTwo, c, i +1, c.Slots);
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
                        if (c.Docked==false)
                        {
                            avaliableSpace = 0;
                            for (int i = DockOne.Length - 1; i > 0; i -= 2)
                            {
                                if (DockOne[i] == null)
                                {
                                    avaliableSpace += 2;
                                    if (avaliableSpace > c.Slots)
                                    {
                                        Array.Fill(DockOne, c, i + 1, c.Slots);
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
                        }
                        _ = Boats.Contains(c) ? AddedBoats++ : RejectedBoats++;

                        break;
                }


            }
        }
    }
}
