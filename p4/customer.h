// customer.h
// Isabel Ovalles

#ifndef CUSTOMER_H
#define CUSTOMER_H

#include <memory>
#include <string>
#include "vendor.h"

// Class invarients:
// - Customer has an account number and a current balance
// - If no parameters are given when ctor is called, default values are given
//    to accountNum and currentBalance
// - Customers can buyOne() item from a Vendor, given a Vendor and the itemName
// - Customer can buy() multiple items from a Vendor, given a Vendor

// Interface invarients:
// - Customers can be created without specifying account number or
//      currentBalance
// - These values can be set after instantiation
// - For buyOne and buy the client should be responsible for passing in an
//     instatiated vendor or customer's will not buy anything
// - Client is not expected to save the boolean returned from buyOne or buy,
//     but can use this result as necessary
// - Both buyOne will work as expected as long as the itemName the client give
//     is exactly as it is saved in the Entree

// Implementation invarients:
// -If no parameters are given when ctor is called, default values are given
//    to accountNum and currentBalance
// - currentBalance is saved within class, can be requested by client through
//    a getters
// - if client gives a negative number to add to currentBalance, it will not
//    affect currentBalance

class Customer
{
  protected:
    unsigned int accountNum;
    float currentBalance;

  public:
    Customer(int accountNum = 0, float currentBalance = 0.0);

    ~Customer();

    // PRE: N/A
    // POST: Adds given amount of money to Customer's currentBalance
    void virtual addMoney(float amount = 0.0);

    // PRE: The item's name that Customer wants to buy is written exactly as it
    //        is saved in Entree name
    // POST: Subtracts price of item bought from Customer's balance,
    //        returns true, else false
    bool virtual buyOne(shared_ptr<Vendor> market, string entreeName = "");

    // PRE: N/A
    // POST: Subtracts price of items bought from Customer's balance,
    //        returns true when one or more items were bought, else false
    bool virtual buy(shared_ptr<Vendor> market);

    // PRE: N/A
    // POST: N/A
    float virtual getCurrentBalance();

    // PRE: N/A
    // POST: N/A
    int virtual getAccountNum();

    // PRE: N/A
    // POST: accountNum is set to num
    void virtual setAccountNum(unsigned int num);
};

#endif
