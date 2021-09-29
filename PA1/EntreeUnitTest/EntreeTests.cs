// Isabel Ovalles
// EntreeTests.cs
// 09/23/2021
// CPSC 3200

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
            Assert.AreEqual(expected, actual, "The milk is not spoiled, even though it requires refrigeration!");
        }

        [TestMethod]
        public void getCheezItServings()
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
            string expected = "1";

            string actual = CheezIt.getNumOfServings();

            Assert.AreEqual(expected, actual, "The number of servings is incorrect!");
        }

        [TestMethod] 
        public void getCheezItCals()
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
            string expected = "140";

            string actual = CheezIt.getCals();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItTotalFat()
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
            string expected = "7";

            string actual = CheezIt.getTotalFat();

            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void getCheezItSFat()
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
            string expected = "1.5";

            string actual = CheezIt.getSFat();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItTFat()
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
            string expected = "0";

            string actual = CheezIt.getTFat();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItCholest()
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
            string expected = "0";

            string actual = CheezIt.getCholest();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItSodium()
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
            string expected = "210";

            string actual = CheezIt.getSodium();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItTotalCarbs()
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
            string expected = "16";

            string actual = CheezIt.getTotalCarbs();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItFiber()
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
            string expected = "0";

            string actual = CheezIt.getFiber();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItTotalSugar()
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
            string expected = "0";

            string actual = CheezIt.getTotalSugar();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void getCheezItProtien()
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
            string expected = "3";

            string actual = CheezIt.getProtein();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void doesPopcornHaveChocolate()
        {
            List<string> popcornIng = new List<string>();
            popcornIng.Add("Popcorn");
            popcornIng.Add("Sunflower oil");
            popcornIng.Add("salt");

            List<string> popcornNutr = new List<string>();
            popcornNutr.Add("1");
            popcornNutr.Add("100");
            popcornNutr.Add("6");
            popcornNutr.Add("0.5");
            popcornNutr.Add("0");
            popcornNutr.Add("9");
            popcornNutr.Add("45");
            popcornNutr.Add("9");
            popcornNutr.Add("9");
            popcornNutr.Add("0");
            popcornNutr.Add("2");

            Entree popcorn = new Entree("Skinny Pop Popcorn", popcornIng, popcornNutr, false, false);
            bool expected = false;

            bool actual = popcorn.hasIngredient("chocolate");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void doesPlanterNutsHavePeanuts()
        {
            List<string> nutsIng = new List<string>();
            nutsIng.Add("Peanuts");
            nutsIng.Add("Peanut and/or Cottonseed oil");
            nutsIng.Add("sea salt");

            List<string> nutsNutr = new List<string>();
            nutsNutr.Add("1");
            nutsNutr.Add("170");
            nutsNutr.Add("14");
            nutsNutr.Add("2");
            nutsNutr.Add("0");
            nutsNutr.Add("0");
            nutsNutr.Add("95");
            nutsNutr.Add("5");
            nutsNutr.Add("2");
            nutsNutr.Add("1");
            nutsNutr.Add("7");

            Entree peanuts = new Entree("Planters Nuts on the Go Salted Peanuts", nutsIng, nutsNutr, false, false);
            bool expected = true;

            bool actual = peanuts.hasIngredient("Peanuts");

            Assert.AreEqual(expected, actual);
        }
    }

}
