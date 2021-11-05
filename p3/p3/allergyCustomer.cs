﻿using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{
    // Class invarients:
    // - allergyCustomer has allergens that are saved
    // - - all allergens must be unique 
    // - upon instatiation the allergen list does not have any allergens in it
    // - allergyCustomer can buyOne() or buy() as long as the item does not contain any of the allergens provided in the allergen list
    // - inherits customer attributes

    // Interface invarients:
    //  - all getters and mutators are inherited from Customer class
    //  - client is responsible for adding allergens to the allergyCustomer once it has been instantiated
    // - For buyOne and buy the client should be responsible for passing in an instatiated vendor or customer's will not buy anything
    // - Client is not expected to save the boolean returned from buyOne or buy, but can use this result as necessary
    // - Both buyOne will work as expected as long as the itemName the client give is exactly as it is saved in the Entree

    // Implementation invarients:
    //  - allergens is saved using a list

    public class allergyCustomer : Customer
    {
        private List<string> allergens;

        public allergyCustomer(uint accountNum = 0, double balance = 0) : base(accountNum, balance)
        {
            allergens = new List<string>(); 
        }

        // PRE: allergen is written exactly as it is in the ingredient list list 
        // POST: adds 1 allergen to allergens list unless it's already in the list
        public void addAllergen(string allergen)
        {
            if (!allergens.Contains(allergen))
            {
                allergens.Add(allergen);
            }
        }

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: One item's price has been subtracted from the carbCustomer's balance
        // or the purchase was not made because item contained allergen so no change to the balance 
        public override bool buyOne(Vendor market, string itemName)
        {
            bool hasAllergen = true;
            bool sold = false; 
            if (market != null)
            {
                int itemIndex = market.findIndex(itemName);
                hasAllergen = market.hasIngredient(itemIndex, itemName);

                if(!hasAllergen && itemIndex > -1)
                {
                    double itemPrice = market.getItemPrice(itemName);
                    if(currentBalance >= itemPrice)
                    {
                        market.sell(itemName);
                        currentBalance -= itemPrice;
                        sold = true; 
                    }
                }
            }
            return sold; 
        }

        public override bool buyOne(Vendor market)
        {
            bool sold = false;
            bool hasAllergen = true;
            if (market != null)
            {
                int itemIndex = market.findIndex(itemName);
                hasAllergen = market.hasIngredient(itemIndex, itemName);

                if (!hasAllergen && itemIndex > -1)
                {
                    double itemPrice = market.getItemPrice(itemName);
                    if (currentBalance >= itemPrice)
                    {
                        market.sell(itemName);
                        currentBalance -= itemPrice;
                        sold = true;
                    }
                }
            }
            return sold;
        }
   
        public string getAllergens()
        {
            string allergies = ""; 
            for(int i = 0; i < allergens.Count; i++)
            {
               allergies += allergens[i] + '\n';
            }
            return allergies; 
        }
    }
}
