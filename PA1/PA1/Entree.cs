// Isabel Ovalles
// Entree.cs
// 09/23/2021
// CPSC 3200

using System;
using System.Collections.Generic; 

namespace PA1
{ 
    public class Entree 
    {
        // Class and Interface invarients:
        //  -An Entree object holds a list of ingredients, nutrition facts, and contains of allergens
        //  -An Entree object holds an expiration date
        //  -Cannot get any member variable unless Entree is initalized
        
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
        private List<string> ingredients = new List<string>();
        private List<string> nutritionStats = new List<string>();
        private List<string> contains = new List<string>();
        
        private DateTime expirationDate;
        private bool needsRefrigeration;

        private bool refrigerated;
        private bool spoiled; 

        public Entree(string txtLine)
        {
            string[] data = txtLine.Split('\t');
            string[] ingredientsBuffer = data[12].Split('$'); // index of specific data is assumming the input file was formatted correctly 
            string[] containsBuffer = data[13].Split('$');

            name = data[0];

            for(int i = 1; i < TOTAL_NUTR_STATS; i++)
            {
                nutritionStats.Add(data[i]);
            }

            for(int i = 0; i < ingredientsBuffer.Length; i++)
            {
                ingredients.Add(ingredientsBuffer[i]);
            }

            for(int i = 0; i < containsBuffer.Length; i++)
            {
                contains.Add(containsBuffer[i]);
            }

            expirationDate = createExpiriationDate();
            needsRefrigeration = randBoolGen();
            refrigerated = needsRefrigeration;
            spoiled = isSpoiled(); 

        }
        public Entree(string name, List<string> ingredients, List<string> nutritionStats, 
                       bool needsRefrigeration,  bool refrigerated) // only for unit tests
        {
            this.name = name;
            this.ingredients = ingredients;
            this.nutritionStats = nutritionStats;

            expirationDate = createExpiriationDate();
            this.refrigerated = refrigerated;
            this.needsRefrigeration = needsRefrigeration;
            spoiled = isSpoiled();
        }

        // PRE: N/A
        // POST: Returns a Datetime object that is in between Jan 1, 2021 to Jan 1, 2030
        private DateTime createExpiriationDate()
        {
            Random generator = new Random();
            DateTime lowerBounds = new DateTime(2020, 1, 1); // oldest expiration date is Jan 1st, 2020
            DateTime upperBounds = new DateTime(2030, 1, 1); // latest expiration date is Jan 1st, 2030
            int range = (upperBounds - lowerBounds).Days;

            return lowerBounds.AddDays(generator.Next(range)); 
        }

        // PRE: N/A
        // POST: Return a random boolean 
        private bool randBoolGen()
        {
            Random generator = new Random();
            int range = 2; 
            return (generator.Next(range) == 1);
        }
    
        // PRE: N/A
        // POST: N/A
        public string getName()
        {
            return name; 
        }

        // PRE: N/A
        // POST: N/A 
        public void printIngredients()
        {
            Console.WriteLine("Ingredients:\n"); 
            for(int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine(ingredients[i] + "\n");
            }
        }

        // PRE: N/A
        // POST: N/A
        public void printNutritionStats()
        {
            Console.WriteLine("Nutrition Facts:");
            for(int i = 0; i < nutritionStats.Count; i++)
            {
                Console.WriteLine(nutritionStats[i] + "\n");
            }
            
        }

        // PRE: N/A
        // POST: N/A
        public string getNumOfServings()
        {
            return nutritionStats[NUM_OF_SERVINGS_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getCals()
        {
            return nutritionStats[CALORIES_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getTotalFat()
        {
            return nutritionStats[TOTAL_FAT_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getSFat()
        {
            return nutritionStats[SAT_FAT_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getTFat()
        {
            return nutritionStats[TRANS_FAT_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getCholest()
        {
            return nutritionStats[CHOLEST_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getSodium()
        {
            return nutritionStats[SODIUM_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getTotalCarbs()
        {
            return nutritionStats[TOT_CARBS_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getFiber()
        {
            return nutritionStats[FIBER_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getTotalSugar()
        {
            return nutritionStats[TOT_SUGAR_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public string getProtein()
        {
            return nutritionStats[PROTIEN_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public DateTime getExpirationDate()
        {
            return expirationDate;
        }

        // PRE: N/A
        // POST: N/A
        public bool getNeedsRefrigeration()
        {
            return needsRefrigeration;
        }

        // PRE: expirationDate is initalized
        // POST: N/A
        public bool isExpired()
        { 
            return (expirationDate < DateTime.Today); 
        }

        // PRE: N/A
        // POST: spoiled might be set to true or false depending
        public bool isSpoiled()
        {
            // if isExpired is true, then spoiled is true
            // if isRefrigerated false and requires refridgeration is true, then spoiled is true
            if (isExpired() == true || (refrigerated == false && needsRefrigeration == true))
            {
                spoiled = true;
            }
            else
            {
                spoiled = false;
            }
            return spoiled;
        }

        // PRE: N/A
        // POST: refrigerated is set to false for the Entree. spoiled maybe set to true
        public void powerOut()
        {
            refrigerated = false;
            if(needsRefrigeration == true)
            {
                spoiled = true;
            }
        }

        // PRE: Assuming target is exactly written like it is on the Ingredients list to be found
        // POST: returns a bool if target is found in Ingredients list
        public bool hasIngredient(string target)
        {
            bool foundIngredient = false;
            
            if(target == "")
            {
                foundIngredient = false; 
            } else
            {
                int count = 0;
                while(foundIngredient == false && count < ingredients.Count)
                {
                    if(target == ingredients[count])
                    {
                        foundIngredient = true;
                    }
                    count++;
                }
            }
            return foundIngredient;
        }
    }
}

// Implementation invarients:
 // -Given list of ingredients and nutrition facts are assumed ordered correctly
 // -Cannot get an nutrience fact since index will never be out of range