﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace p3
{
    // Class invarients:
    // -An Entree object holds a list of ingredients, nutrition facts,
    //    contains of allergens, an expiration date, as well as if it needs
    //    refrigeration and if it is refrigerated.
    // -Entree object will be in a valid state when instantiated with the
    //    parameterized ctor.
    // -Cannot get any member variable unless Entree is initialized.

    // Interface invarients:
    //  -When instantiating an Entree object, the client is responsible for:
    //    1.)  All nutritional facts must be passed to the ctor and be in the correct
    //          order.
    //    2.) The ingredients list and contains must have the $ as the delimiter
    //        between ingredients.

    // Implementation invarients:
    // -isExpired and isSpoiled is not saved as internal states, Client
    //    must request for them

    public class Entree
    {
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
        private const int PROTEIN_INDEX = 10;
        private const int NUM_OF_NUTR_STATS = 11;

        private string name;
        private List<string> ingredients = new List<string>();
        private List<int> nutritionStats = new List<int>();
        private List<string> contains = new List<string>();
        private DateTime expirationDate;
        private bool needsRefridge;
        private bool isRefrigerated;


        public Entree(string txtLine, DateTime expirationDate, bool needsRefridge, bool isRefrigerated)
        {
            List<string> data = txtLine.Split('\t').ToList();
            int count = 0; 
         
            name = data[0];
            data.RemoveAt(0);

            while (count > NUM_OF_NUTR_STATS)
            {
                nutritionStats.Add(Int32.Parse(data[count]));
                count++;
                data.RemoveAt(0);
            }

            List<string> ingredients = data[0].Split('$').ToList();
            data.RemoveAt(0);
            
            if(data.Count > 0)
            {
               List<string> contains = data[0].Split('$').ToList();
            }

            this.expirationDate = expirationDate;
            this.needsRefridge = needsRefridge;
            this.isRefrigerated = isRefrigerated; 
        }

        // PRE: N/A
        // POST: N/A
        public string getName()
        {
            return name; 
        }

        // PRE: N/A
        // POST: N/A
        public int getNumOfServings()
        {
            return nutritionStats[NUM_OF_SERVINGS_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getCals()
        {
            return nutritionStats[CALORIES_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getTotalFat()
        {
            return nutritionStats[TOTAL_FAT_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getSFat()
        {
            return nutritionStats[SAT_FAT_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getTFat()
        {
            return nutritionStats[TRANS_FAT_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getCholest()
        {
            return nutritionStats[CHOLEST_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getSodium()
        {
            return nutritionStats[SODIUM_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getTotalCarbs()
        {
            return nutritionStats[TOT_CARBS_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getFiber()
        {
            return nutritionStats[FIBER_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getTotalSugar()
        {
            return nutritionStats[TOT_SUGAR_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public int getProtein()
        {
            return nutritionStats[PROTEIN_INDEX];
        }

        // PRE: N/A
        // POST: N/A
        public bool isExpired()
        {
            return expirationDate < DateTime.Today; 
        }

        // PRE: N/A
        // POST: N/A
        public bool isSpoiled()
        {
            return ((!isRefrigerated) && needsRefridge) || isExpired();
        }

        // PRE: N/A
        // POST: refrigerated is set to false for the Entree.
        public void powerOut()
        {
            isRefrigerated = false;
        }

        public bool hasIngredient(string target)
        {
            bool foundIngredient = false;

            if (target == "")
            {
                foundIngredient = false;
            }
            else
            {
                int count = 0;
                while (foundIngredient == false && count < ingredients.Count)
                {
                    if (target == ingredients[count])
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
