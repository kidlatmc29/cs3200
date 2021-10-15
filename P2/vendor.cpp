// vendor.cpp
// Isabel Ovalles

#include "vendor.h"

Vendor::Vendor(string name, bool isRefrigerator)
{
  this->name = name;
  this-> isRefrigerator = isRefrigerator;

  head = nullptr;
  size = 0;
}

Vendor::vendorNode::vendorNode(Entree food, int qty, float price)
{
  this->food = food;
  this->qty = qty;
  this->price = price;
}

Vendor::~Vendor()
{
  vendorNode *nPtr = head;
  vendorNode *nextPtr;

  while(nPtr)
  {
    nextPtr = nPtr->next;
    delete nPtr;
    nPtr = nextPtr;
  }
  head = nullptr;
}

void Vendor::load(Entree food, int qty, double price)
{
}

string Vendor::getName()
{
  return name;
}
