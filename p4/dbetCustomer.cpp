// dbetCustomer.cpp
// Isabel Ovalles

#include "dbetCustomer.h"

bool dbetCustomer::buyOne(shared_ptr<Vendor> market, string itemName)
{
  bool sold = false;
  if(dailySugar < MAX_SUGAR && market->isStocked(itemName))
  {
    double itemSugar = stod(market->getItemSugar(itemName));
    double itemPrice = market->getItemPrice(itemName);
    if (itemSugar + dailySugar <= MAX_SUGAR && itemSugar <= SINGLE_SUGAR)
    {
      market->sell(itemName);
      currentBalance -= itemPrice;
      dailySugar += itemSugar;
      sold = true;
    }
  }
  return sold;
}

bool dbetCustomer::buy(shared_ptr<Vendor> market)
{
  bool sold = false;
  return sold;
}
