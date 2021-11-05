using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class carbCustomerTest
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
        public void Test_buy_carbCustomer_false()
        {
            // Arrange
            carbCustomer Jake = new carbCustomer(12, 6.34);
            Vendor bakery = new Vendor("Cupcakes and More!", true);

            string txt1 = "Sprite	1	140	0	0	0	0	75	65	0	65	0	CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$NATURAL FLAVORS$SODIUM CITRATE$SODIUM BENZOATE";
            DateTime exp1 = new DateTime(2024, 12, 2);
            Entree cookie = new Entree(txt1, exp1, false, true);

            string txt2 = "Coke	1	240	0	0	0	0	75	65	0	65	0	CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CARAMEL COLOR$PHOSPHORIC ACID$NATURAL FLAVORS$CAFFEINE";
            DateTime exp2 = new DateTime(2021, 12, 30);
            Entree soda = new Entree(txt2, exp2, true, true);

            string txt3 = "Vanilla Cupcake	1	240	10	3	0	15	160	35	0	26	1	Sugar$ Bleached Enriched Flour (wheat Flour$ Malted Barley Flour$ Niacin$ Iron$ Thiamin Mononitrate$ Riboflavin$ Folic Acid)$ Soybean Oil$ Water$ Blueberries$ Eggs$ Glycerine$ Contains 2% Or Less: Corn Syrup$ Modified Food Starch$ Non Fat Dry Milk$ Leavening (sodium Acid Pyrophosphate$ Baking Soda$ Monocalcium Phosphate)$ Salt$ Natural Flavors$ Preservatives (sodium Propionate And Potassium Sorbate)$ Xanthan Gum$ Corn Starch$ Citric Acid$ Carnauba Wax	egg$milk$soy$wheat";
            DateTime exp3 = new DateTime(2023, 5, 23);
            Entree cupcake = new Entree(txt3, exp3, true, true);

            bakery.load(cookie, 12, 2.50);
            bakery.load(soda, 23, 1.00);
            bakery.load(cupcake, 5, 4.50);

            bool expected = false;
            // Act
            bool actual = Jake.buy(bakery);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_buyOne_carbCustomer_true()
        {

        }

        [TestMethod]
        public void Test_buyOne_carbCustomer_false()
        {

        }

        [TestMethod]
        public void Test_getDailyCarbs_carbsCustomer_true()
        {
            // Arrange
            carbCustomer me = new carbCustomer(100, 3.00);
            Vendor bakery = new Vendor("Sugar Rush", false);

            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022, 5, 1);
            Entree obj = new Entree(txt, exp, false, false);

            bakery.load(obj, 3, 2.00);
            double expected = 25.00;

            // Act
            me.buyOne(bakery, "Grandma's Chocolate Chip Cookies");
            double actual = me.getDailyCarbs();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
