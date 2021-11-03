using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{
    // Class invarients:

    // Interface invarients:

    // Implementation invarients:
    public class allergyCustomer : Customer
    {
        private List<string> allergens;

        public allergyCustomer(uint accountNum = 0, double balance = 0) : base(accountNum, balance)
        {
            allergens = new List<string>(); 
        }

        // PRE: allergen is written exactly as it is in the ingredience list 
        // POST: adds 1 allergen to allergens list
        public void addAllergen(string allergen)
        {
            allergens.Add(allergen);
        }

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: One item's price has been subtracted from the carbCustomer's balance
        // or the purchase was not made because item contained allergen so no change to the balance 
        public override bool buy(Vendor market, string itemName)
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
    }
}
