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
            Employee bob = new Employee("Bob", "Smith", 1, "QFC");
            double expected = 150.00;

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
            Employee bob = new Employee("Bob", "Smith", 2, "QFC");
            double expected = 300.00;

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
            Employee bob = new Employee("Bob", "Smith", 3, "QFC");
            double expected = 400.00;

            // Act
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getEmployeer_employee_true()
        {
            string expected = "Kroger";
            Employee mark = new Employee("Mark", "Zuck", 2, expected);

            string actual = mark.getEmployer();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getFName_defaultCtor_employee_true()
        {
            string expected = "N/A";
            Employee marnie = new Employee();

            string actual = marnie.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getFName_employee_true()
        {
            string expected = "Marnie";
            Employee marnie = new Employee(expected, "Silver", 1, "Pokemart"); ;

            string actual = marnie.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getLName_defaultCtor_employee_true()
        {
            string expected = "N/A";
            Employee kass = new Employee();

            string actual = kass.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getLName_employee_true()
        {
            string expected = "Momokoto";
            Employee kass = new Employee("Kass", expected, 1, "Maruta");

            string actual = kass.getLName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_setFName_employee_true()
        {
            string expected = "Link";
            Employee link = new Employee();
            link.setFName(expected);

            string actual = link.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_setLName_employee_true()
        {
            string expected = "Link";
            Employee link = new Employee();
            link.setLName(expected);

            string actual = link.getLName();

            Assert.AreEqual(expected, actual);
        }
    }
}