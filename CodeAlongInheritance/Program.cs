using System;

namespace CodeAlongInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Fact fact = new Fact(120, "Bertil Långben", 45, "Science");
            Console.WriteLine($"{fact.Subject}, {fact.Author}, {fact.Pages}, {fact.Price}£. {fact.GetType().Name}");
        }
    }
}
