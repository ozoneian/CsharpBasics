using System;
using System.Collections.Generic;
using System.Text;

namespace PolymorfismExempel
{
    class Animal
    {
        public virtual void AnimalSound()
        {
            Console.WriteLine("Animal noise");
        }
    }
    class Pig : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Pig Oink oink");
        }
    }
    class Dog : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Dog Woof woof");
        }
    }
}

