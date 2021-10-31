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

            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
