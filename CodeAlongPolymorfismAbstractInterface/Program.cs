using System;
using StandardExempel;

namespace CodeAlongPolymorfismAbstractInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal myAnimal = new StandardExempel.Animal();
            Animal myPig = new StandardExempel.Pig();
            Animal myDog = new Dog();


            myAnimal.AnimalSound();
            myPig.AnimalSound();
            myDog.AnimalSound();

            Console.WriteLine("-----------------------------------------------");

            Animal animal = new StandardExempel.Animal();
            Pig pig = new StandardExempel.Pig();
            StandardExempel.Dog dog = new StandardExempel.Dog();

            animal.AnimalSound();
            pig.AnimalSound();
            dog.AnimalSound();


            Console.WriteLine("-----------------------------------------------");

            PolymorfismExempel.Animal myAnimal2 = new PolymorfismExempel.Animal();
            PolymorfismExempel.Animal myPig2 = new PolymorfismExempel.Pig();
            PolymorfismExempel.Animal myDog2 = new PolymorfismExempel.Dog();


            myAnimal2.AnimalSound();
            myPig2.AnimalSound();
            myDog2.AnimalSound();

            Console.WriteLine("-----------------------------------------------");

            //AbstractExample.Animal animal1 = new AbstractExample.Animal(); //can't make an instance of an abstract class.
            AbstractExample.Pig pig1 = new AbstractExample.Pig(); //but we may create an instance of an abstracts(baseclass) subclass
            pig1.AnimalSound();
            pig1.Sleep(); //can access a method declared in an abstract class. This enables the baseclass to be more secure?

            Console.WriteLine("-----------------------------------------------");

            InterfaceExempel.Dog dog1 = new InterfaceExempel.Dog();
            dog1.AnimalSound();
        }
    }
}
