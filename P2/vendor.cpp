// vendor.cpp
// Isabel Ovalles

#include "vendor.h"

Vendor::Vendor(string name, bool isRefrigerator)
{
  this->name = name;
  this->isRefrigerator = isRefrigerator;

  stock = new Entree[INITIAL_SIZE];
  quanties = new int[INITIAL_SIZE];
  prices = new double[INITIAL_SIZE];
}
