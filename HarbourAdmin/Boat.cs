using System;

namespace HarbourAdmin
{
    class Boat
    {
        public bool Docked { get; set; } = false;

        static Random Rand { get; set; } = new Random();
        public int Weight { get; set; } //kg
        public int MaxSpeed { get; set; } //knot
        public string ID { get; set; } = GetRandomID();

        static string GetRandomID()
        {
            char[] Alphabet = new char[]
            {
                'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            string letters="";
            for (int i = 0; i < 3; i++)
            {
                letters += Alphabet[Rand.Next(0, Alphabet.Length)].ToString();
            }


            return letters;
        }
    }
}
