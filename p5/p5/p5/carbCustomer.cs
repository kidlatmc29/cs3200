using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
    // Class invarients: 
    //  - carbCustomer has a daily max carbs intake of 30 g
    //  - when buying one or multiple items, the current item's carbs cannot make the dailyCarbs over 30 g
    //  - inherits customer attributes 

    // Interface invarients:
    //  - all getters and mutators are inherited from Customer class
    // - For buyOne and buy the client should be responsible for passing in an instatiated vendor or customer's will not buy anything
    // - Client is not expected to save the boolean returned from buyOne or buy, but can use this result as necessary
    // - Both buyOne will work as expected as long as the itemName the client give is exactly as it is saved in the Entree

    // Implementation invarients: 
    //  - when a carbCustomer is created, the dailyCarbs's value starts at 0
    //  - dailyCarbs is a const and cannot be modified by the client 

    public class carbCustomer : Customer
    {
        private const double MAX_CARBS = 30;
        private double dailyCarbs;

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: One item's price has been subtracted from the carbCustomer's balance
        // or the purchase was not made so no change to the balance 
        public carbCustomer(uint accountNum = 0, double balance = 0) : base(accountNum, balance)
        {
            dailyCarbs = 0;
        }

        public override bool buyOne(Vendor market, string itemName)
        {
            bool sold = false;
            if (dailyCarbs < MAX_CARBS && market.isStocked(itemName))
            {
                double itemCarbs = Convert.ToDouble(market.getItemCarbs(itemName));
                double itemPrice = market.getItemPrice(itemName);
                if (itemCarbs + dailyCarbs <= MAX_CARBS && currentBalance >= itemPrice)
                {
                    market.sell(itemName);
                    currentBalance -= itemPrice;
                    dailyCarbs += itemCarbs;
                    sold = true;
                }
            }
            return sold;
        }

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: Multiple items' prices have been subtracted from carbCustomer's balance
        // or no items were purchased so no change to the balance
        public override bool buy(Vendor market)
        {
            bool sold = false;
            if (market.getSize() > 0)
            {
                for (int i = 0; i < market.getSize(); i++)
                {
                    string itemName = market.getItemName(i);
                    if (market.isStocked(itemName))
                    {
                        double itemCarbs = Convert.ToDouble(market.getItemCarbs(itemName));
                        double itemPrice = market.getItemPrice(itemName);
                        if (dailyCarbs + itemCarbs <= MAX_CARBS)
                        {
                            if (currentBalance >= itemPrice)
                            {
                                market.sell(itemName);
                                currentBalance -= itemPrice;
                                dailyCarbs += itemCarbs;
                                sold = true;
                            }
                        }
                    }
                }
            }
            return sold;
        }

        // PRE: N/A
        // POST: N/A
        public double getDailyCarbs()
        {
            return dailyCarbs;
        }

        // PRE: N/A  
        // POST: dailySugar is set to 0
        public void resetDailyCarbs()
        {
            dailyCarbs = 0;
        }
    }
}
