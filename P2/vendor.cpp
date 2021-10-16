// vendor.cpp
// Isabel Ovalles

#include "vendor.h"

Vendor::Vendor(string name, bool isRefrigerator)
{
  this->name = name;
  this->isRefrigerator = isRefrigerator;

  head = nullptr;
  size = 0;
}

Vendor::vendorNode::vendorNode(Entree f, int q, float p)
{
  food = f;
  qty = q;
  price = p;
}

Vendor::Vendor(Vendor &original)
{
  head = nullptr;
  size = 0;

  vendorNode *copy = original.head;

  while(copy)
  {
    load(copy->food, copy->qty, copy->price);
    copy = copy->next;
  }
}

Vendor& Vendor::operator=(const Vendor &original)
{
  if(this->head != original.head) {
    head = nullptr;
    size = 0;

    vendorNode *copy = original.head;

    while(copy)
    {
      load(copy->food, copy->qty, copy->price);
      copy = copy->next;
    }
  }
  return *this;
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
  vendorNode *newItem = new vendorNode(food, qty, price);
  newItem->next = nullptr;
  vendorNode *nPtr;

  if(head == nullptr)
  {
    head = newItem;
  } else {
    nPtr = head;
    while(nPtr->next)
    {
      nPtr = nPtr->next;
    }
    nPtr->next = newItem;
  }
  size++;
}

string Vendor::getName()
{
  return name;
}

int Vendor::getSize()
{
  return size;
}
