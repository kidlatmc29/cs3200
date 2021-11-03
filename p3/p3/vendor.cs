using System;
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
        public int findIndex(string itemName)
        {
            bool found = false; 
            int index = 0;
            int foundIndex = -1; 
            if (!isEmpty())
            {
                while (!found && index != stock.Count)
                {
                    found = stock[index].food.getName() == itemName && !stock[index].food.isSpoiled();
                    if (found)
                    {
                        foundIndex = index; 
                    }
                    index++;
                }
            }
            return foundIndex; 
        }

        public Vendor(string name, bool isRefrigerator)
        {
            this.name = name;
            this.isRefrigerator = isRefrigerator;
            stock = null;
        }

        // PRE:
        // POST: 
        public void load(Entree food, int qty, double price)
        {
            if(stock == null)
            {
                stock = new List<Item>(); 
            }

            Item a = new Item(food, qty, price);

            stock.Add(a); 
        }

        // PRE:
        // POST: 
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

        // PRE:
        // POST: 
        public bool isStocked(string itemName)
        {
            return findIndex(itemName) >= 0 ; 
        }

        // PRE:
        // POST: 
        public void poweroutage()
        {
            if (!isEmpty() && isRefrigerator)
            {
                for (int i = 0; i < stock.Count; i++)
                {
                    stock[i].food.powerOut();
                }
            }
        }

        // PRE:
        // POST: 
        public void sell(string entreeName)
        {
            int itemIndex = findIndex(entreeName);
            if(itemIndex >= 0)
            {
                stock[itemIndex] = new Item(stock[itemIndex].food, stock[itemIndex].qty - 1, stock[itemIndex].price); 
            } 
        }

        // PRE: itemName is exactly what is saved in Entree's name
        // POST: N/A
        public double getItemPrice(string itemName)
        {
            double itemPrice = -1;
            int itemIndex = findIndex(itemName);
            if(itemIndex >= 0)
            {
                itemPrice = stock[itemIndex].price; 
            }
            return itemPrice;
        }

        // PRE: itemName is exactly what is saved in Entree's name
        // POST: N/A 
        public int getItemQuantity(string itemName)
        {
            int itemQty = 0;
            int itemIndex;
            if(!isEmpty())
            {
                if(isStocked(itemName))
                {
                    itemIndex = findIndex(itemName);
                    itemQty = stock[itemIndex].qty;
                }
            }
            return itemQty; 
        }

        // PRE: N/A 
        // POST: N/A
        public string getItemName(int index)
        {
            return stock[index].food.getName(); 
        }

        // PRE: itemName is exactly what is saved in Entree's name
        // POST: N/A
        public string getItemCarbs(string itemName)
        {
            string itemCarbs = "0";
            int itemIndex;
            if (!isEmpty())
            {
                if (isStocked(itemName))
                {
                    itemIndex = findIndex(itemName);
                    itemCarbs = stock[itemIndex].food.getTotalCarbs();
                }
            }
            return itemCarbs;
        }

        // PRE: itemName is exactly what is saved in Entree's name
        // POST: N/A
        public string getItemSugar(string itemName)
        {
            string itemSugar = "0";
            int itemIndex;
            if (!isEmpty())
            {
                if (isStocked(itemName))
                {
                    itemIndex = findIndex(itemName);
                    itemSugar = stock[itemIndex].food.getTotalSugar();
                }
            }
            return itemSugar;
        }

        // PRE: N/A 
        // POST: N/A
        public string getName()
        {
            return name; 
        }

        // PRE: N/A 
        // POST: N/A
        public int getSize()
        {
            return stock.Count; 
        }
    }
}
