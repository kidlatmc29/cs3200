// Isabel Ovalles

using System;
using System.Collections.Generic; 

namespace PA1
{
    public class Entree // Class invarients: 
    {
        private string name;
        private List<string> ingredients;

        private List<uint> nutritionStats;
        private uint experationDate;

        private bool isRefrigerated;
        private bool needsRefrigeration;
        private bool isSpoiled; 
        
        public Entree(string entreeName)
        {
            name = entreeName;
        }

        // PRE:
        // POST: 
        public string getName()
        {
            return name; 
        }
    }
}

// Implementation invarients