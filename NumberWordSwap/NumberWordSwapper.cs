using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace NumberWordSwap
{
    /// <summary>
    /// Number Word Swapper used to change numbers into words
    /// Only changes numbers divisble by 3 to the one word and 5 to another word
    /// </summary>
    public class NumberWordSwapper : INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// Word that will be used for numbers divisible by 3
        /// </summary> 
        public string WordFor3 { get; set; }
        /// <summary>
        /// Word that will be used for numbers divisible by 5
        /// </summary>
        public string WordFor5 { get; set; }
        /// <summary>
        /// Upper limit for the program to count up to.  
        /// </summary>
        public int UpperLimit { get; set; }
        /// <summary>
        /// Cache Size -- Might make this changable int he future but for now using 1000 results as the cut off.  
        /// </summary>
        private int cacheSize = 1000;
        /// <summary>
        /// Completed list - will be completely populated once the list is done
        /// </summary>
        public List<string> Results { get; set; }
        /// <summary>
        /// private member for Cache list - used to hold the cached values as we build up the list.  It will hold the last [cacheSize] numbers processed
        /// </summary>
        private List<string> cache;
        /// <summary>
        /// Cache list - used to hold the cached values as we build up the list.  It will hold the last [cacheSize] numbers processed
        /// </summary>
        public List<string> CacheResults
        {
            get { return cache; }
            set
            {
                cache = value;
                OnListCacheUpdate();
            }
        }
        #endregion

        #region EventHandlers
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        /// <summary>
        /// Constructor that takes in custom words for the values divisible by 3 and 5
        ///     With an upperlimit that can be set from 0 to int.Max
        /// </summary>
        /// <param name="wordFor3">Word to use when divisible by 3</param>
        /// <param name="wordFor5">Word to use when divisible by 5</param>
        /// <param name="upperLimit">The last number to stop the process on</param>
        public NumberWordSwapper(string wordFor3, string wordFor5, int upperLimit)
        {
            WordFor3 = wordFor3;
            WordFor5 = wordFor5;
            UpperLimit = upperLimit;
        }
        /// <summary>
        /// Constructor that takes an upperlimit with a range from 0 - int.Max
        ///     This uses the default words
        ///     Fizz - divisible by 3
        ///     Buzz - divisible by 5
        /// </summary>
        /// <remarks>An upperlimit of 0 will just return an empty list</remarks>
        /// <param name="upperLimit"></param>
        public NumberWordSwapper(int upperLimit)
        {
            WordFor3 = "Fizz";
            WordFor5 = "Buzz";
            UpperLimit = upperLimit;
        }
        // Find a way to get a subset of the results
        //  Add a unit test to verify the 15 case
        // Pass their own word pairs instead of Fizz Buzz
        public List<string> ProcessValues()
        {
            List<string> list = new List<string>();
            List<Task<string>> processResults = new List<Task<string>>();
            int cacheIndex = cacheSize;
            int startIndex = 0;
            for (int index = 1; index <= UpperLimit; index++)
            {
                list.Add(ProcessNumberSwap(index));

                // Cache a 1000 results and put them into the Cache Results list
                // the even will trigger when this happens allowing the Console to fire off a print when the 1000 is available
                if (index % 1000 == 0)
                {
                    CacheResults = list.GetRange(startIndex, cacheSize);
                    startIndex = index;
                    cacheIndex += cacheSize;
                }
            }
            return list;
        }
        /// <summary>
        /// Processes the number and determines if it is divisible by 3, 5 or both
        /// </summary>
        /// <param name="wordFor3"></param>
        /// <param name="wordFor5"></param>
        /// <param name="num"></param>
        /// <returns>Either the original number as a string or the resulting word(s)</returns>
        public string ProcessNumberSwap(int num)
        {
            string value = num.ToString();
            if (num % 3 == 0 && num % 5 == 0)
            {
                value = $"{WordFor3}{WordFor5}";
            }
            else if (num % 5 == 0)
            {
                value = WordFor5;
            }
            else if (num % 3 == 0)
            {
                value = WordFor3;
            }
            return value;
        }
        /// <summary>
        /// This method fires off when the Cache change
        /// </summary>
        protected void OnListCacheUpdate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CacheResults"));
        }
    }
}
