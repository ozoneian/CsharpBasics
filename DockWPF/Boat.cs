using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace DockWPF
{
    class Boat
    {
        public bool Docked { get; set; } = false;
        public virtual int Slots { get; set; }
        static Random Rand { get; set; } = new Random();
        public int Weight { get; set; } //kg
        public int MaxSpeed { get; set; } //knot
        public string ID { get; set; } = GetRandomID();
        public virtual SolidColorBrush BoatColor { get; set; } = new SolidColorBrush(Colors.Black);
    static string GetRandomID()
        {
            char[] Alphabet = new char[]
            {
                        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
            };
            string letters = "";
            for (int i = 0; i < 3; i++)
            {
                letters += Alphabet[Rand.Next(0, Alphabet.Length)].ToString();
            }


            return letters;
        }
        public virtual void AddDay()
        {

        }
        public virtual string DisplayBoatInfo()
        {
            return " ";

        }
        public virtual string BoatInfo()
        {
            return " ";

        }
    }
}
