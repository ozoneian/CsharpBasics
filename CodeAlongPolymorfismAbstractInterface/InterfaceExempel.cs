using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExempel
{
    interface IAnimal

    {
        void AnimalSound();
        //void AnotherMethod(); need to declare the same method in the subclass if used.
    }
    class Dog: IAnimal
    {
        public void AnimalSound()
        {
            Console.WriteLine("Dog Woof woof");
        }
    }
}
