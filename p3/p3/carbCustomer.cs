using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{

    // Class invarients: 
    // Interface invarients:
    // Implementation invarients: 
    public class carbCustomer : Customer
    {
        private const double MAX_CARBS = 30;
        private double dailyCarbs; 

        public void buyOne(Vendor market, string itemName)
        {
            if (dailyCarbs < MAX_CARBS && market.isStocked(itemName))
            {
                double itemSugar = Convert.ToDouble(market.getItemSugar(itemName));
                double itemPrice = market.getItemPrice(itemName);
                if (itemSugar + dailyCarbs <= MAX_CARBS && currentBalance >= itemPrice)
                {
                    market.sell(itemName);
                    currentBalance -= itemPrice;
                }
            }
        }

        public void buy()
        {

        }

        public double getDailyCarbs()
        {
            return dailyCarbs;
        }

        public void resetDailyCarbs()
        {
            dailyCarbs = 0; 
        }
    }
}
