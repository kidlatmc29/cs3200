using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
    public class dbetCustomer : Customer
    {
        // Class invarients: 
        //  - dbetCustomer has a daily max sugar of 50 g
        //  - -inherits customer attributes 
        //  - When buying one item, total sugar of item must be less than or equal to 10 g
        //  - When buying mutiple items, the total sugar of those items combined must be less than or equal to 25 g

        // Interface invarients:
        //  - all getters and mutators are inherited from Customer class
        // - For buyOne and buy the client should be responsible for passing in an instatiated vendor or customer's will not buy anything
        // - Client is not expected to save the boolean returned from buyOne or buy, but can use this result as necessary
        // - Both buyOne will work as expected as long as the itemName the client give is exactly as it is saved in the Entree

        // Implementation invarients: 
        //  - when a dbetCustomer is created, the dailySugar's value starts at 0
        //  - dailySugar can be only modified using the buy() or buyOne() fxns 
        //  - max daily sugar, sugar limit for one item, and the sugar limit for multiple items are all consts and client cannot change them

        private const double MAX_SUGAR = 50;
        private const double SINGLE_SUGAR = 10;
        private const double MULTI_SUGAR = 25;

        private double dailySugar;

        public dbetCustomer(uint accountNum = 0, double balance = 0) : base(accountNum, balance)
        {
            dailySugar = 0;
        }

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: One item's price has been subtracted from the dbetCustomer's balance
        // or the purchase was not made so no change to the balance 
        public override bool buyOne(Vendor market, string itemName)
        {
            bool sold = false;
            if (dailySugar < MAX_SUGAR && market.isStocked(itemName))
            {
                double itemSugar = Convert.ToDouble(market.getItemSugar(itemName));
                double itemPrice = market.getItemPrice(itemName);
                if (itemSugar + dailySugar <= MAX_SUGAR && itemSugar <= SINGLE_SUGAR)
                {
                    market.sell(itemName);
                    currentBalance -= itemPrice;
                    dailySugar += itemSugar;
                    sold = true;
                }
            }

            return sold;
        }

        // PRE: itemname is written the same way as it is saved in Vendor
        // POST: Multiple items' prices have been subtracted from dbetCustomer's balance
        // or no items were purchased so no change to the balance
        public override bool buy(Vendor market)
        {
            bool sold = false;
            double currentSugar = 0;
            if (market.getSize() > 0)
            {
                for (int i = 0; i < market.getSize(); i++)
                {
                    string itemName = market.getItemName(i);
                    if (market.isStocked(itemName))
                    {
                        double itemSugar = Convert.ToDouble(market.getItemSugar(itemName));
                        double itemPrice = market.getItemPrice(itemName);
                        if (currentSugar + itemSugar <= MULTI_SUGAR && itemSugar + dailySugar <= MAX_SUGAR)
                        {
                            if (currentBalance >= itemPrice)
                            {
                                market.sell(itemName);
                                currentBalance -= itemPrice;
                                dailySugar += itemSugar;
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
        public double getDailySugar()
        {
            return dailySugar;
        }

        // PRE: N/A
        // POST: dailySugar is set to 0
        public void resetDailySugar()
        {
            dailySugar = 0;
        }
    }
}
