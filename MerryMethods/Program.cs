using System;

namespace MerryMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodBench methodBench = new MethodBench();
            bool shout = methodBench.FourthMethod();
            int conditional = 0;
            

            do
            {
                methodBench.FirstMethod();
                conditional++;

            } while (conditional < 3);

            methodBench.SecondMethod("C# Now and Forever!");
            string userSentance = Console.ReadLine();
            methodBench.SecondMethod(userSentance);
            
            bool makeChoice = true;
            bool isLargeSmall = false;
            while (makeChoice)
            {
                Console.WriteLine("Type 'small' for the output to be in small letters or 'large' for large letters!: ");
                string largeSmall = Console.ReadLine();

                if (largeSmall == "large")
                {
                    isLargeSmall = true;
                    makeChoice = false;
                }
                else if (largeSmall == "small")
                {
                    isLargeSmall = false;
                    makeChoice = false;

                }
                else
                {
                    Console.WriteLine("Invalid input. Type large/small! ");
                }

            }
            methodBench.ThirdMethod(userSentance, isLargeSmall);
            methodBench.ThirdMethod(userSentance, shout);
            methodBench.ThirdMethod(userSentance, methodBench.FourthMethod());
        }
    }
}
