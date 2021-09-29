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
        public Entree(string name, List<string> ingredients, List<string> nutritionStats) // only for unit tests
        {
            this.name = name;
            this.ingredients = ingredients;
            this.nutritionStats = nutritionStats;

            expirationDate = createExpiriationDate();
            refrigerated = randBoolGen();
            needsRefrigeration = randBoolGen();
            spoiled = isSpoiled();
        }

        // PRE:
        // POST:
        private DateTime createExpiriationDate()
        {
            Random generator = new Random();
            DateTime lowerBounds = new DateTime(2020, 1, 1); // oldest expiration date is Jan 1st, 2020
            DateTime upperBounds = new DateTime(2030, 1, 1); // latest expiration date is Jan 1st, 2030
            int range = (upperBounds - lowerBounds).Days;

            return lowerBounds.AddDays(generator.Next(range)); 
        }

        // PRE:
        // POST:
        private bool randBoolGen()
        {
            Random generator = new Random();
            int range = 2; 
            return (generator.Next(range) == 1);
        }
    
        // PRE:
        // POST: 
        public string getName()
        {
            return name; 
        }

        // PRE:
        // POST: 
        public void printIngredients()
        {
            Console.WriteLine("Ingredients:\n"); 
            for(int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine(ingredients[i] + "\n");
            }
        }

        // PRE:
        // POST: 
        public void printNutritionStats()
        {
            Console.WriteLine("Nutrition Facts:");
            for(int i = 0; i < nutritionStats.Count; i++)
            {
                Console.WriteLine(nutritionStats[i] + "\n");
            }
            
        }

        // PRE:
        // POST:
        public string getNumOfServings()
        {
            return nutritionStats[NUM_OF_SERVINGS_INDEX];
        }

        // PRE:
        // POST:
        public string getCals()
        {
            return nutritionStats[CALORIES_INDEX];
        }

        // PRE:
        // POST:
        public string getTotalFat()
        {
            return nutritionStats[TOTAL_FAT_INDEX];
        }

        // PRE:
        // POST:
        public string getSFat()
        {
            return nutritionStats[SAT_FAT_INDEX];
        }

        // PRE:
        // POST:
        public string getTFat()
        {
            return nutritionStats[TRANS_FAT_INDEX];
        }

        // PRE:
        // POST:
        public string getCholest()
        {
            return nutritionStats[CHOLEST_INDEX];
        }

        // PRE:
        // POST:
        public string getSodium()
        {
            return nutritionStats[SODIUM_INDEX];
        }

        // PRE:
        // POST:
        public string getTotalCarbs()
        {
            return nutritionStats[TOT_CARBS_INDEX];
        }

        // PRE:
        // POST:
        public string getFiber()
        {
            return nutritionStats[FIBER_INDEX];
        }

        // PRE:
        // POST:
        public string getTotalSugar()
        {
            return nutritionStats[TOT_SUGAR_INDEX];
        }

        // PRE:
        // POST:
        public string getProtein()
        {
            return nutritionStats[PROTIEN_INDEX];
        }

        // PRE:
        // POST:
        public DateTime getExpirationDate()
        {
            return expirationDate;
        }

        // PRE:
        // POST:
        public bool getNeedsRefrigeration()
        {
            return needsRefrigeration;
        }

        // PRE:
        // POST:
        public bool isExpired()
        { 
            return (expirationDate < DateTime.Today); 
        }

        // PRE:
        // POST:
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

        // PRE:
        // POST:
        public void powerOut()
        {
            refrigerated = false;
            if(needsRefrigeration == true)
            {
                spoiled = true;
            }
        }

        // PRE:
        // POST:
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