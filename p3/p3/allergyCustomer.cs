using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{
    // Class invarients:

    // Interface invarients:

    // Implementation invarients:
    class allergyCustomer : Customer
    {
        private List<string> allergens;

        public allergyCustomer(uint accountNum = 0, double balance = 0) : base(accountNum, balance)
        {
            allergens = null; 
        }

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: One item's price has been subtracted from the carbCustomer's balance
        // or the purchase was not made because item contained allergen so no change to the balance 
        public override bool buy(Vendor market, string itemName)
        {
            bool hasAllergen = true; 
            if (market != null)
            {
                int itemIndex = market.findIndex(itemName);
                hasAllergen = market.hasIngredient(itemIndex, itemName);

                if(!hasAllergen)
                {
                    double itemPrice = market.getItemPrice(itemName);
                    if(currentBalance >= itemPrice)
                    {
                        market.sell(itemName);
                        currentBalance -= itemPrice; 
                    }
                }
            }
            return hasAllergen; 
        }
    }
}
