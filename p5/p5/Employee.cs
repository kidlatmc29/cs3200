using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
    // Class invarients:
    // Interface invarients:
    // Implementation invarients: 
   public class Employee : IEmployee
    {
        const int MAX_PAYLVL = 3;
        const int MIN_PAYLVL = 1;
        const double PAY_1 = 12.00;
        const double PAY_2 = 15.00;
        const double PAY_3 = 20.00;
        private string fName;
        private string lName;
        private int payLvl;
        private double accountBalance;
        private string employer;

        public Employee()
        {
            fName = "N/A";
            lName = "N/A";
            payLvl = MIN_PAYLVL;
            accountBalance = 0.0;
            employer = "N/A"; 
        }

        public Employee(string fName, string lName, int payLvl = 1, string employer = "N/A")
        {
            this.fName = fName;
            this.lName = lName; 
            this.payLvl = payLvl;
            accountBalance = 0.0;
            this.employer = employer; 
        }

        // PRE: N/A
        // POST: N/A
        public int getPayLvl()
        {
            return payLvl; 
        }

        // PRE: N/A 
        // POST: payLvl is set to a valid pay level.
        public void setPayLvl(int payLvl)
        {
            if(payLvl >= MIN_PAYLVL && payLvl <= MAX_PAYLVL)
            {
                this.payLvl = payLvl;
            }
        }

        // PRE: N/A 
        // POST: N/A 
        public double getAccountBalance()
        {
            return accountBalance; 
        }

        // PRE: N/A
        // POST: N/A 
        public string getEmployer()
        {
            return employer;
        }

        // PRE: N/A 
        // POST: employer is changed to the value of e. 
        public void setEmployer(string e)
        {
            employer = e; 
        }

        // PRE: N/A 
        // POST: paycheck amount is added to the accountBalance
        public void weeklyPay()
        {
            if(payLvl == 0)
            {
                accountBalance += PAY_1;
            } else if(payLvl == 1)
            {
                accountBalance += PAY_2;
            } else
            {
                accountBalance += PAY_3; 
            }
        }
    }
}
