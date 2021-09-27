// Isabel Ovalles
// 09/23/2021

using System;
using System.Collections.Generic; 

namespace PA1
{
    public class Entree 
    {
        // Class invarients:
        private string name;
        private List<string> ingredients;
        private List<float> nutritionStats;
        
        private DateTime expirationDate;
        private bool refrigerated;
        private bool needsRefrigeration;
        private bool spoiled; 
        
        public Entree(string name)
        {
            this.name = name;
        }

        public Entree(string name, List<string> ingredients, List<float> nutritionStats)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.nutritionStats = nutritionStats;

            expirationDate = createExperiationDate();
            refrigerated = true;
            needsRefrigeration = true;
            spoiled = false;
        }

        // PRE:
        // POST:
        private DateTime createExperiationDate()
        {
            Random generator = new Random();

            DateTime lowerBounds = new DateTime(2020, 1, 1); // oldest expiration date is Jan 1st, 2020
            DateTime upperBounds = new DateTime(2030, 1, 1); // latest expiration date is Jan 1st, 2030
            int range = (upperBounds - lowerBounds).Days;

            return lowerBounds.AddDays(generator.Next(range)); 
        }
    
        // PRE:
        // POST: 
        public string getName()
        {
            return name; 
        }

        public void printIngredients()
        {
            Console.WriteLine("Ingredients:\n"); 
            for(int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine(ingredients[i] + "\n");
            }
        }

        public float getNumOfServings()
        {
            return 1;
        }

        public uint getCals()
        {
            return 0;
        }

        public uint getTotalFat()
        {
            return 0;
        }

        public float getSFat()
        {
            return 0;
        }

        public uint getTFat()
        {
            return 0;
        }

        public uint getCholest()
        {
            return 0;
        }
        public uint getSodium()
        {
            return 0;
        }

        public uint getTotalCarbs()
        {
            return 0;
        }

        public uint getFiber()
        {
            return 0;
        }

        public uint getTotalSugar()
        {
            return 0;
        }

        public uint getProtein()
        {
            return 0;
        }

        public DateTime getExpirationDate()
        {
            return expirationDate;
        }
        public bool isExpired()
        {
            return false; 
        }

        public bool isSpoiled()
        {
            // if isExpired is true, then spoiled is true
            return spoiled;
        }

    }
}

// Implementation invarients: