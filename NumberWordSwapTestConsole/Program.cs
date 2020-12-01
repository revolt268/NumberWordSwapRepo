using System;
using System.Collections.Generic;

namespace NumberWordSwapTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Pass in 3 parameters - 3 case Name, 5 case Name, and upper limit
            // We want to return the results as we process them
            IList<string> results = NumberWordSwap.NumberWordSwapper.ProcessValues(100);
            //IList<string> results = NumberWordSwap.NumberWordSwapper.ProcessValues(int.MaxValue);
            foreach (string result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
