// customer.cs
// Isabel Ovalles

using System;
using System.Collections.Generic;
using System.Text;

// Class invarients:
// - Customer has an account number and a current balance
// - If no parameters are given when ctor is called, default values are given
//    to accountNum and currentBalance

// Interface invarients:
// - Customers can be created without specifying account number or
//    getCurrentBalance
//    These values can be set after instantiation

// Implementation invarients:

namespace p3
{
    public class Customer
    {
        protected uint accountNum;
        protected double currentBalance;

        public Customer(uint num = 0, double balance = 0)
        {
            accountNum = num;
            currentBalance = balance; 
        }

        // PRE: N/A
        // POST: Adds given amount of money to Customer's currentBalance
        public void addMoney(double amount)
        {
            if(amount > 0)
            {
                currentBalance += amount; 
            }
        }

        // PRE: The item's name that Customer wants to buy is written exactly as it
        //        is saved in Entree name
        // POST: Subtracts price of item bought from Customer's balance,
        //        returns true, else false
        public bool buy(Vendor market, string itemName)
        {
            bool sold = false; 
            if(market.isStocked(itemName))
            {
                double itemPrice = market.getItemPrice(itemName);
                if(currentBalance >= itemPrice)
                {
                    market.sell(itemName);
                    currentBalance -= itemPrice;
                    sold = true;
                }
            }
            return sold; 
        }

        // PRE: N/A
        // POST: N/A
        public double getCurrentBalance()
        {
            return currentBalance;
        }

        // PRE: N/A
        // POST: N/A
        public uint getAccountNum()
        {
            return accountNum;
        }

        // PRE: N/A
        // POST: accountNum is set to num
        public void setAccountNum(uint num)
        {
            accountNum = num; 
        }
    }
}
