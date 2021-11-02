using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{
    public class dbetCustomer : Customer
    {
        // Class invarients: 
        // Interface invarients:
        // Implementation invarients: 

        private const double MAX_SUGAR = 50;
        private const double SINGLE_SUGAR = 10;
        private const double MULTI_SUGAR = 25; 

        private double dailySugar; 

        public dbetCustomer(uint accountNum = 0, double balance = 0) : base(accountNum, balance)
        {
            dailySugar = 0; 
        }

        // PRE:
        // POST:
        public void buyOne(Vendor market, string itemName)
        {
            if(dailySugar < MAX_SUGAR && market.isStocked(itemName))
            {
                double itemSugar = Convert.ToDouble(market.getItemSugar(itemName));
                double itemPrice = market.getItemPrice(itemName); 
                if (itemSugar + dailySugar <= MAX_SUGAR && itemSugar <= SINGLE_SUGAR && currentBalance >= itemPrice)
                {
                    market.sell(itemName);
                    currentBalance -= itemPrice;
                }
            }
        }

        // PRE:
        // POST:
        public void buy(Vendor market)
        {
             while(dailySugar < MAX_SUGAR)
            {

            }
        }
    }
}
