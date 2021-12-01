using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class EmployeeCustomerTest
    {
        [TestMethod]
        public void Test_PAYLVL1_weeklyPay_EmployeeCustomer_true()
        {
            // Arrange
            dbetCustomer b = new dbetCustomer();
            EmployeeCustomer bob = new EmployeeCustomer("Bob", "Smith", 1, "QFC", b);
            double expected = 150.00;

            // Act
            bob.setPay();
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PAYLVL2_weeklyPay_EmployeeCustomer_true()
        {
            // Arrange
            dbetCustomer b = new dbetCustomer();
            EmployeeCustomer bob = new EmployeeCustomer("Bob", "Smith", 2, "QFC", b);
            double expected = 300.00;

            // Act
            bob.setPay();
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_PAYLVL3_weeklyPay_EmployeeCustomer_true()
        {
            // Arrange
            dbetCustomer b = new dbetCustomer();
            EmployeeCustomer bob = new EmployeeCustomer("Bob", "Smith", 3, "QFC", b);
            double expected = 400.00;

            // Act
            bob.setPay();
            bob.weeklyPay();
            double actual = bob.getAccountBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getEmployeer_EmployeeCustomer_true()
        {
            carbCustomer m = new carbCustomer();
            string expected = "Kroger";
            EmployeeCustomer mark = new EmployeeCustomer("Mark", "Zuck", 2, expected, m);

            string actual = mark.getEmployer();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getFName_defaultCtor_EmployeeCustomer_true()
        {
            string expected = "N/A";
            EmployeeCustomer marnie = new EmployeeCustomer();

            string actual = marnie.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getFName_EmployeeCustomer_true()
        {
            carbCustomer m = new carbCustomer();
            string expected = "Marnie";
            EmployeeCustomer marnie = new EmployeeCustomer(expected, "Silver", 1, "Pokemart", m); ;

            string actual = marnie.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getLName_defaultCtor_employee_true()
        {
            string expected = "N/A";
            EmployeeCustomer kass = new EmployeeCustomer();

            string actual = kass.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getLName_EmployeeCustomer_true()
        {
            allergyCustomer k = new allergyCustomer();
            string expected = "Momokoto";
            EmployeeCustomer kass = new EmployeeCustomer("Kass", expected, 1, "Maruta", k);

            string actual = kass.getLName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_setFName_EmployeeCustomer_true()
        {
            string expected = "Link";
            EmployeeCustomer link = new EmployeeCustomer();
            link.setFName(expected);

            string actual = link.getFName();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_setLName_EmployeeCustomer_true()
        {
            string expected = "Link";
            EmployeeCustomer link = new EmployeeCustomer();
            link.setLName(expected);

            string actual = link.getLName();

            Assert.AreEqual(expected, actual);
        }
    }
}