using System;
using System.Collections.Generic;
using System.Text;

namespace VirusEpidemic
{
    public class Person
    {

        public bool Infected { get; set; }
        public int InfectedWhen { get; set; }

        public bool Immune { get; set; }

        public List<Person> CreatePeople()
        {
            List<Person> disco = new List<Person>
            {
                PatientZero()
            };

            Console.WriteLine("How many people are allowed in the disco?\nInput number: ");
            int peopleAllowedIntoDisco = int.Parse(Console.ReadLine());
            peopleAllowedIntoDisco -= 1;

            for (int i = 0; i < peopleAllowedIntoDisco; i++)
            {
                Person PersonInDisco = new Person();
                disco.Add(PersonInDisco);
            }
            
            return disco;
        }
        public Person PatientZero()
        {
            Person person = new Person()
            {
                Infected = true,
            };
            return person;
        }

    }
}
