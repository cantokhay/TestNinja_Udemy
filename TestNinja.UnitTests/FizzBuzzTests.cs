using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        [TestCase(1)]
        public void GetOutput_NumberNotDivisibleBy3Or5_ReturnTheSameNumber(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo(number.ToString()));
        }

        [Test]
        [TestCase(3)]
        public void GetOutput_NumberDivisibleBy3Only_ReturnFizz(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        [TestCase(5)]
        public void GetOutput_NumberDivisibleBy5Only_ReturnBuzz(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        [TestCase(45)]
        public void GetOutput_NumberDivisibleBy3And5_ReturnFizzBuzz(int number)
        {
            var result = FizzBuzz.GetOutput(number);

            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }
    }
}
