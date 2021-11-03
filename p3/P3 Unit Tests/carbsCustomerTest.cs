using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class carbsCustomerTest
    {
        [TestMethod]
        public void Test_buy_carbCustomer_true()
        {
            // Arrange 
            carbCustomer Molly = new carbCustomer(12, 12.00);
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

            double expected = 9.00;

            // Act
            Molly.buyOne(fruitStand, "Grapes");
            double actual = Molly.getCurrentBalance();

            //  Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buy_carbsCustomer_true()
        {
            carbCustomer Molly = new carbCustomer(12, 12.00);
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

            double expected = 10.50;

            // Act
            Molly.buy(fruitStand);
            double actual = Molly.getCurrentBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
