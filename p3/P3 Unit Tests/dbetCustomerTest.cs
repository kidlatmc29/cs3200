using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class dbetCustomerTest
    {
        [TestMethod]
        public void Test_buyOne_dbCustomer_true()
        {
            // Arrange
            dbetCustomer me = new dbetCustomer(24, 10.00);

            Vendor fruitStand = new Vendor("McPhee's", true);

            string txt = "Fresh Brand - Sliced Apples	2.5	70	0	0	0	0	0	19	3	15	0	apples";
            DateTime exp = new DateTime(2021, 12, 31);
            Entree obj = new Entree(txt, exp, true, false);

            fruitStand.load(obj, 5, 1.50);
            int expected = 4;

            // Act
            me.buyOne(fruitStand, "Fresh Brand - Sliced Apples");
            int actual = fruitStand.getItemQuantity("Fresh Brand - Sliced Apples");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
