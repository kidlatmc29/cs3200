// dbetCustomer.cpp
// Isabel Ovalles

#include "dbetCustomer.h"

dbetCustomer::dbetCustomer(unsigned int accountNum, float currentBalance)
  : Customer (accountNum, currentBalance)
{
    dailySugar = 0;
    id = 1;
}

bool dbetCustomer::buyOne(Vendor *market, string itemName)
{
  bool sold = false;
  string strSugar = "";
  double itemSugar = 0;
  double itemPrice = 0;
  if(dailySugar < MAX_SUGAR && market->IsStocked(itemName))
  {
    strSugar = market->getItemSugar(itemName);

    itemSugar = stod(strSugar);
    itemPrice = market->getItemPrice(itemName);
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
  double currentSugar = 0;
  string itemName = "";

  if(market != nullptr && market->getSize() > 0)
  {
    for(int i = 0; i < market->getSize(); i++)
    {
      itemName = market->getItemName(i);
      if(market->IsStocked(itemName))
      {
        double itemSugar = stod(market->getItemSugar(itemName));
        double itemPrice = market->getItemPrice(itemName);
        if(currentSugar + itemSugar <= MULTI_SUGAR &&
           itemSugar + dailySugar <= MAX_SUGAR)
        {
          if(currentBalance >= itemPrice)
          {
            market->Sell(itemName);
            currentBalance -= itemPrice;
            currentSugar += itemSugar;
            dailySugar += itemSugar;
            sold = true;
          }
        }
      }
    }
  }
  return sold;
}

double dbetCustomer::getDaily()
{
  return dailySugar;
}

void dbetCustomer::resetDaily()
{
  dailySugar = 0;
}
