using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace TheifAndPolice
{
    class Program
    {
        static void Main(string[] args)
        {

        Console.WriteLine("\n" +
            @"___________.__    .__        _____     " + "\n" +
            @"\__    ___/|  |__ |__| _____/ ____\   " + "\n" +
            @"  |    |   |  |  \|  |/ __ \   __\ " + "\n" +
            @"  |    |   |   Y  \  \  ___/|  |  " + "\n" +
            @"  |____|   |___|  /__|\___  >__|  " + "\n" +
            @"                \/        \/     " + "\n" +
            @"                   ____    " + "\n" +
            @"                  /  _ \ " + "\n" +
            @"                  >  _ </\   " + "\n" +
            @"                 /  <_\ \/   " + "\n" +
            @"                 \_____\ \   " + "\n" +
            @"                        \/   " + "\n" +
            @"          __________      .__  .__       " + "\n" +
            @"          \______   \____ |  | |__| ____  ____ " + "\n" +
            @"           |     ___/  _ \|  | |  |/ ___\/ __ \" + "\n" +
            @"           |    |  (  <_> )  |_|  \  \__\  ___/ " + "\n" +
            @"           |____|   \____/|____/__|\___  >___  >" + "\n" +
            @"                                       \/    \/" + "\n" +


            "");


            Console.WriteLine("  Press a key.. to start the simulation...");
            Console.ReadKey(true);
            Console.Clear();
            City runCity = new City(60, 120); //Didn't notice while I was working on this assignment but because of my 'hardcoding' for a lack of a better word. This game cannot keep up rendering large maps.

        }
    
    }
}