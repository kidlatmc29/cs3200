using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
    // Class invarients:
    //  - Employee has a first name, last name, employeer all stored as strings
    //  - Employee also has a payLvl from 1-3
    //  - Employees have an accountBalance where their weekly pay is deposited, saved as a double
    // Interface invarients:
    //  - Employee implements the methods from IEmployee
    //  - Employees can be instantiated with all attributes given, or none.
    //  - Employee default constructor will set all attributes to "zero" values
    // Implementation invarients: 
    //  - Employees accountBalances is set to $0.00 regardless of how it is instantiated
    //  - weeklyPay() adds the pay to accountBalance, given the current payLvl saved
    public class Employee : IEmployee
    {
        private const int MAX_PAYLVL = 3;
        private const int MIN_PAYLVL = 1;
        private const double PAY_1 = 150.00;
        private const double PAY_2 = 300.00;
        private const double PAY_3 = 400.00;
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
            if(payLvl == 1)
            {
                accountBalance += PAY_1;
            } else if(payLvl == 2)
            {
                accountBalance += PAY_2;
            } else
            {
                accountBalance += PAY_3; 
            }
        }

        // PRE: N/A
        // POST: N/A  
        public string getFName()
        {
            return fName;
        }

        // PRE: N/A
        // POST: N/A
        public string getLName()
        {
            return lName; 
        }

        // PRE: N/A
        // POST: fName is set to new string
        public void setFName(string fName)
        {
            this.fName = fName;
        }

        // PRE: N/A
        // POST: lName is set to new string
        public void setLName(string lName)
        {
            this.lName = lName;
        }

        // PRE: N/A
        // POST: N/A 
        public double viewPaycheck()
        {
            double paycheck = 0.0;
            if (payLvl == 1)
            {
                paycheck = PAY_1;
            }
            else if (payLvl == 2)
            {
                paycheck = PAY_2;
            }
            else
            {
                paycheck = PAY_3;
            }
            return paycheck;
        }
    }
}
