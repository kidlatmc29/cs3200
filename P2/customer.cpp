// customer.cpp
// Isabel Ovalles

#include "customer.h"

Customer::Customer(int accountNum, float currentBalance)
{
  this->accountNum = accountNum;
  this->currentBalance = currentBalance;
}

Customer::~Customer()
{
}

void Customer::addMoney(float amount)
{
  if(amount > 0.0) // checking if amount is pos
  {
    currentBalance += amount;
  }
}

bool Customer::buyEntree(shared_ptr<Vendor> market, string entreeName)
{
  bool sold = false;
  if(market->isStocked(entreeName))
  {
    float itemPrice =  market->getItemPrice(entreeName);
    if(currentBalance >= itemPrice)
    {
      market->sell(entreeName);
      currentBalance -= itemPrice;
      sold = true;
    }
  }
  return sold;
}

float Customer::getCurrentBalance()
{
  return currentBalance;
}

int Customer::getAccountNum()
{
  return accountNum;
}
