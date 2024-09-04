using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        private EmployeeController _controller;
        private Mock<IEmployeeData> _employeeData;

        [SetUp]
        public void SetUp()
        {
            _employeeData = new Mock<IEmployeeData>();
            _controller = new EmployeeController(_employeeData.Object);
        }

        [Test]
        public void DeleteEmployee_WhenCalled_DeleteEmployeeFromDb()
        {
            // Arrange
            _employeeData.Setup(x => x.DeleteEmployee(1));

            // Act
            _controller.DeleteEmployee(1);

            // Assert
            _employeeData.Verify(x => x.DeleteEmployee(1));
        }

        [Test]
        public void DeleteEmployee_WhenCalled_RedirectToEmployees()
        {
            // Arrange
            var result = _controller.DeleteEmployee(1);

            // Assert
            Assert.That(result, Is.TypeOf<RedirectResult>());
        }
    }
}
