//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    #region Syntax
    //public void MethodName_Scenario_ExpectedBehaviour() -- syntax
    //{
    // 1- Arrange
    // 2- Act
    // 3- Assert
    //}
    #endregion


    #region MSTest
    ////! This is Buil-in MSTest Testing Framework Syntax
    //[TestClass]
    //public class ReservationTests
    //{


    //    [TestMethod]
    //    public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
    //    {
    //        // Arrange
    //        var reservation = new Reservation();

    //        // Act
    //        var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

    //        // Assert
    //        Assert.IsTrue(result);
    //    }

    //    [TestMethod]
    //    public void CanBeCancelledBy_MadeByIsUser_ReturnsTrue()
    //    {
    //        // Arrange
    //        var user = new User();
    //        var reservation = new Reservation { MadeBy = user };

    //        // Act
    //        var result = reservation.CanBeCancelledBy(user);

    //        // Assert
    //        Assert.IsTrue(result);
    //    }

    //    [TestMethod]
    //    public void CanBeCancelledBy_AnotherUser_ReturnsFalse()
    //    {
    //        var reservation = new Reservation { MadeBy = new User() };

    //        var result = reservation.CanBeCancelledBy(new User());

    //        Assert.IsFalse(result);
    //    }
    //}
    #endregion


    #region NUnit --Current
    //! This is NUnit Testing Framework Syntax
    // need to download NUnit and NUnit3TestAdapter from NuGet Package Manager
    // assert should using NUnit.Framework;
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_UserIsAdmin_ReturnsTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert v0
            //Assert.IsTrue(result);

            // Assert v1
            //Assert.That(result, Is.True);

            // Assert v2
            Assert.That(result == true);
        }

        [Test]
        public void CanBeCancelledBy_MadeByIsUser_ReturnsTrue()
        {
            // Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy = user };

            // Act
            var result = reservation.CanBeCancelledBy(user);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);
        }
    }
    #endregion

}
