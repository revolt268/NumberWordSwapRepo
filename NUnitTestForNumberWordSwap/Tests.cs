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

        [Test]
        public void Is15FizzBuzz()
        {
            string result = NumberWordSwapper.ProcessNumberSwap("Fizz", "Buzz", 15);
            Assert.AreEqual(result, "FizzBuzz");
        }
    }
}