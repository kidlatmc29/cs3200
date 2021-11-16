// customer.cpp
// Isabel Ovalles

#include "customer.h"

Customer::Customer(unsigned int accountNum, float currentBalance)
{
  this->accountNum = accountNum;
  this->currentBalance = currentBalance;
  this->id = 0;
}

Customer::~Customer()
{
}

ostream& operator<<(ostream& os, const Customer& shopper)
{
  os << "Account Num: " << shopper.accountNum << endl
     << "Customer Type: ";
  if(shopper.id == 1)
  {
    os << "Diabetic";
  } else if(shopper.id == 2)
  {
    os << "Carb";
  } else if(shopper.id == 3)
  {
    os << "Allergy";
  } else {
    os << "Customer";
  }
  os << endl << "Balance: $" << shopper.currentBalance << endl;
  return os;
}

bool operator==(const Customer& c1, const Customer& c2)
{
  return c1.accountNum == c2.accountNum;
}

bool operator!=(const Customer& c1, const Customer& c2)
{
  return !operator==(c1,c2);
}

void Customer::addMoney(float amount)
{
  if(amount >= 0.0) // checking if amount is pos
  {
    currentBalance += amount;
  }
}

bool Customer::buyOne(Vendor *market, string entreeName)
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

bool Customer::buy(Vendor *market)
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

int Customer::whoami()
{
  return id;
}

double Customer::getDaily()
{
  return -1;
}

void Customer::resetDaily()
{
}
