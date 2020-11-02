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
//        public List<Boat> Boats { get; set; } = new List<Boat>(); //beeneficial when I want to manipulate objects/display/sort.
//        public int TempInterval { get; set; }
//        public int RejectedBoats { get; set; }
//        public int AddedBoats { get; set; }
//        public string Data { get; set; }
//        public const string DataPath = "Boats.txt";
//        static void Main(string[] args)
//        {
//            Program p = new Program();
//            p.Run();
//        }
//        public void ReadDockData()
//        {
//            Data = File.ReadAllText(DataPath);

//            if (Data == "")
//            {
//                Console.WriteLine("Harbour hasn't been opened yet...");
//            }
//            else
//            {
//                string[] split = Data.Split('\n');

//                foreach (var item in split)
//                {
//                    if (item == split[0])
//                    {
//                        string[] counters = item.Split('-');
//                        Day = int.Parse(counters[0]);
//                        RejectedBoats = int.Parse(counters[1]);
//                        AddedBoats = int.Parse(counters[2]);
//                    }
//                    else
//                    {
//                        string[] boats = item.Split(',');

//                        if (boats[0].ToLower() == "sailboat" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
//                        {
//                            SailBoat sail = new SailBoat()
//                            {
//                                ID = boats[1],
//                                Weight = int.Parse(boats[2]),
//                                MaxSpeed = int.Parse(boats[3]),
//                                LengthInFeet = int.Parse(boats[4]),
//                                DaysDocked = int.Parse(boats[5])
//                            };
//                            sail.Docked = true;
//                            Array.Fill(Docks, sail, Counter, sail.Slots);
//                            Boats.Add(sail);
//                        }
//                        if (boats[0].ToLower() == "rowingboat" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
//                        {
//                            RowingBoat row = new RowingBoat()
//                            {
//                                ID = boats[1],
//                                Weight = int.Parse(boats[2]),
//                                MaxSpeed = int.Parse(boats[3]),
//                                MaxPassenger = int.Parse(boats[4]),
//                                DaysDocked = int.Parse(boats[5])
//                            };
//                            row.Docked = true;

//                            Array.Fill(Docks, row, Counter, row.Slots);
//                            Boats.Add(row);
//                        }
//                        if (boats[0].ToLower() == "powerboat" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
//                        {
//                            PowerBoat power = new PowerBoat()
//                            {
//                                ID = boats[1],
//                                Weight = int.Parse(boats[2]),
//                                MaxSpeed = int.Parse(boats[3]),
//                                NumberOfHorsepower = int.Parse(boats[4]),
//                                DaysDocked = int.Parse(boats[5])
//                            };
//                            power.Docked = true;

//                            Array.Fill(Docks, power, Counter, power.Slots);
//                            Boats.Add(power);
//                        }
//                        if (boats[0].ToLower() == "catamaran" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
//                        {
//                            Catamaran catamaran = new Catamaran()
//                            {
//                                ID = boats[1],
//                                Weight = int.Parse(boats[2]),
//                                MaxSpeed = int.Parse(boats[3]),
//                                Beds = int.Parse(boats[4]),
//                                DaysDocked = int.Parse(boats[5])
//                            };
//                            catamaran.Docked = true;

//                            Array.Fill(Docks, catamaran, Counter, catamaran.Slots);
//                            Boats.Add(catamaran);
//                        }
//                        if (boats[0].ToLower() == "cargoship" && !Array.Exists(Docks, b => b != null && b.ID == boats[1]))
//                        {
//                            CargoShip cargo = new CargoShip()
//                            {
//                                ID = boats[1],
//                                Weight = int.Parse(boats[2]),
//                                MaxSpeed = int.Parse(boats[3]),
//                                CargoContainers = int.Parse(boats[4]),
//                                DaysDocked = int.Parse(boats[5])
//                            };
//                            cargo.Docked = true;

//                            Array.Fill(Docks, cargo, Counter, cargo.Slots);
//                            Boats.Add(cargo);
//                        }

//                        Counter++;

//                    }
//                }
//                Counter = 0;
//            }
//        }
//        public void WriteDockData()
//        {
//            File.WriteAllText(DataPath, string.Empty);
//            using StreamWriter sw = new StreamWriter(DataPath, true);
//            sw.WriteLine($"{Day}-{RejectedBoats}-{AddedBoats}-");
//            foreach (var s in Docks)
//            {
//                if (s == null)
//                {
//                    sw.WriteLine("null");
//                }
//                else
//                {
//                    sw.WriteLine(s.BoatInfo());
//                }
//            }
//            sw.Close();
//            Console.ReadKey();
//        }
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
//            Counter = 0;
//            Day++;

//            foreach (var boat in Boats)
//            {
//                if (boat != null)
//                {
//                    boat.AddDay();
//                }
//            }
//        }
//        public void RemoveBoat()
//        {
//            int[] result = Docks
//                      .Select((b, i) => b != null && b.Docked == false ? i : -1)
//                      .Where(i => i != -1)
//                      .ToArray();

//            foreach (var item in result)
//            {
//                Docks.SetValue(null, item);
//            }
//            Boats
//                .RemoveAll(b => b != null && b.Docked == false);
//        }

//        public void GenerateBoat(int amount)
//        {
//            for (int boat = 0; boat < amount; boat++)
//            {

//                int avaliableSpace = 0;

//                switch (Rand.Next(1, 5 + 1))
//                {
//                    case 1:
//                        SailBoat s = new SailBoat();


//                        for (int i = 0; i < Docks.Length; i += 2)
//                        {
//                            if (Docks[i] == null)
//                            {
//                                avaliableSpace += 2;
//                                if (avaliableSpace > s.Slots)
//                                {
//                                    TempInterval = i - s.Slots;
//                                    Array.Fill(Docks, s, TempInterval, s.Slots);
//                                    Boats.Add(s);
//                                    s.Docked = true;

//                                    break;
//                                }
//                            }
//                            else
//                            {
//                                avaliableSpace = 0;
//                            }
//                        }
//                        _ = Boats.Contains(s) ? AddedBoats++ : RejectedBoats++;


//                        break;

//                    case 2:
//                        RowingBoat r = new RowingBoat();


//                        for (int i = 0; i < Docks.Length; i++)
//                        {
//                            if (Docks[i] == null)
//                            {

//                                Array.Fill(Docks, r, i, r.Slots);
//                                Boats.Add(r);
//                                r.Docked = true;
//                                break;

//                            }
//                            else
//                            {
//                                avaliableSpace = 0;
//                            }
//                        }
//                        _ = Boats.Contains(r) ? AddedBoats++ : RejectedBoats++;


//                        break;

//                    case 3:
//                        PowerBoat p = new PowerBoat();


//                        for (int i = 0; i < Docks.Length; i += 2)
//                        {
//                            if (Docks[i] == null)
//                            {
//                                avaliableSpace += 2;
//                                if (avaliableSpace > p.Slots)
//                                {
//                                    TempInterval = i - p.Slots;
//                                    Array.Fill(Docks, p, TempInterval, p.Slots);
//                                    Boats.Add(p);
//                                    p.Docked = true;
//                                    break;
//                                }
//                            }
//                            else
//                            {
//                                avaliableSpace = 0;
//                            }
//                        }
//                        _ = Boats.Contains(p) ? AddedBoats++ : RejectedBoats++;


//                        break;

//                    case 4:
//                        Catamaran k = new Catamaran();


//                        for (int i = 0; i < Docks.Length; i += 2)
//                        {
//                            if (Docks[i] == null)
//                            {
//                                avaliableSpace += 2;
//                                if (avaliableSpace > k.Slots)
//                                {
//                                    TempInterval = i - k.Slots;
//                                    Array.Fill(Docks, k, TempInterval, k.Slots);
//                                    Boats.Add(k);
//                                    k.Docked = true;
//                                    break;
//                                }
//                            }
//                            else
//                            {
//                                avaliableSpace = 0;
//                            }
//                        }
//                        _ = Boats.Contains(k) ? AddedBoats++ : RejectedBoats++;


//                        break;

//                    case 5:
//                        CargoShip c = new CargoShip();

//                        for (int i = Docks.Length - 1; i > 0; i -= 2)
//                        {
//                            if (Docks[i] == null)
//                            {
//                                avaliableSpace += 2;
//                                if (avaliableSpace > c.Slots)
//                                {
//                                    TempInterval = i + 1;
//                                    Array.Fill(Docks, c, TempInterval, c.Slots);
//                                    Boats.Add(c);
//                                    c.Docked = true;

//                                    break;
//                                }
//                            }
//                            else
//                            {
//                                avaliableSpace = 0;
//                            }
//                        }
//                        _ = Boats.Contains(c) ? AddedBoats++ : RejectedBoats++;

//                        break;
//                }


//            }
//        }


//    }
//}

//using System;

//namespace HarbourAdmin
//{
//    class SailBoat : Boat
//    {
//        static Random Rand { get; set; } = new Random();
//        public int LengthInFeet { get; set; }
//        public override int Slots { get; set; } = 2 * 2;

//        private int currentDay;

//        public int DaysDocked
//        {
//            get { return currentDay; }
//            set
//            {
//                if (value >= 4)
//                {
//                    Docked = false;
//                }
//                else
//                {
//                    currentDay = value;
//                }
//            }
//        }


//        public SailBoat()
//        {
//            LengthInFeet = Rand.Next(10, 60 + 1);
//            Weight = Rand.Next(800, 6000 + 1);
//            string temp = ID;
//            ID = "S-" + temp;
//            MaxSpeed = Rand.Next(0, 12 + 1);
//        }
//        public override void AddDay()
//        {
//            DaysDocked++;
//        }
//        public override string DisplayBoatInfo()
//        {
//            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Length: {Math.Round(LengthInFeet * 0.3048)} m";
//        }
//        public override string BoatInfo()
//        {
//            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{LengthInFeet},{DaysDocked}";

//        }
//    }
//}
//using System;

//namespace HarbourAdmin
//{
//    class RowingBoat : Boat
//    {
//        static Random Rand { get; set; } = new Random();

//        public int MaxPassenger { get; set; }
//        public override int Slots { get; set; } = 1;
//        private int currentDay;

//        public int DaysDocked
//        {
//            get { return currentDay; }
//            set
//            {
//                if (value >= 1)
//                {
//                    Docked = false;
//                }
//                else
//                {
//                    currentDay = value;
//                }
//            }
//        }
//        public RowingBoat()
//        {
//            string temp = ID;
//            ID = "R-" + temp;

//            Weight = Rand.Next(100, 300 + 1);
//            MaxSpeed = Rand.Next(0, 3 + 1);
//            MaxPassenger = Rand.Next(1, 6 + 1);
//        }
//        public override void AddDay()
//        {
//            DaysDocked++;
//        }
//        public override string DisplayBoatInfo()
//        {
//            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Max passengers: {MaxPassenger}";

//        }
//        public override string BoatInfo()
//        {
//            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{MaxPassenger},{DaysDocked}";

//        }
//    }
//}

//using System;

//namespace HarbourAdmin
//{
//    class PowerBoat : Boat
//    {
//        static Random Rand { get; set; } = new Random();

//        public int NumberOfHorsepower { get; set; }
//        public override int Slots { get; set; } = 1 * 2;

//        private int currentDay;

//        public int DaysDocked
//        {
//            get { return currentDay; }
//            set
//            {
//                if (value >= 3)
//                {
//                    Docked = false;
//                }
//                else
//                {
//                    currentDay = value;
//                }
//            }
//        }
//        public PowerBoat()
//        {
//            string temp = ID;
//            ID = "M-" + temp;
//            Weight = Rand.Next(200, 3000 + 1);
//            MaxSpeed = Rand.Next(0, 60 + 1);
//            NumberOfHorsepower = Rand.Next(10, 1000 + 1);
//        }
//        public override void AddDay()
//        {
//            DaysDocked++;
//        }
//        public override string DisplayBoatInfo()
//        {
//            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Horsepower: {NumberOfHorsepower} hk";


//        }
//        public override string BoatInfo()
//        {
//            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{NumberOfHorsepower},{DaysDocked}";

//        }
//    }
//}

//using System;

//namespace HarbourAdmin
//{
//    class Catamaran : Boat
//    {
//        static Random Rand { get; set; } = new Random();

//        public int Beds { get; set; }
//        public override int Slots { get; set; } = 3 * 2;

//        private int currentDay;

//        public int DaysDocked
//        {
//            get { return currentDay; }
//            set
//            {
//                if (value >= 3)
//                {
//                    Docked = false;
//                }
//                else
//                {
//                    currentDay = value;
//                }
//            }
//        }
//        public Catamaran()
//        {
//            string temp = ID;
//            ID = "K-" + temp;
//            Weight = Rand.Next(1200, 8000 + 1);
//            MaxSpeed = Rand.Next(0, 12 + 1);
//            Beds = Rand.Next(1, 4 + 1);
//        }
//        public override void AddDay()
//        {
//            DaysDocked++;
//        }
//        public override string DisplayBoatInfo()
//        {
//            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Beds: {Beds}";


//        }
//        public override string BoatInfo()
//        {
//            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{Beds},{DaysDocked}";

//        }
//    }
//}

//using System;

//namespace HarbourAdmin
//{
//    class CargoShip : Boat
//    {
//        static Random Rand { get; set; } = new Random();

//        public int CargoContainers { get; set; }
//        public override int Slots { get; set; } = 4 * 2;

//        private int currentDay;

//        public int DaysDocked
//        {
//            get { return currentDay; }
//            set
//            {
//                if (value >= 6)
//                {
//                    Docked = false;
//                }
//                else
//                {
//                    currentDay = value;
//                }
//            }
//        }

//        public CargoShip()
//        {
//            string temp = ID;
//            ID = "L-" + temp;
//            Weight = Rand.Next(3000, 20000 + 1);
//            MaxSpeed = Rand.Next(0, 20 + 1);
//            CargoContainers = Rand.Next(0, 500 + 1);
//        }
//        public override void AddDay()
//        {
//            DaysDocked++;
//        }
//        public override string DisplayBoatInfo()
//        {
//            return $" {GetType().Name.ToLower()} - {ID} - {Weight} kg - {Math.Round(MaxSpeed * 1.85200)} km/h - Containers: {CargoContainers}";


//        }
//        public override string BoatInfo()
//        {
//            return $"{GetType().Name},{ID},{Weight},{MaxSpeed},{CargoContainers},{DaysDocked}";

//        }
//    }
//}

//using System;

//namespace HarbourAdmin
//{
//    class Boat
//    {
//        public bool Docked { get; set; } = false;
//        public virtual int Slots { get; set; }
//        static Random Rand { get; set; } = new Random();
//        public int Weight { get; set; } //kg
//        public int MaxSpeed { get; set; } //knot
//        public string ID { get; set; } = GetRandomID();

//        static string GetRandomID()
//        {
//            char[] Alphabet = new char[]
//            {
//                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
//            };
//            string letters = "";
//            for (int i = 0; i < 3; i++)
//            {
//                letters += Alphabet[Rand.Next(0, Alphabet.Length)].ToString();
//            }


//            return letters;
//        }
//        public virtual void AddDay()
//        {

//        }
//        public virtual string DisplayBoatInfo()
//        {
//            return " ";

//        }
//        public virtual string BoatInfo()
//        {
//            return " ";

//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DockWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewDayButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
