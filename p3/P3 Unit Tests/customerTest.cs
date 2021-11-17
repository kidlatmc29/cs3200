using System; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class customerTest
    {
        [TestMethod]
        public void Test_addMoney_customer_true()
        {
            // Arrange
            Customer me = new Customer(1, 5.00);
            double expected = 10.00;

            // Act
            me.addMoney(5.00);
            double actual = me.getCurrentBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_addMoney_negative_customer_true()
        {
            // Arrange
            Customer me = new Customer(1, 10.40);
            double expected = 10.40;

            // Act
            me.addMoney(-10.00);
            double actual = me.getCurrentBalance();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buyOne_inStock_customer_true()
        {

        }

        [TestMethod]
        public void Test_buyOne_NotInStock_customer_true()
        {

        }

        [TestMethod]
        public void Test_buyOne_noMoney_customer_true()
        {
        }

        [TestMethod]
        public void Test_buy_inStock_customer_true()
        {
            // Arrange
            Customer me = new Customer(10, 5.00);
            Vendor candy = new Vendor("Candy Store", false);

            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022, 5, 1);
            Entree obj = new Entree(txt, exp, false, false);

            candy.load(obj, 3, 2.00);
            bool expected = true;

            // Act
            bool actual = me.buy(candy);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buy_noMoney_customer_false()
        {
            // Arrange
            Customer me = new Customer(10, 1.00);
            Vendor candy = new Vendor("Candy Store", false);

            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022, 5, 1);
            Entree obj = new Entree(txt, exp, false, false);

            candy.load(obj, 3, 2.00);
            bool expected = false;

            // Act
            bool actual = me.buy(candy);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
