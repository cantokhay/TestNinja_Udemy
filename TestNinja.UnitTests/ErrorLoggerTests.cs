using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        private ErrorLogger _logger;

        [SetUp]
        public void SetUp()
        {
            _logger = new ErrorLogger();
        }

        [Test]
        public void Log_WhenCalled_SetTheLastErrorProperty()
        {
            // Act
            _logger.Log("a");

            // Assert
            Assert.That(_logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            // Assert
            Assert.That(() => _logger.Log(error), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            // Arrange
            var id = Guid.Empty;
            _logger.ErrorLogged += (sender, guid) => { id = guid; };

            // Act
            _logger.Log("a");

            // Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
        

    }
}
