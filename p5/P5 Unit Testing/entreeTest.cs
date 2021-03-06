using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p5
{
    [TestClass]
    public class entreeTest
    {
        [TestMethod]
        public void Test_getName_entree_true()
        {
            // Arrange
            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022, 5, 1);
            Entree obj = new Entree(txt, exp, false, false);
            string expected = "Grandma's Chocolate Chip Cookies";

            // Act
            string actual = obj.getName();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_isExpired_entree_true()
        {
            // Arrange
            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2021, 10, 10);
            Entree obj = new Entree(txt, exp, false, false);

            // Act
            bool actual = obj.isExpired();

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_isExpired_entree_false()
        {
            // Arrange
            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022, 10, 10);
            Entree obj = new Entree(txt, exp, false, false);

            // Act
            bool actual = obj.isExpired();

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Test_isSpoiled_entree_true()
        {
            // Arrange
            string txt = "Fresh Brand - Sliced Apples	2.5	70	0	0	0	0	0	19	3	15	0	apples";
            DateTime exp = new DateTime(2021, 12, 31);
            Entree obj = new Entree(txt, exp, true, false);

            // Act
            bool actual = obj.isSpoiled();

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_isSpoiled_entree_false()
        {
            // Arrange
            string txt = "Skinny Pop Popcorn	1	100	6	0.5	0	9	45	9	9	0	2	Popcorn$Sunflower oil$salt";
            DateTime exp = new DateTime(2022, 1, 13);
            Entree obj = new Entree(txt, exp, false, false);

            // Act
            bool actual = obj.isSpoiled();

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Test_powerOut_isSpoiled_entree_true()
        {
            // Arrange
            string txt = "Horizon Organic Whole Milk	1	150	8	5	0	35	130	13	0	12	8	Grade A Organic Milk$Vitamin D3	milk";
            DateTime exp = new DateTime(2022, 10, 10);
            Entree obj = new Entree(txt, exp, true, true);

            // Act
            obj.powerOut();
            bool actual = obj.isSpoiled();

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_powerOut_isSpoiled_entree_false()
        {
            // Arrange
            string txt = "Fritos Original Corn Chips	1	160	10	1.5	0	0	170	16	1	0	2	Corn$Corn oil$salt";
            DateTime exp = new DateTime(2022, 10, 10);
            Entree obj = new Entree(txt, exp, false, false);

            // Act
            obj.powerOut();
            bool actual = obj.isSpoiled();

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void Test_hasIngredient_entree_true()
        {
            // Arrange
            string txt = "Planters Nuts on the Go Salted Peanuts	1	170	14	2	0	0	95	5	2	1	7	Peanuts$Peanut and/or Cottonseed oil$sea salt	peanuts";
            DateTime exp = new DateTime(2022, 10, 10);
            Entree obj = new Entree(txt, exp, false, false);

            // Act
            bool actual = obj.hasIngredient("Peanuts");

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void Test_hasIngredient_entree_false()
        {
            // Arrange
            string txt = "Planters Nuts on the Go Salted Peanuts	1	170	14	2	0	0	95	5	2	1	7	Peanuts$Peanut and/or Cottonseed oil$sea salt	peanuts";
            DateTime exp = new DateTime(2022, 10, 10);
            Entree obj = new Entree(txt, exp, false, false);

            // Act
            bool actual = obj.hasIngredient("carrots");

            // Assert
            Assert.AreEqual(false, actual);
        }
    }
}
