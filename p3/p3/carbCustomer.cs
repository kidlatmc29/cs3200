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

        public void buyOne()
        {

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
