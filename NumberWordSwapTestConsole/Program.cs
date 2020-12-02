using NumberWordSwap;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NumberWordSwapTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Decided to create a class for this to process the numbers and maintain a cache
            NumberWordSwapper numberSwapper = new NumberWordSwapper("My", "Word", 1000);
            // Attaching the below method to capture the caches list as it is completed.  
            numberSwapper.PropertyChanged += NumberSwapper_PropertyChanged;
            var output = numberSwapper.ProcessValues();

            // this call isn't completely needed now since the NumberSwapper_PropertyChange is 
            //   Printing out the results but I left it to show that all the results can also be printed out as well.
            //   this is also handy since if the upperlimit is set to something lower then the cache size then the cache
            //   is not used.  
            Console.WriteLine("Complete showing whole list below");
            foreach (string result in output)
            {
                Console.WriteLine(result);
            }
        }
        /// <summary>
        ///  Method called  when the cache is finished so that the 
        ///    values can be pulled before the whole process is done.
        ///    Currently this just gets the last 1000 results.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /*************************************************************
 
        *************************************************************/
        private static void NumberSwapper_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NumberWordSwapper swapper = (NumberWordSwapper)sender;
            if (swapper.CacheResults == null)
                return;
            Console.WriteLine("*************Cached*************"); // Just put here to help see where the cache has started/ended
            foreach (string value in swapper.CacheResults)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("*************Cached*************");
        }
    }
}
