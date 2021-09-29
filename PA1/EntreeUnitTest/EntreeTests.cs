// Isabel Ovalles

using PA1;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PA1
{
    [TestClass]
    public class EntreeTests
    {
        [TestMethod]
        public void getEntreeCookieName()
        {
            //Arrange 
            string expected = "Oreos";
            Entree cookie;

            List<string> oreoIng = new List<string>();
            oreoIng.Add("Flour");
            oreoIng.Add("Sugar");
            oreoIng.Add("Palm Oil");
            oreoIng.Add("Cocoa");
            oreoIng.Add("High Fructose Corn Syrup");
            oreoIng.Add("Salt");

            List<string> oreoNutr = new List<string>();
            oreoNutr.Add("1");
            oreoNutr.Add("77");
            oreoNutr.Add("3");
            oreoNutr.Add("1");
            oreoNutr.Add("0.3");
            oreoNutr.Add("0");
            oreoNutr.Add("66");
            oreoNutr.Add("12");
            oreoNutr.Add("1");
            oreoNutr.Add("7");
            oreoNutr.Add("1");

            //Act
            cookie = new Entree("Oreos", oreoIng, oreoNutr, false, false);

            //Assert
            string actual = cookie.getName();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void isCookieExpired()
        {
            // Arrange 
            List<string> oreoIng = new List<string>();
            oreoIng.Add("Flour");
            oreoIng.Add("Sugar");
            oreoIng.Add("Palm Oil");
            oreoIng.Add("Cocoa");
            oreoIng.Add("High Fructose Corn Syrup");
            oreoIng.Add("Salt");

            List<string> oreoNutr = new List<string>();
            oreoNutr.Add("1");
            oreoNutr.Add("77");
            oreoNutr.Add("3");
            oreoNutr.Add("1");
            oreoNutr.Add("0.3");
            oreoNutr.Add("0");
            oreoNutr.Add("66");
            oreoNutr.Add("12");
            oreoNutr.Add("1");
            oreoNutr.Add("7");
            oreoNutr.Add("1");

            Entree cookie = new Entree("Oreos", oreoIng, oreoNutr, false, false);

            bool expected = cookie.getExpirationDate() < DateTime.Today;

            // Act
            bool actual = cookie.isExpired();
            Console.WriteLine("isExpired: " + actual + "\n");

            // Assert
           Assert.AreEqual(expected, actual, "Should be expired!");
        }

        [TestMethod]
        public void isMilkSpoiled()
        {
            // Arrange
            List<string> milkIng = new List<string>();
            milkIng.Add("Grade A Organic Milk");
            milkIng.Add("Vitamin D3");

            List<string> milkNutr = new List<string>();
            milkNutr.Add("1");
            milkNutr.Add("150");
            milkNutr.Add("8");
            milkNutr.Add("5");
            milkNutr.Add("0");
            milkNutr.Add("35");
            milkNutr.Add("130");
            milkNutr.Add("0");
            milkNutr.Add("12");
            milkNutr.Add("8");

            Entree milk = new Entree("Horizon Organic Whole Milk", milkIng, milkNutr, true, false);

            bool expected = true;
            // Act

            bool actual = milk.isSpoiled();

            // Assert
            Assert.AreEqual(actual, expected, "The milk is not spoiled, even though it requires refrigeration!");
        }

        [TestMethod]
        public void getCheezItServerings()
        {
            List<string> cheezIng = new List<string>();
            cheezIng.Add("Enriched flour (wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)");
            cheezIng.Add("vegetable oil (high oleic soybeen, soybean, palm, canola oil)");
            cheezIng.Add("salt");
            cheezIng.Add("paprika extract color");
            cheezIng.Add("yeast");
            cheezIng.Add("soy lecithin");

            List<string> cheezNutr = new List<string>();
            cheezNutr.Add("1");
            cheezNutr.Add("140");
            cheezNutr.Add("7");
            cheezNutr.Add("1.5");
            cheezNutr.Add("0");
            cheezNutr.Add("0");
            cheezNutr.Add("210");
            cheezNutr.Add("16");
            cheezNutr.Add("0");
            cheezNutr.Add("0");
            cheezNutr.Add("3");

            Entree CheezIt = new Entree("Cheez It", cheezIng, cheezNutr, false, false);
            string actual = "1";

            string expected = CheezIt.getNumOfServings();

            Assert.AreEqual(actual, expected, "The number of servings is incorrect!");

        }

        [TestMethod] 
        public void getCheezItCals()
        {

        }

        [TestMethod]
        public void getCheezeItTotalFat()
        {

        }
    }

}
