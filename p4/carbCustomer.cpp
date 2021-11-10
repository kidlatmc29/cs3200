// carbCustomer.cpp
// Isabel Ovalles

#include "carbCustomer.h"

carbCustomer::carbCustomer(unsigned int accountNum, float currentBalance)
  : Customer(accountNum, currentBalance)
  {
    dailyCarbs = 0;
  }

bool carbCustomer::buyOne(shared_ptr<Vendor> market, string itemName)
{
  bool sold = false;
  if (dailyCarbs < MAX_CARBS && market->isStocked(itemName))
  {
      double itemCarbs = stod(market->getItemCarbs(itemName));
      double itemPrice = market->getItemPrice(itemName);
      if (itemCarbs + dailyCarbs <= MAX_CARBS && currentBalance >= itemPrice)
      {
          market->sell(itemName);
          currentBalance -= itemPrice;
          dailyCarbs += itemCarbs;
          sold = true;
      }
  }
  return sold;
}

bool carbCustomer::buy(shared_ptr<Vendor> market)
{
  bool sold = false;
  if (market->getSize() > 0)
  {
      for (int i = 0; i < market->getSize(); i++)
      {
          string itemName = market->getItemName(i);
          if (market->isStocked(itemName))
          {
              double itemCarbs = stod(market->getItemCarbs(itemName));
              double itemPrice = market->getItemPrice(itemName);
              if (dailyCarbs + itemCarbs <= MAX_CARBS)
              {
                  if (currentBalance >= itemPrice)
                  {
                      market->sell(itemName);
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

double carbCustomer::getDailyCarbs()
{
  return dailyCarbs;
}

void carbCustomer::restDailyCarbs()
{
  dailyCarbs = 0;
}
