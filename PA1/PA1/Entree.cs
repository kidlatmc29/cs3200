// Isabel Ovalles

using System;

namespace PA1
{
    public class Entree // Class invarients: 
    {
        private string name; 
        
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