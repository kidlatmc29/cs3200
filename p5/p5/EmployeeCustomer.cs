using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
    // Class invarients:
    // Interface invarients:
    // Implementation invarients: 
    public class EmployeeCustomer : IEmployee, ICustomer
    {
        const int MAX_PAYLVL = 3;
        const int MIN_PAYLVL = 1;
        const double PAY_1 = 150.00;
        const double PAY_2 = 300.00;
        const double PAY_3 = 400.00;
        private string fName;
        private string lName;
        private int payLvl;
        private double accountBalance;
        private string employer;
        private double paycheck;

        ICustomer c;
        public EmployeeCustomer()
        {
            c =  new Customer();
            fName = "N/A";
            lName = "N/A";
            payLvl = MIN_PAYLVL;
            accountBalance = 0.0;
            employer = "N/A";
            paycheck = PAY_1; 
        }
        
        public EmployeeCustomer(string fName, string lName, int payLvl, string employer, ICustomer c) 
        {
            this.fName = fName;
            this.lName = lName;
            this.payLvl = payLvl;
            accountBalance = 0.0;
            this.employer = employer;

            if(c == null)
            {
                c = new Customer(); 
            } else
            {
                this.c = c; 
            }
        }

        public void addMoney(double amount)
        {
            c.addMoney(amount);
        }

        public bool buy(Vendor market)
        {
            Console.WriteLine("buying from EmployeeCustomer!"); 
            return c.buy(market);
        }

        public bool buyOne(Vendor market, string itemName)
        {
            Console.WriteLine("buyingOne from EmployeeCustomer!");
            return c.buyOne(market, itemName);
        }

        public double getCurrentBalance()
        {
            return c.getCurrentBalance(); 
        }

        public uint getAccountNum()
        {
            return c.getAccountNum();
        }

        // PRE: N/A
        // POST: accountNum is set to num
        public void setAccountNum(uint num)
        {
            c.setAccountNum(num);
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
            if (payLvl >= MIN_PAYLVL && payLvl <= MAX_PAYLVL)
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
            if (payLvl == 0)
            {
                accountBalance += paycheck;
            }
            else if (payLvl == 1)
            {
                accountBalance += paycheck;
            }
            else
            {
                accountBalance += paycheck;
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
        // POST: substracts the amount in deduction from the weekly paycheck
        public void adjustPaycheck(double deduction)
        {
           if(paycheck - deduction > 0)
            {
                paycheck -= deduction;
            }
        }

        // PRE: N/A 
        // POST: resets paycheck back to the specific pay lvl
        public void setPay()
        {
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
        }
    }
}
