using NumberWordSwap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NumberWordSwapTestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Pass in 3 parameters - 3 case Name, 5 case Name, and upper limit
            // We want to return the results as we process them
            //Task<List<string>> results = NumberWordSwapper.ProcessValues("My", "Word", 100);
            Task<IEnumerable<string>> results = NumberWordSwapper.ProcessValues(int.MaxValue);
            //Task<IEnumerable<string>> results = NumberWordSwapper.ProcessValues(1000);
            var output = await results;
            foreach (string result in output)
            {
                Console.WriteLine(result);
            }
        }
    }
}
