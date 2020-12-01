using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NumberWordSwap
{
    public class NumberWordSwapper
    {
        // Find a way to get a subset of the results
        //  Add a unit test to verify the 15 case
        // Pass their own word pairs instead of Fizz Buzz
        public static async Task<IEnumerable<string>> ProcessValues(int upperLimit)
        {
            List<string> list = new List<string>();
            List<Task<string>> processResults = new List<Task<string>>();
            int cacheIndex = 1000;
            for (int index = 1; index <= upperLimit; index++)
            {
                // look into returning the results so far
                if (index > cacheIndex)
                {
                    Console.WriteLine("Continue operation? y/n");
                    string reply = Console.ReadLine();
                    if (string.Equals(reply, "n"))
                        break;
                    else
                    {
                        cacheIndex += 1000;
                    }
                }
                Console.WriteLine(ProcessNumberSwap("Fizz", "Buzz", index));
                processResults.Add(Task.Run(() => ProcessNumberSwap("Fizz", "Buzz", index)));
                //var result = await Task.Run(() => ProcessNumberSwap("Fizz", "Buzz", index));
                //list.Add(result);
            }
            return await Task.WhenAll(processResults);
        }

        public static async Task<List<string>> ProcessValues(string wordFor3, string wordFor5, int upperLimit)
        {
            List<string> results = new List<string>();
            for (int index = 1; index <= upperLimit; index++)
            {
                var result = await Task.Run(() => ProcessNumberSwap(wordFor3, wordFor5, index));
                results.Add(result);
            }
            return results;
        }

        public static string ProcessNumberSwap(string wordFor3, string wordFor5, int num)
        {
            string value = num.ToString();
            if (num % 3 == 0 && num % 5 == 0)
            {
                value = $"{wordFor3}{wordFor5}";
            }
            else if (num % 5 == 0)
            {
                value = wordFor5;
            }
            else if (num % 3 == 0)
            {
                value = wordFor3;
            }
            return value;
        }
    }
}
