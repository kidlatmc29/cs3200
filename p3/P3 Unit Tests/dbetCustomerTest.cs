using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class dbetCustomerTest
    {
        [TestMethod]
        public void Test_buyOne_dbCustomer_false()
        {
            // Arrange
            dbetCustomer me = new dbetCustomer(24, 10.00);

            Vendor fruitStand = new Vendor("McPhee's", true);

            string txt = "Fresh Brand - Sliced Apples	2.5	70	0	0	0	0	0	19	3	15	0	apples";
            DateTime exp = new DateTime(2021, 12, 31);
            Entree obj = new Entree(txt, exp, true, true);

            fruitStand.load(obj, 5, 1.50);
            int expected = 5;

            // Act
            me.buyOne(fruitStand, "Fresh Brand - Sliced Apples");
            int actual = fruitStand.getItemQuantity("Fresh Brand - Sliced Apples");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buyOne_dbCustomer_true()
        {
            // Arrange
            dbetCustomer someone = new dbetCustomer(10, 4.21);
            Vendor snacks = new Vendor("Snacc", true);

            string txt = "Rhythm Superfoods Carrot Sticks	1	60	1	0	0	0	130	12	4	2	1	Organic carrots$organic high oleic sunflower oil$organic rosemary extract$	Cashew";
            DateTime exp = new DateTime(2021, 12, 31);
            Entree obj = new Entree(txt, exp, true, true);

            snacks.load(obj, 23, 1.10);
            int expected = 22;

            // Act
            someone.buyOne(snacks, "Rhythm Superfoods Carrot Sticks");
            int actual = snacks.getItemQuantity("Rhythm Superfoods Carrot Sticks");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buyOne_overDailySugar_dbCustomer_true()
        {
            // Arrange
            dbetCustomer Joe = new dbetCustomer(13, 3.00);
            Vendor store = new Vendor("Walmart", true);

            string txt = "Fanta	1	270	0	0	0	0	75	73	0	73	0	CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$SODIUM BENZOATE (TO PROTECT TASTE)$NATURAL FLAVORS$MODIFIED FOOD STARCH$SODIUM POLYPHOSPHATES$GLYCEROL ESTER OF ROSIN$YELLOW 6$RED 40";
            DateTime exp = new DateTime(2023, 3, 12);
            Entree obj = new Entree(txt, exp, true, true);

            store.load(obj, 13, 2.50);

            int expected = 13; 

            // Act
            Joe.buyOne(store, "Fanta");
            int actual = store.getItemQuantity("Fanta");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
