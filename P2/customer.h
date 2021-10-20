// customer.h
// Isabel Ovalles

#ifndef CUSTOMER_H
#define CUSTOMER_H

#include "vendor.h"

// Class invarients:

// Interface invarients:

// Implementation invarients:

class Customer
{
  private:
    unsigned int accountNum;
    float currentBalance;

  public:
    Customer(int accountNum = 0000, float currentBalance = 0.0);

    ~Customer();

    // PRE: N/A
    // POST: Adds given amount of money to Customer's currentBalance
    void addMoney(float amount = 0.0);

    // PRE: The item's name that Customer wants to buy is written exactly as it
    //        is saved in Entree name
    // POST: Subtracts price of item bought from Customer's balance
    void buyEntree(Vendor market, string entreeName = "");

    // PRE: N/A
    // POST: N/A
    float getCurrentBalance();
};

#endif
