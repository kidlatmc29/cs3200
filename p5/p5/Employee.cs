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
        private string fName;
        private string lName;
        private int payLvl;
        private double accountBalance;
        private string employer;

        Employee()
        {
            fName = "N/A";
            lName = "N/A";
            payLvl = MIN_PAYLVL;
            accountBalance = 0.0;
            employer = "N/A"; 
        }

        Employee(string fName, string lName, int payLvl = 1, double accountBalance = 0.0, string employer = "N/A")
        {
            this.fName = fName;
            this.lName = lName; 
            this.payLvl = payLvl;
            this.accountBalance = accountBalance;
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
    }
}
