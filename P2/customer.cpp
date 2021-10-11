// customer.cpp
// Isabel Ovalles

#include<iostream>
#include "customer.h"

Customer::Customer(int accountNum = 0000, double currentBalance = 0.0)
{
  this->accountNum = accountNum;
  this->currentBalance = currentBalance;
}

Customer::~Customer()
{
}

void Customer::addMoney(double amount)
{
  if(amount > 0.0) // checking if amount is pos
  {
    currentBalance += amount;
  }
}

void Customer::buyEntree(Vendor market, string entreeName)
{
    // check if there's enough money to buy
}
