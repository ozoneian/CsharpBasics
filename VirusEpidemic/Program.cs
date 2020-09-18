using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace VirusEpidemic
{
    class Program
    {
        static void Main(string[] args)
        {
            RunDisco();
        }
        static void RunDisco()
        {
            int discoOpenedFor = 0;
            bool discoOpen = true;

            Person person = new Person();
            List<Person> people = person.CreatePeople();
            while (discoOpen)
            {
                Console.Clear();
                int counter = 0;

                for (int i = 0; i < people.Count; i++)
                {
                    Console.WriteLine($"Disco has been opened for {discoOpenedFor} h. Infected: {people[i].Infected} , Infected for: {people[i].InfectedWhen} , Immune: {people[i].Immune}");


                    if (people[i].Infected)
                    {
                        SetInfectionDuration(people[i]);
                        counter++;
                    }
                }
                SetInfected(people,counter);
                

                discoOpenedFor++;
                
                Console.ReadKey(true);
            }
        }
        static void SetInfected(List<Person> people, int amount) //Breakpoint can't big iq this
        {
            int temp = 0;

            foreach (var person in people)
            {
                if (person.Infected==false && person.Immune==false && temp<amount)
                {
                    person.Infected = true;
                    temp++;
                }
            }
        }
        static void SetInfectionDuration(Person person)
        {
            if (person.InfectedWhen == 5)
            {
                MakeImmune(person);

            }
            else if (person.InfectedWhen<5)
            {
                person.InfectedWhen++;
            }
            
        }
        static void MakeImmune(Person person)
        {
            person.Immune = true;
            person.Infected = false;
        }
        
       
    }
}
