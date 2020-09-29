using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractExample
{
    abstract class Animal
    {
        public abstract void AnimalSound();

        public void Sleep()
        {
            Console.WriteLine("Zzzzzz");
        }
    }
    class Pig : Animal
    {
        public override void AnimalSound()
        {
            Console.WriteLine("Pig Oink oink");
        }
    }
}
