using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class StackTests
    {
        private Stack<string> _stack;

        [SetUp]
        public void SetUp()
        {
            _stack = new Stack<string>();
        }

        [TearDown]
        public void TearDown()
        {
            _stack = null;
        }

        [Test]
        public void Push_WhenCalled_AddObjectToStack()
        {
            _stack.Push("a");

            Assert.That(_stack.Count, Is.EqualTo(1));
        }
        [Test]
        public void Push_ArgIsNull_ThrowArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Pop_WhenCalled_RemoveObjectFromStack()
        {
            _stack.Push("a");
            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_WhenCalled_ReturnObjectFromStack()
        {
            _stack.Push("a");
            var result = _stack.Peek();

            Assert.That(result, Is.EqualTo("a"));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Count_StackWithObjects_ReturnNumberOfObjects()
        {
            _stack.Push("a");
            _stack.Push("b");
            _stack.Push("c");

            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
