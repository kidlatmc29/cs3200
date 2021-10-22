// customer.h
// Isabel Ovalles

#ifndef CUSTOMER_H
#define CUSTOMER_H

#include <memory>
#include "vendor.h"

// Class invarients:
// - Customer has an account number and a current balance
// - If no parameters are given when ctor is called, default values are given
//    to accountNum and currentBalance

// Interface invarients:
// - Customers can be created without specifying account number or getCurrentBalance
//    These values can be set after instantiation

// Implementation invarients:

class Customer
{
  private:
    unsigned int accountNum;
    float currentBalance;

  public:
    Customer(int accountNum = 0, float currentBalance = 0.0);

    ~Customer();

    // PRE: N/A
    // POST: Adds given amount of money to Customer's currentBalance
    void addMoney(float amount = 0.0);

    // PRE: The item's name that Customer wants to buy is written exactly as it
    //        is saved in Entree name
    // POST: Subtracts price of item bought from Customer's balance,
    //        returns true, else false
    bool buyEntree(shared_ptr<Vendor> market, string entreeName = "");

    // PRE: N/A
    // POST: N/A
    float getCurrentBalance();

    // PRE: N/A
    // POST: N/A
    int getAccountNum();

    // PRE: N/A
    // POST: accountNum is set to num
    void setAccountNum(int num);
};

#endif
