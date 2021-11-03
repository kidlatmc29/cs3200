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

        [TestMethod]
        public void Test_buy_dbCustomer_true()
        {
            // Arrange
            dbetCustomer me = new dbetCustomer(24, 10.00);

            Vendor fruitStand = new Vendor("McPhee's", true);

            string txt1 = "Fresh Brand - Sliced Apples	2.5	70	0	0	0	0	0	19	3	15	0	apples";
            DateTime exp1 = new DateTime(2021, 12, 31);
            Entree obj1 = new Entree(txt1, exp1, true, true);

            string txt2 = "Grapes	1	104	0	0	0	0	3	27	1	23	1	Grapes";
            DateTime exp2 = new DateTime(2022, 1, 10);
            Entree obj2 = new Entree(txt2, exp2, true, true);

            string txt3 = "Carrot Sticks	1	60	1	0	0	0	130	12	4	2	1	Organic carrots$organic high oleic sunflower oil$organic rosemary extract$	Cashew";
            DateTime exp3 = new DateTime(2022, 1, 10);
            Entree obj3 = new Entree(txt3, exp3, true, true);

            fruitStand.load(obj1, 5, 1.50);
            fruitStand.load(obj2, 10, 3.00);
            fruitStand.load(obj3, 6, 2.50);

            double expected = 3.00;

            // Act
            me.buy(fruitStand);
            double actual = me.getCurrentBalance(); 
            
            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buy_allOverDailySugar_dbCustomer_true()
        {
            // Arrange
            dbetCustomer me = new dbetCustomer(24, 10.00);
            Vendor sodaMachine = new Vendor("Drinks", true);

            string txt1 = "Fanta	1	270	0	0	0	0	75	73	0	73	0	CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$SODIUM BENZOATE (TO PROTECT TASTE)$NATURAL FLAVORS$MODIFIED FOOD STARCH$SODIUM POLYPHOSPHATES$GLYCEROL ESTER OF ROSIN$YELLOW 6$RED 40";
            DateTime exp1 = new DateTime(2022, 3, 20);
            Entree obj1 = new Entree(txt1, exp1, true, true);

            string txt2 = "Sprite	1	140	0	0	0	0	75	65	0	65	0	CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$NATURAL FLAVORS$SODIUM CITRATE$SODIUM BENZOATE";
            DateTime exp2 = new DateTime(2022, 3, 20);
            Entree obj2 = new Entree(txt2, exp2, true, true);

            string txt3 = "Coke	1	240	0	0	0	0	75	65	0	65	0	CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CARAMEL COLOR$PHOSPHORIC ACID$NATURAL FLAVORS$CAFFEINE";
            DateTime exp3 = new DateTime(2022, 3, 20);
            Entree obj3 = new Entree(txt3, exp3, true, true);

            sodaMachine.load(obj1, 5, 2.00);
            sodaMachine.load(obj2, 5, 2.00);
            sodaMachine.load(obj3, 5, 2.00);

            double expected = 10.00;

            // Act
            me.buy(sodaMachine);
            double actual = me.getCurrentBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_getDailySugar_sugarCustomer_true()
        {
            // Arrange
            // Act
            // Assert
        }
    }
}
