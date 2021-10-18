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
    if(nPtr->food.isExpired() == true)
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
      if(nPtr->food.isExpired() == true)
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

bool Vendor::isStocked(string itemName)
{
  vendorNode *nPtr = head;
  bool inStock = false;
  if(!isEmpty()) {
    if(nPtr->food.getName() == itemName &&
      !(nPtr->food.isSpoiled()) && nPtr->qty>0)
    {
      inStock = true;
    } else {
      while(nPtr && nPtr->food.getName() != itemName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr && !(nPtr->food.isSpoiled()) && nPtr->qty > 0)
      {
        inStock = true;
      }
    }
  }
  return inStock;
}

void Vendor::poweroutage()
{
  vendorNode *nPtr = head;
  if(!isEmpty()) {
    while(nPtr)
    {
      nPtr->food.powerOut();
    }
  }
}

void sell(string entreeName)
{

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
