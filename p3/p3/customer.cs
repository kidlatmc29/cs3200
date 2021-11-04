// customer.cs
// Isabel Ovalles

using System;
using System.Collections.Generic;
using System.Text;

// Class invarients:
// - Customer has an account number and a current balance
// - Customers can buyOne() item from a Vendor, given a Vendor and the itemName
// - Customer can buy() multiple items from a Vendor, given a Vendor

// Interface invarients:
// - Customers can be created without specifying account number or
//    getCurrentBalance
// - These values can be set after instantiation
// - For buyOne and buy the client should be responsible for passing in an instatiated vendor or customer's will not buy anything
// - Client is not expected to save the boolean returned from buyOne or buy, but can use this result as necessary
// - Both buyOne will work as expected as long as the itemName the client give is exactly as it is saved in the Entree

// Implementation invarients:
// -If no parameters are given when ctor is called, default values are given
//    to accountNum and currentBalance
// - currentBalance is saved within class, can be requested by client through a getters
// - if client gives a negative number to add to currentBalance, it will not affect currentBalance

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
        public virtual bool buyOne(Vendor market, string itemName)
        {
            bool sold = false;
            if (market.isStocked(itemName))
            {
                double itemPrice = market.getItemPrice(itemName);
                if (currentBalance >= itemPrice)
                {
                    market.sell(itemName);
                    currentBalance -= itemPrice;
                    sold = true;
                }
            }
            return sold;
        }
        
        // PRE: N/A
        // POST: Subtracts price of items bought from Customer's balance,
        //        returns true when one or more items were bought, else false
        public virtual bool buy(Vendor market)
        {
            bool sold = false;
            if(market != null)
            {
                for(int i = 0; i < market.getSize(); i++)
                {
                    string itemName = market.getItemName(i);
                    double itemPrice = market.getItemPrice(itemName);
                    if(itemPrice <= currentBalance)
                    {
                        market.sell(itemName);
                        currentBalance -= itemPrice;
                        sold = true; 
                    }
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
