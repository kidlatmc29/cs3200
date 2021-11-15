// carbCustomer.cpp
// Isabel Ovalles

#include "carbCustomer.h"

carbCustomer::carbCustomer(unsigned int accountNum, float currentBalance)
  : Customer(accountNum, currentBalance)
  {
    dailyCarbs = 0;
    id = 2;
  }

bool carbCustomer::buyOne(Vendor *market, string itemName)
{
  bool sold = false;
  if (dailyCarbs < MAX_CARBS && market->IsStocked(itemName))
  {
      double itemCarbs = stod(market->getItemCarbs(itemName));
      double itemPrice = market->getItemPrice(itemName);
      if (itemCarbs + dailyCarbs <= MAX_CARBS && currentBalance >= itemPrice)
      {
          market->Sell(itemName);
          currentBalance -= itemPrice;
          dailyCarbs += itemCarbs;
          sold = true;
      }
  }
  return sold;
}

bool carbCustomer::buy(Vendor *market)
{
  bool sold = false;
  if (market->getSize() > 0)
  {
      for (int i = 0; i < market->getSize(); i++)
      {
          string itemName = market->getItemName(i);
          if (market->IsStocked(itemName))
          {
              double itemCarbs = stod(market->getItemCarbs(itemName));
              double itemPrice = market->getItemPrice(itemName);
              if (dailyCarbs + itemCarbs <= MAX_CARBS)
              {
                  if (currentBalance >= itemPrice)
                  {
                      market->Sell(itemName);
                      currentBalance -= itemPrice;
                      dailyCarbs += itemCarbs;
                      sold = true;
                  }
              }
          }
      }
  }
  return sold;
}

double carbCustomer::getDaily()
{
  return dailyCarbs;
}

void carbCustomer::restDaily()
{
  dailyCarbs = 0;
}
