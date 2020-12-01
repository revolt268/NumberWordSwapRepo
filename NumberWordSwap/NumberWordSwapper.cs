using System;
using System.Collections.Generic;

namespace NumberWordSwap
{
    public class NumberWordSwapper
    {
        // Find a way to get a subset of the results
        //  Add a unit test to verify the 15 case
        // Pass their own word pairs instead of Fizz Buzz
        public static IList<string> ProcessValues(int upperLimit)
        {
            IList<string> results = new List<string>();
            for (int index = 1; index <= upperLimit; index++)
            {
                string value = index.ToString();
                if (index % 3 == 0 && index % 5 == 0)
                {
                    value = "FizzBuzz";
                }
                else if (index % 5 == 0)
                {
                    value = "Buzz";
                }
                else if (index % 3 == 0)
                {
                    value = "Fizz";
                }
                results.Add(value);
            }
            return results;
        }
    }
}
