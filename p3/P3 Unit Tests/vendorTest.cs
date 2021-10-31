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
    }
}
