// dbetCustomer.cpp
// Isabel Ovalles

#include "dbetCustomer.h"

dbetCustomer::dbetCustomer(unsigned int accountNum, float currentBalance)
  : Customer (accountNum, currentBalance)
{
    dailySugar = 0;
}

bool dbetCustomer::buyOne(Vendor *market, string itemName)
{
  bool sold = false;
  if(dailySugar < MAX_SUGAR && market->IsStocked(itemName))
  {
    double itemSugar = stod(market->getItemSugar(itemName));
    double itemPrice = market->getItemPrice(itemName);
    if (itemSugar + dailySugar <= MAX_SUGAR && itemSugar <= SINGLE_SUGAR)
    {
      market->Sell(itemName);
      currentBalance -= itemPrice;
      dailySugar += itemSugar;
      sold = true;
    }
  }
  return sold;
}

bool dbetCustomer::buy(Vendor *market)
{
  bool sold = false;
  return sold;
}

double dbetCustomer::getDailySugar()
{
  return dailySugar;
}

void dbetCustomer::resetDailySugar()
{
  dailySugar = 0;
}
