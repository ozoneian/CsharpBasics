using System;
using System.Collections.Generic;
using System.Text;

namespace MerryMethods
{
    class MethodBench
    {
        public void FirstMethod()
        {
            Console.WriteLine("Merry Methods");
        }
        public void SecondMethod(string parameter)
        {
            Console.WriteLine(parameter);
        }
        public void ThirdMethod(string parameter, bool conditional)
        {
            if (conditional==true)
            {
                SecondMethod(parameter.ToUpper());
            }
            else
            {
                SecondMethod(parameter.ToLower());
            }
        }
        public bool FourthMethod()
        {
            Console.WriteLine("Do you want to 'whisper' or 'scream'?\n\n Press the key [W] to whisper OR [S] to scream: ");
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                return true;
            }
            //else if (Console.ReadKey(true).Key==ConsoleKey.W)
            //{
            //    return false;
            //}
            else
            {
                return false;
            }
        }
    }
}
