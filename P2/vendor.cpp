// vendor.cpp
// Isabel Ovalles

#include "vendor.h"

Vendor::Vendor(string name, bool isRefrigerator)
{
  this->name = name;
  this->isRefrigerator = isRefrigerator;

  stock = new Item[INITIAL_SIZE];
  totalItems = 0;
  currentSize = INITIAL_SIZE;
}

Vendor::~Vendor()
{
    delete[] stock;
    stock = nullptr;
}

/**
void Vendor::load(Entree food, int qty, double price)
{
  Item newItem;

  if(totalItems + 1 > currentSize)
  {
    resize();
  }

  newItem.food = food;
  newItem.qty = qty;
  newItem.price = price;

  totalItems++;
}
**/

void Vendor::resize()
{

}

string Vendor::getName()
{
  return name;
}
