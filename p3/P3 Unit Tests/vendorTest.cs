using Microsoft.VisualStudio.TestTools.UnitTesting;
using System; 

namespace p3
{
    [TestClass]
    public class vendorTest
    {
        [TestMethod]
        public void Test_getName_vendor_true()
        {
            // Arrange
            string expected = "Sweets 4 Life"; 
            Vendor candyStore = new Vendor(expected, false);

            // Act
            string actual = candyStore.getName();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_load_vendor_true()
        {
            // Arrange
            int expected = 1;
            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022, 5, 1);
            Entree obj = new Entree(txt, exp, false, false);

            Vendor bakery = new Vendor("Cool Cookies", false);

            // Act
            bakery.load(obj, 10, 2.00);
            int actual = bakery.getSize();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_isStocked_vendor_true()
        {
            // Arrange
            string txt1 = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp1 = new DateTime(2022, 5, 1);
            Entree cookie = new Entree(txt1, exp1, false, false);

            string txt2 = "Cheez It	1	140	7	1.5	0	0	210	16	0	0	3	\"Enriched flour(wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable oil(high oleic soybeen, soybean, palm, canola oil) $ cheese(skim milk, whey protein, salt, cheese cultrures, enzymes, annatto extract color) \"	salt$paprika$yeast$paprika extract color$ soy lecithin";
            DateTime exp2 = new DateTime(2021, 11, 30);
            Entree cheez = new Entree(txt2, exp2, false, false);

            Vendor snacks = new Vendor("Snack Bar", false);
            snacks.load(cookie, 12, 2.00);
            snacks.load(cheez, 5, 1.50);

            // Act
            bool actual = snacks.isStocked("Cheez It");

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_isStocked_vendor_false()
        {
            // Arrange
            string txt1 = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp1 = new DateTime(2022, 5, 1);
            Entree cookie = new Entree(txt1, exp1, false, false);

            string txt2 = "Cheez It	1	140	7	1.5	0	0	210	16	0	0	3	\"Enriched flour(wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable oil(high oleic soybeen, soybean, palm, canola oil) $ cheese(skim milk, whey protein, salt, cheese cultrures, enzymes, annatto extract color) \"	salt$paprika$yeast$paprika extract color$ soy lecithin";
            DateTime exp2 = new DateTime(2021, 11, 30);
            Entree cheez = new Entree(txt2, exp2, false, false);

            string txt3 = "Welch's Fruit Snacks Mixed Fruit	1	70	0	0	0	0	20	17	0	10	1	\"Fruit Puree(Grape, Peach, Orange, Strawberry, Raspberry)$corn syrup$gelatin$concord grape juice from concentrate$citric acid$lactic acid$natural and artifical flavors$ascorbic acid(vitamin C)$alpha tocopherol actate(vitamin e)$vitamin A palmitate$ sodium citrate$coconut oil$carnauba wax$annatto(color)$turmeric(color)$red 40$blue 1\"";
            DateTime exp3 = new DateTime(2001, 10, 30);
            Entree old = new Entree(txt3, exp3, false, false);


            Vendor snacks = new Vendor("Snack Bar", false);
            snacks.load(cookie, 12, 2.00);
            snacks.load(cheez, 5, 1.50);
            snacks.load(old, 3, .50);

            // Act
            bool actual = snacks.isStocked("Welch's Fruit Snacks Mixed Fruit");

            // Assert
            Assert.AreEqual(false, actual);

        }

    }
}
