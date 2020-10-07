using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ClothingStore
{
    class Program
    {
        public List<Garment> Clothes { get; set; } = new List<Garment>();
        public string[] AdminOptions { get; set; } = new string[] { "Add", "Remove", "Edit", "Exit" };
        public List<Garment> Cart { get; set; } = new List<Garment>();
        public decimal CartTotal { get; set; }
        static void Main(string[] args)
        {
            Program store = new Program();
            store.Run();
            
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                SelectUser();
                Console.ReadKey(true);

            }
        }
        public void SelectUser()
        {
              Console.WriteLine($"Welcome to the store!\nAre you a customer or admin?: ");
                string user = Console.ReadLine().ToLower();
                if (!string.IsNullOrWhiteSpace(user))
                {
                    if (user=="admin")
                        Admin();
                    else if (user=="customer")
                        Customer();
                    else
                        Console.WriteLine("Invalid input..");
                }
        }
        public void Admin()
        {
            Console.Clear();
            switch (AdminMenu())
            {
                case 0:
                    AddItemAdmin();
                    break;
                case 1:
                    RemoveItemAdmin();
                    break;
                case 2:
                    EditItemAdmin();
                    break;
                case 3:
                    Exit();
                    break;
                default:
                    break;
            }
        }
        public int AdminMenu()
        {
            int selected = 0;
            bool done = false;
            Console.WriteLine("Administrator interface\n".ToUpper());
            while (!done)
            {
                for (int i = 0; i < AdminOptions.Length; i++)
                {
                    if (selected == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.WriteLine(AdminOptions[i]);

                    Console.ResetColor();
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        selected = Math.Max(0, selected - 1);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        selected = Math.Min(AdminOptions.Length - 1, selected + 1);
                        break;
                    case ConsoleKey.Enter:
                        done = true;
                        break;
                }

                if (!done)
                    Console.CursorTop = Console.CursorTop - AdminOptions.Length;
            }
            Console.WriteLine($"Selected {AdminOptions[selected]}.");
            return selected;
            

        }
        public void AddItemAdmin()
        {
            if (Clothes.Count<1)
            {
                Console.WriteLine("There are currently no items listed.");
            }
            else
                GetItems();


            Console.WriteLine();
            Console.WriteLine();
            while (true)
            {
                int selected;
                bool success;
                bool pick = true;
                Console.WriteLine("ADD ITEM TO SELL IN STORE: \n");

                Garment garment = new Garment();

                DisplayType();
                Console.WriteLine("Pick garment from list, add by entering it's associated number: ");
                do
                {

                success = Int32.TryParse(Console.ReadLine(), out selected);
                if (success && Enum.IsDefined(typeof(Item), selected))
                {
                        garment.Type = (Item)selected;
                        pick = false; 
                }
                else
                     Console.WriteLine("Invalid input: make sure to enter a number from the list!");
                } while (pick);

                Console.Clear();
                pick = true;
                DisplayColor();
                Console.WriteLine("Pick color from list, add by entering it's associated number: ");
                do
                {
                    success = Int32.TryParse(Console.ReadLine(), out selected);
                    if (success && Enum.IsDefined(typeof(Color), selected))
                    {
                        garment.Color = (Color)selected;
                        pick = false;
                    }
                    else
                        Console.WriteLine("Invalid input: make sure to enter a number from the list!");
                } while (pick);

                Console.Clear();
                pick = true;
                DisplaySize();
                Console.WriteLine("Pick size from list, add by entering it's associated number: ");
                do
                {

                    success = Int32.TryParse(Console.ReadLine(), out selected);
                    if (success && Enum.IsDefined(typeof(Size), selected))
                    {
                        garment.Size = (Size)selected;
                        pick = false;
                    }
                    else
                        Console.WriteLine("Invalid input: make sure to enter a number from the list!");
                } while (pick);

                Console.Clear();
                pick = true;
                DisplaySeason();
                Console.WriteLine("Pick season from list, add by entering it's associated number: ");
                do
                {
                    success = Int32.TryParse(Console.ReadLine(), out selected);
                    if (success && Enum.IsDefined(typeof(Collection), selected))
                    {
                        garment.Season = (Collection)selected;
                        pick = false;
                    }
                    else
                        Console.WriteLine("Invalid input: make sure to enter a number from the list!");
                } while (pick);

                pick = true;
                do
                {
                    Console.WriteLine($"Enter the price of {garment.Type} (in £): ");

                    try
                    {
                        decimal input = decimal.Parse(Console.ReadLine());
                        if (input>0)
                        {
                            garment.Price = input;
                            pick = false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                } while (pick);

                Console.WriteLine($"Adding..{garment.Type} with the color: {garment.Color}, in size: {garment.Size}, with the price: {garment.Price} £... to the store.");
                Clothes.Add(garment);
                break; //add one item at a time for simplification purposes
            }
        }
        public void RemoveItemAdmin()
        {
            Console.WriteLine("remove");
            if (Clothes.Count < 1)
            {
                Console.WriteLine("There are currently no items listed.");
            }
            else
                GetItems();
        }
        public void EditItemAdmin()
        {
            Console.WriteLine("edit");
            if (Clothes.Count < 1)
            {
                Console.WriteLine("There are currently no items listed.");
            }
            else
                GetItems();
        }
        public void DisplayType()
        {
            Console.WriteLine("No: | Type:");
            foreach (int i in Enum.GetValues(typeof(Item)))
            {
                Console.WriteLine($"[{i}] | {Enum.GetName(typeof(Item), i)}");
            }
        }
        public void DisplaySize()
        {
            Console.WriteLine("No: | Size:");
            foreach (int i in Enum.GetValues(typeof(Size)))
            {

                Console.WriteLine($"[{i}] | {Enum.GetName(typeof(Size), i)}");
            }
        }
        public void DisplayColor()
        {
            Console.WriteLine("No: | Color:");
            foreach (int i in Enum.GetValues(typeof(Color)))
            {
                Console.WriteLine($"[{i}] | {Enum.GetName(typeof(Color), i)}");
            }
        }
        public void DisplaySeason()
        {
            Console.WriteLine("No: | Collection:");
            foreach (int i in Enum.GetValues(typeof(Collection)))
            {
                Console.WriteLine($"[{i}] | {Enum.GetName(typeof(Collection), i)}");
            }
        }

        public void Exit()
        {
            Console.WriteLine("exiting..");
        }
        public void Customer()
        {
            Console.Clear();
            int addCart;
            Console.WriteLine($"Cart: {(Cart.Count>0? $" {Cart.Count} items with the total price of {CartTotal} £." : "is empty.")} \n");
            addCart = StoreInventory();
            if (addCart>-1)
            {
                Cart.Add(Clothes[addCart]);
                CartTotal += Clothes[addCart].Price;
            }
            Console.ReadKey();
        }
        public int StoreInventory()
        {
                int selected = 0;
                bool done = false;
                Console.WriteLine("Store Inventory\n".ToUpper());
            if (Clothes.Count>0)
            {
                Console.WriteLine("Press 'enter' to add item to cart!");
                while (!done)
                {
                    for (int i = 0; i < Clothes.Count; i++)
                    {
                        if (selected == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("> ");
                        }
                        else
                        {
                            Console.Write("  ");
                        }

                        Console.WriteLine($"{Clothes[i].Type}: color {Clothes[i].Color}, size {Clothes[i].Size}, price {Clothes[i].Price}£.".ToUpper());

                        Console.ResetColor();
                    }

                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.W:
                        case ConsoleKey.UpArrow:
                            selected = Math.Max(0, selected - 1);
                            break;
                        case ConsoleKey.S:
                        case ConsoleKey.DownArrow:
                            selected = Math.Min(Clothes.Count - 1, selected + 1);
                            break;
                        case ConsoleKey.Enter:
                            done = true;
                            break;
                    }

                    if (!done)
                        Console.CursorTop = Console.CursorTop - Clothes.Count;
                }
                Console.WriteLine($"Selected: {Clothes[selected].Type} is added to cart!.");

            }
            else
            {
                Console.WriteLine("Store is empty.. contact administrator for further assistance!");
                selected = -1;
            }

            return selected;

        }
        public void GetItems()
        {
            Console.WriteLine("ITEMS IN STORE: \n");
            foreach (Garment item in Clothes)
            {
                Console.WriteLine($"{item.Type}: color {item.Color}, size {item.Size}, price {item.Price}£.".ToUpper());
            }
        }
    }
}

