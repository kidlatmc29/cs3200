using System; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class allergyCustomerTest
    {
        [TestMethod]
        public void Test_buyOne_allergyCustomer_true()
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
        public void Test_buyOne_containsAllergen_allergyCustomer_false()
        {
            // Arrange

            // Act

            // Assert
        }

        [TestMethod]
        public void Test_buy_allergyCustomer_true()
        {
            // Arrange
            allergyCustomer Bob = new allergyCustomer(300, 10.00);
            Vendor fruitStand = new Vendor("McPhee's", true);

            Bob.addAllergen("milk");
            Bob.addAllergen("peanuts");

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

            bool expected = true; 

            // Act
            bool actual = Bob.buy(fruitStand);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buy_allergyCustomer_false()
        {
            // Arrange
            allergyCustomer Nancy = new allergyCustomer(123, 10.00); 
            Vendor snacks = new Vendor("Fast Snaccs", true);

            Nancy.addAllergen("peanuts");
            Nancy.addAllergen("milk");
            Nancy.addAllergen("wheat");

            string txt1 = "Horizon Organic Whole Milk	1	150	8	5	0	35	130	13	0	12	8	Grade A Organic Milk$Vitamin D3	milk";
            DateTime exp1 = new DateTime(2022, 12, 1);
            Entree obj1 = new Entree(txt1, exp1, true, true);

            string txt2 = "Planters Nuts on the Go Salted Peanuts	1	170	14	2	0	0	95	5	2	1	7	Peanuts$Peanut and/or Cottonseed oil$sea salt	peanuts";
            DateTime exp2 = new DateTime(2022, 11, 1);
            Entree obj2 = new Entree(txt2, exp2, false, false);

            string txt3 = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening(palm and canola oil [with TBHQ to preserve freshness])$ semi - sweet chocolate chips(sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2 % of$molasses$fructose$modified corn starch$polydextrose$leavening(baking soda, ammonium bicarbonate)$propylene glycol mono - and diesters of fats and fatty acides, mono-and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp3 = new DateTime(2021, 12, 1);
            Entree obj3 = new Entree(txt3, exp3, false, false);

            snacks.load(obj1, 3, 4.00);
            snacks.load(obj2, 12, 1.50);
            snacks.load(obj3, 5, 2.00);

            bool expected = false;

            // Act
            bool actual = Nancy.buy(snacks);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void Test_addAllergen_allergyCustomer_true()
        {
            // Arrange
            allergyCustomer me = new allergyCustomer();
            me.addAllergen("peanuts");
            bool expected = true;

            // Act
            string allergies = me.getAllergens();
            bool actual = allergies.Contains("peanuts");

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
