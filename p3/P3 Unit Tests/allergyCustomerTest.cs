using System; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class allergyCustomerTest
    {
        [TestMethod]
        public void Test_buy_allergyCustomer_true()
        {
            // Arrange
            allergyCustomer me = new allergyCustomer(230, 5.23);
            Vendor market = new Vendor("The Peas", true);

            me.addAllergen("peanuts");
            me.addAllergen("egg");
            me.addAllergen("milk");

            string txt = "Fresh Brand - Sliced Apples	2.5	70	0	0	0	0	0	19	3	15	0	apples";
            DateTime exp = new DateTime(2021, 12, 31);
            Entree obj = new Entree(txt, exp, true, true);

            market.load(obj, 12, 2.12);

            bool expected = true;

            // Act
            bool actual = me.buyOne(market, "Fresh Brand - Sliced Apples");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] 
        public void Test_buy_containsAllergen_allergyCustomer_false()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
