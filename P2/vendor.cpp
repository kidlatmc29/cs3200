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

  if(isEmpty())
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

void Vendor::cleanStock()
{
  if(!(isEmpty()))
  {
    vendorNode *previous = head;
    vendorNode *nPtr = previous->next;
    vendorNode *temp;

    // deleteing head
    cout << "Is " << nPtr->food.getName() << " expired? " << nPtr->food.isExpired();
    if(nPtr->food.isExpired())
    {
      temp = head;
      head = nPtr;
      delete temp;
      size--;

      nPtr = nPtr->next;
      previous = previous->next;
    }

    while(nPtr)
    {
      cout << "Is " << nPtr->food.getName() << " expired? " << nPtr->food.isExpired();
      if(nPtr->food.isExpired())
      {
        temp = nPtr;
        previous->next = nPtr->next; // assigning prev node's next to the next of deleted node
        delete nPtr;
        size--;
      }
      nPtr = nPtr->next;
      previous = previous->next;
    }
  }
}

string Vendor::getName()
{
  return name;
}

int Vendor::getSize()
{
  return size;
}

bool Vendor::isEmpty()
{
  return !(head);
}
