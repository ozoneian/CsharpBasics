using System;
using System.Collections.Generic;
using System.Text;

namespace StandardExempel
{
    class Standard
    {

    }
    class Animal
    {
        public void AnimalSound()
        {
            Console.WriteLine("Animal noise");
        }
    }
    class Pig : Animal
    {
        public void AnimalSound()
        {
            Console.WriteLine("Pig Oink oink");
        }
    }
    class Dog : Animal
    {
        public void AnimalSound()
        {
            Console.WriteLine("Dog Woof woof");
        }
    }
}
