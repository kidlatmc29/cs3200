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

  totalItems = 0;
  currentSize = INITIAL_SIZE;
}

Vendor::~Vendor()
{
  delete[] stock;
  delete[] quanties;
  delete[] prices;

  stock = nullptr;
  quanties = nullptr;
  prices = nullptr;
}

void Vendor::load(Entree newItem, int qty, double price)
{
  if(totalItems + 1 > currentSize){
    // need to resize
  } else {
    stock[totalItems] = newItem;
    quanties[totalItems] = qty;
    prices[totalItems] = price;
  }

void Vendor::resize()
{
  int newSize = currentSize * 2;

  Entree *resizeStock = new Entree[newSize];
  int *resizeQuanties = new int[newSize];
  double *resizePrices = new double[newSize];

  for(int i = 0; i < currentSize; i++)
  {
    resizeStock[i] = stock[i];
  }

  for(int i = 0; i < currentSize; i++)
  {
    resizeQuanties[i] = quanties[i];
  }

  for(int i = 0; i < currentSize; i++)
  {
    resizePrices[i] = prices[i];
  }

  delete[] stock;
  delete[] quanties;
  delete[] prices;

  stock = resizeStock;
  quanties = resizeQuanties;
  prices = resizePrices;

  currentSize = newSize; 
}
