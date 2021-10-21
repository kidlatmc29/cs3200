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
      !(nPtr->food.isSpoiled()) && nPtr->qty > 0)
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

void Vendor::sell(string entreeName)
{
  cout << entreeName << " is being sold... " << endl;
  vendorNode *nPtr = head;
  if(!isEmpty()) {
    if(nPtr->food.getName() == entreeName)
    {
      nPtr->qty--;
    } else {
      while(nPtr && nPtr->food.getName() != entreeName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        nPtr->qty--;
      }
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

float Vendor::getItemPrice(string itemName)
{
  vendorNode *nPtr = head;
  float itemPrice = -1;
  if(!isEmpty()) {
    if(nPtr->food.getName() == itemName)
    {
      itemPrice = nPtr->price;
    } else {
      while(nPtr && nPtr->food.getName() != itemName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        itemPrice = nPtr->price;
      }
    }
  }
  cout << itemName << " price is : " << itemPrice << endl;
  return itemPrice;
}

string Vendor::getItemNutrFacts(string itemName)
{
  vendorNode *nPtr = head;
  string nutrFacts = "";
  if(!isEmpty()) {
    if(nPtr->food.getName() == itemName)
    {
      nutrFacts = "Num of Servings: " + nPtr->food.getNumOfServings() + "\n";
      nutrFacts += "Calories: " + nPtr->food.getCalories() + "\n";
      nutrFacts += "Total Fat: " + nPtr->food.getTotalFat() + "\n";
      nutrFacts += "Saturated Fat: " + nPtr->food.getSatFat() + "\n";
      nutrFacts += "Trans Fat: " + nPtr->food.getTransFat() + "\n";
      nutrFacts += "Cholest: " + nPtr->food.getCholest() + "\n";
      nutrFacts += "Sodium: " + nPtr->food.getSodium() + "\n";
      nutrFacts += "Total Carbs: " + nPtr->food.getTotalCarbs() + "\n";
      nutrFacts += "Fiber: " + nPtr->food.getFiber() + "\n";
      nutrFacts += "Total Sugar: " + nPtr->food.getTotalSugar() + "\n";
      nutrFacts += "Protein: " + nPtr->food.getProtein() + "\n";
    } else {
      while(nPtr && nPtr->food.getName() != itemName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        nutrFacts = "Num of Servings: " + nPtr->food.getNumOfServings() + "\n";
        nutrFacts += "Calories: " + nPtr->food.getCalories() + "\n";
        nutrFacts += "Total Fat: " + nPtr->food.getTotalFat() + "\n";
        nutrFacts += "Saturated Fat: " + nPtr->food.getSatFat() + "\n";
        nutrFacts += "Trans Fat: " + nPtr->food.getTransFat() + "\n";
        nutrFacts += "Cholest: " + nPtr->food.getCholest() + "\n";
        nutrFacts += "Sodium: " + nPtr->food.getSodium() + "\n";
        nutrFacts += "Total Carbs: " + nPtr->food.getTotalCarbs() + "\n";
        nutrFacts += "Fiber: " + nPtr->food.getFiber() + "\n";
        nutrFacts += "Total Sugar: " + nPtr->food.getTotalSugar() + "\n";
        nutrFacts += "Protein: " + nPtr->food.getProtein() + "\n";
      }
    }
  }

  return nutrFacts;
}

bool Vendor::isEmpty()
{
  return !(head);
}
