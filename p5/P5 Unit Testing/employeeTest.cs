using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class employeeTest
    {
        [TestMethod]
        public void Test_PAYLVL1_weeklyPay_employee_true()
        {
            // Arrange
            Employee bob = new Employee("Bob", "Smith", 0, "QFC");
            double expected = 12.00;

            // Act
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PAYLVL2_weeklyPay_employee_true()
        {
            // Arrange
            Employee bob = new Employee("Bob", "Smith", 1, "QFC");
            double expected = 15.00;

            // Act
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PAYLVL3_weeklyPay_employee_true()
        {
            // Arrange
            Employee bob = new Employee("Bob", "Smith", 2, "QFC");
            double expected = 20.00;

            // Act
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}