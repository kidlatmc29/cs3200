using System; 
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p3
{
    [TestClass]
    public class entreeTest
    {
        [TestMethod]
        public void Test_getName_entree_true()
        { 
            //Arrange
            string txt = "Grandma's Chocolate Chip Cookies	2	200	10	4	0	0	125	25	1	12	2	\"Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors\"	egg$milk$soy$wheat";
            DateTime exp = new DateTime(2022,5,1);
            Entree obj = new Entree(txt, exp, false, false);
            string expected = "Grandma's Chocolate Chip Cookies";
            //Act
            string actual = obj.getName(); 

            // Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
