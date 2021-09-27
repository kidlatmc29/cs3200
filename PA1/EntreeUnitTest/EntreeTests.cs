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
        public void getEntreeName()
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

            List<double> oreoNutr = new List<double>();
            oreoNutr.Add(1);
            oreoNutr.Add(77);
            oreoNutr.Add(3);
            oreoNutr.Add(1);
            oreoNutr.Add(0.3);
            oreoNutr.Add(0);
            oreoNutr.Add(66);
            oreoNutr.Add(12);
            oreoNutr.Add(1);
            oreoNutr.Add(7);
            oreoNutr.Add(1);

            //Act
            cookie = new Entree("Oreos", oreoIng, oreoNutr);

            //Assert
            string actual = cookie.getName();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void isExpired()
        {
            // Arrange 
            List<string> oreoIng = new List<string>();
            oreoIng.Add("Flour");
            oreoIng.Add("Sugar");
            oreoIng.Add("Palm Oil");
            oreoIng.Add("Cocoa");
            oreoIng.Add("High Fructose Corn Syrup");
            oreoIng.Add("Salt");

            List<double> oreoNutr = new List<double>();
            oreoNutr.Add(1);
            oreoNutr.Add(77);
            oreoNutr.Add(3);
            oreoNutr.Add(1);
            oreoNutr.Add(0.3);
            oreoNutr.Add(0);
            oreoNutr.Add(66);
            oreoNutr.Add(12);
            oreoNutr.Add(1);
            oreoNutr.Add(7);
            oreoNutr.Add(1);

            Entree cookie = new Entree("Oreos", oreoIng, oreoNutr);

            bool expected = cookie.getExpirationDate() < DateTime.Today;

            // Act
            bool actual = cookie.isExpired();

            // Assert
            Assert.AreEqual(expected, actual, "Should be expired!");
        }
    }
}
