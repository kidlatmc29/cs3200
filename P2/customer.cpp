// customer.cpp
// Isabel Ovalles

#include "customer.h"

Customer::Customer(int accountNum, double currentBalance)
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
  if(market.isStocked(entreeName))
  {
    cout << "Need to check if you have enough money to buy item!!" << endl;
  }
}

double Customer::getCurrentBalance()
{
  return currentBalance;
}
