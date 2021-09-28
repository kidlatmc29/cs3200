// Isabel Ovalles
// 09/23/2021

using System;
using System.Collections.Generic; 

namespace PA1
{
    public class Entree 
    {
        // Class invarients:
        private const int NUM_OF_SERVINGS_INDEX = 0;
        private const int CALORIES_INDEX = 1;
        private const int TOTAL_FAT_INDEX = 2;
        private const int SAT_FAT_INDEX = 3;
        private const int TRANS_FAT_INDEX = 4;
        private const int CHOLEST_INDEX = 5;
        private const int SODIUM_INDEX = 6;
        private const int TOT_CARBS_INDEX = 7;
        private const int FIBER_INDEX = 8;
        private const int TOT_SUGAR_INDEX = 9;
        private const int PROTIEN_INDEX = 10;
        private const int TOTAL_NUTR_STATS = 11; 

        private string name;
        private List<string> ingredients;
        private List<string> nutritionStats;
        
        private DateTime expirationDate;
        private bool refrigerated;
        private bool needsRefrigeration;
        private bool spoiled; 
        

        public Entree(string name, List<string> ingredients, List<double> nutritionStats)
        {
            this.name = name;
            this.ingredients = ingredients;
            this.nutritionStats = nutritionStats;

            expirationDate = createExperiationDate();
            refrigerated = true;
            needsRefrigeration = true;
            spoiled = false;
        }

        public Entree(string txtLine)
        {
            string[] data = txtLine.Split('\t');
            string[] ingredientsBuffer = data[12].Split('$'); // index of data is assumming the input file was formatting correctly 

            name = data[0];

            for(int i = 1; i < TOTAL_NUTR_STATS; i++)
            {
                nutritionStats.Add(data[i]);
            }
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

        public void printNutritionStats()
        {
            Console.WriteLine("Nutrition Facts:");
            for(int i = 0; i < nutritionStats.Count; i++)
            {
                Console.WriteLine(nutritionStats[i] + "\n");
            }
            
        }

        public string getNumOfServings()
        {
            return nutritionStats[NUM_OF_SERVINGS_INDEX];
        }

        public string getCals()
        {
            return nutritionStats[CALORIES_INDEX];
        }

        public string getTotalFat()
        {
            return nutritionStats[TOTAL_FAT_INDEX];
        }

        public string getSFat()
        {
            return nutritionStats[SAT_FAT_INDEX];
        }

        public string getTFat()
        {
            return nutritionStats[TRANS_FAT_INDEX];
        }

        public string getCholest()
        {
            return nutritionStats[CHOLEST_INDEX];
        }
        public string getSodium()
        {
            return nutritionStats[SODIUM_INDEX];
        }

        public string getTotalCarbs()
        {
            return nutritionStats[TOT_CARBS_INDEX];
        }

        public string getFiber()
        {
            return nutritionStats[FIBER_INDEX];
        }

        public string getTotalSugar()
        {
            return nutritionStats[TOT_SUGAR_INDEX];
        }

        public string getProtein()
        {
            return nutritionStats[PROTIEN_INDEX];
        }

        public DateTime getExpirationDate()
        {
            return expirationDate;
        }
        public bool isExpired()
        { 
            return (expirationDate < DateTime.Today); 
        }

        public bool isSpoiled()
        {
            // if isExpired is true, then spoiled is true
            // if isRefrigerated false and requires refridgeration is true
            if(isExpired() == true || (refrigerated == false && needsRefrigeration == true))
            {
                spoiled = true;
            }
            return spoiled;
        }

    }
}

// Implementation invarients: