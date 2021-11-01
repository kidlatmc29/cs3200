﻿using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{
    // Class invarients:
    // -Vendor contains a list of items that represent the Vendor's stock.
    // -It also holds the name of the Vendor and if the Vendor's stock is a
    //    refridgerator
    // -Vendor is instantiated with 0 items to begin with

    // Interface invarients:
    //  - Entree objects must be instantiated before loading them into a Vendor
    // - When instantiating a Vendor object, must provide a name and if it's a
    //    refrigerator in the parameterized ctor for a valid state

    // Implementation invarients:
    //  - Item is implemented as a struct, stock is a list of item structs
    //  -sell is called from the Customer object, see Customer class for checking
    //    validity of purchase
    public class Vendor
    {
        private string name;
        private bool isRefrigerator;
        private List<Item> stock; 

         private struct Item
        {
            public Entree food;
            public int qty;
            public double price; 
            public Item(Entree f, int q, double p)
            {
                food = f;
                qty = q;
                price = p; 
            }
        }

        // helper fxns
        // PRE: N/A 
        // POST: N/A
        private bool isEmpty()
        {
            return stock == null;
        }

        // PRE: itemName is exactly what is saved in Entree's name
        // POST: Returns the index of foundItem, otherwise returns -1
        private int findIndex(string itemName)
        {
            return -1; 
        }

        public Vendor(string name, bool isRefrigerator)
        {
            this.name = name;
            this.isRefrigerator = isRefrigerator;
            stock = null;
        }

        public void load(Entree food, int qty, double price)
        {
            if(stock == null)
            {
                stock = new List<Item>(); 
            }

            Item a = new Item(food, qty, price);

            stock.Add(a); 
        }

        public void cleanStock()
        {
            for (int i = 0; i < stock.Count; i++)
            {
                if (stock[i].food.isSpoiled())
                {
                    stock.RemoveAt(i);
                    i--;
                }
            }
        }

        public bool isStocked(string itemName)
        {
            int index = -1;
            bool found = false;

            while(!found && index != stock.Count)
            {
                index++;
                found = stock[index].food.getName() == itemName; 
            }

            if(stock[index].food.isSpoiled())
            {
                found = false; 
            }

            return found; 
        }

        public void poweroutage()
        {

        }

        public void sell(string entreeName)
        {

        }

        public double getItemPrice(string itemName)
        {
            return 0;
        }

        public string getName()
        {
            return name; 
        }

        public int getSize()
        {
            return stock.Count; 
        }
    }
}
