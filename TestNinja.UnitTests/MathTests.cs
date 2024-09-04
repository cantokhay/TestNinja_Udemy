using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class MathTests
    {
        private Math _math;

        // SetUp : Called before each test
        // TearDown : Called after each test

        [SetUp]
        public void SetUp()
        {
            _math = new Math();
        }

        [Test]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = _math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [Ignore("Ignored test!")]
        public void Max_FirstArgumentIsGreater_ReturnTheFirstArgument()
        {

            var result = _math.Max(2, 1);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Ignored test!")]
        public void Max_SecondArgumentIsGreater_ReturnTheSecondArgument()
        {

            var result = _math.Max(1, 2);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        [Ignore("Ignored test!")]
        public void Max_ArgumentsAreEqual_ReturnTheSameArgument()
        {

            var result = _math.Max(1, 1);

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 1, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnTheGreaterArgument(int a, int b, int expectedReturn)
        {
            var result = _math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedReturn));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = _math.GetOddNumbers(5);

            //Assert.That(result, Is.Not.Empty); too general
            //Assert.That(result.Count(), Is.EqualTo(3)); too specific

            //Assert.That(result, Does.Contain(1)); //not reliable
            //Assert.That(result, Does.Contain(3)); //not reliable
            //Assert.That(result, Does.Contain(5)); //not reliable

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 })); //better practice in this case
            //Assert.That(result, Is.Ordered);
            //Assert.That(result, Is.Unique); 
        }

        [Test]
        public void GetOddNumbers_LimitIsZero_ReturnEmptySequence()
        {
            var result = _math.GetOddNumbers(0);

            Assert.That(result, Is.Empty );
        }

        [Test]
        public void GetOddNumbers_LimitIsNegative_ReturnEmptySequence()
        {
            var result = _math.GetOddNumbers(-5);

            Assert.That(result, Is.Empty);
        }
    }
}
