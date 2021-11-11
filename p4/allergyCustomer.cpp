// allergyCustomer.cpp
// Isabel Ovalles

#include "allergyCustomer.h"

allergyCustomer::allergyCustomer(unsigned int accountNum, float currentBalance,
  string* allergens, int numOfAllergens, int size) : Customer (accountNum, currentBalance)
{
  this->allergens = allergens;
  this->numOfAllergens = numOfAllergens;
  currentSize = size;
}

bool allergyCustomer::buyOne(shared_ptr<Vendor> market, string itemName)
{
  bool hasAllergen = false;
  bool sold = false;

  if (market != nullptr)
  {
      if(numOfAllergens > 0 && market->IsStocked(itemName))
      {
        for(int i = 0; i < numOfAllergens; i++)
        {
          if(market->hasIngredient(itemName, allergens[i]))
          {
            hasAllergen = true;
          }
        }

        if(!hasAllergen && currentBalance >= market->getItemPrice(itemName))
        {
          market->Sell(itemName);
          currentBalance -= market->getItemPrice(itemName);
          sold = true;
        }
      } else {
        if(market->IsStocked(itemName) && currentBalance >=
              market->getItemPrice(itemName))
        {
          market->Sell(itemName);
          currentBalance -= market->getItemPrice(itemName);
          sold = true;
        }
      }
  }
  return sold;
}

bool allergyCustomer::buy(shared_ptr<Vendor> market)
{
  bool hasAllergen = false;
  bool sold = false;

  if (market != nullptr)
  {
    for (int i = 0; i < market->getSize(); i++)
    {
        string currentItemName = market->getItemName(i);
        if (numOfAllergens > 0 && market->IsStocked(currentItemName))
        {
          for (int j = 0; j < numOfAllergens; j++)
          {
            if (market->hasIngredient(currentItemName, allergens[j]))
            {
              hasAllergen = true;
            }
          }

          if (!hasAllergen && currentBalance >=
              market->getItemPrice(currentItemName))
          {
            market->Sell(currentItemName);
            currentBalance -= market->getItemPrice(currentItemName);
            sold = true;
          }
        }
      }
    }
  return sold;
}

void allergyCustomer::addAllergen(string allergen)
{
  bool copy = false;
  int count = 0;

  if(allergens == nullptr)
  {
      allergens = new string[INITIAL_SIZE];
      currentSize = INITIAL_SIZE;
  }

  if(numOfAllergens == currentSize)
  {
    resize();
  }

  while(count != numOfAllergens)
  {
    if(allergens[count] == allergen)
    {
      copy = true;
    }
    count++;
  }

  if(!copy) {
    allergens[numOfAllergens] = allergen;
    numOfAllergens++;
  }
}

void allergyCustomer::resize()
{
  string *temp = new string[currentSize * 2];
  for(int i = 0; i < numOfAllergens; i++)
  {
    temp[i] = allergens[i];
  }
  delete[] allergens;
  allergens = temp;
  currentSize *= 2;
}
