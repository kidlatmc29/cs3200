// customer.cpp
// Isabel Ovalles

#include "customer.h"

Customer::Customer(unsigned int accountNum, float currentBalance)
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

bool Customer::buyOne(shared_ptr<Vendor> market, string entreeName)
{
  bool sold = false;
  if(market->IsStocked(entreeName))
  {
    float itemPrice =  market->getItemPrice(entreeName);
    if(currentBalance >= itemPrice)
    {
      market->Sell(entreeName);
      currentBalance -= itemPrice;
      sold = true;
    }
  }
  return sold;
}

bool Customer::buy(shared_ptr<Vendor> market)
{
  bool sold = false;
  if(market != nullptr)
  {
    for(int i = 0; i < market->getSize(); i++)
    {
      string itemName = market->getItemName(i);
      float itemPrice = market->getItemPrice(itemName);
      if(itemPrice <= currentBalance)
      {
        market->Sell(itemName);
        currentBalance -= itemPrice;
        sold = true;
      }
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

void Customer::setAccountNum(unsigned int num)
{
  accountNum = num;
}
