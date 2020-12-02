using NumberWordSwap;
using NUnit.Framework;

namespace NUnitTestForNumberWordSwap
{
    public class Tests
    {        
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Test to determine if 15 does report "FizzBuzz"
        /// This will make sure the basic function of both 
        ///  divisible by 3 and 5 work
        /// </summary>
        [Test]
        public void Is15FizzBuzz()
        {
            NumberWordSwap.NumberWordSwapper newSwapper = new NumberWordSwapper(20);
            string result = newSwapper.ProcessNumberSwap(15);
            Assert.AreEqual(result, "FizzBuzz");
        }
    }
}