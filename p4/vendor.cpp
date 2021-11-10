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
    vendorNode *previous = nullptr;
    vendorNode *nPtr = head;
    while(nPtr)
    {
      if(nPtr->qty < 1 || nPtr->food.isSpoiled())
      {
        if(head == nPtr)
        {
          head = nPtr->next;
          delete nPtr;
          size--;
        } else {
          vendorNode *temp = nPtr;
          previous->next = nPtr->next;
          delete temp;
          size--;
        }
      }
      previous = nPtr;
      nPtr = nPtr->next;
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
//  cout << "inStock is: " << inStock << endl;
  return inStock;
}

void Vendor::poweroutage()
{
  vendorNode *nPtr = head;
  if(!isEmpty()) {
    while(nPtr)
    {
      nPtr->food.powerOut();
      nPtr = nPtr->next;
    }
  }
}

void Vendor::sell(string entreeName)
{
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

int Vendor::findIndex(string itemName)
{
  int currentIndex = 0;
  int foundIndex = -1;
  vendorNode *nPtr = head;
  if (!isEmpty())
  {
    if(nPtr->food.getName() == itemName)
    {
      foundIndex = currentIndex;
    } else {
      while(nPtr && nPtr->food.getName() != itemName) // MAKE SURE THIS WORKS
      {
        nPtr = nPtr->next;
        currentIndex++;
      }
      if(nPtr)
      {
        foundIndex = currentIndex;
      }
    }
  }
  return foundIndex;
}

bool Vendor::hasIngredient(string itemName, string allergen)
{
  vendorNode *nPtr = head;
  bool hasIngredient = false;
  if (!isEmpty())
  {
    if(nPtr->food.getName() == itemName)
    {
      hasIngredient = nPtr->food.hasIngredient(allergen);
    } else {
      while(nPtr && nPtr->food.getName() != itemName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        hasIngredient = nPtr->food.hasIngredient(allergen);
      }
    }
  }
  return hasIngredient;
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
  return itemPrice;
}

string Vendor::getItemName(int index)
{
  vendorNode *nPtr = head;
  string itemName = "";
  int count = 0;
  if(!isEmpty())
  {
    if(index == 0)
    {
      itemName = nPtr->food.getName();
    } else {
      while(nPtr && count != index)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        itemName = nPtr->food.getName();
      }
    }
  }
  return itemName;
}

string Vendor::getItemSugar(string itemName)
{
  vendorNode *nPtr = head;
  string itemSugar = "";
  if(!isEmpty()) {
    if(nPtr->food.getName() == itemName)
    {
      itemSugar = nPtr->food.getTotalSugar();
    } else {
      while(nPtr && nPtr->food.getName() != itemName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        itemSugar = nPtr->food.getTotalSugar();
      }
    }
  }
  return itemSugar;
}

string Vendor::getItemCarbs(string itemName)
{
  vendorNode *nPtr = head;
  string itemCarbs = "";
  if(!isEmpty()) {
    if(nPtr->food.getName() == itemName)
    {
      itemCarbs = nPtr->food.getTotalCarbs();
    } else {
      while(nPtr && nPtr->food.getName() != itemName)
      {
        nPtr = nPtr->next;
      }
      if(nPtr)
      {
        itemCarbs = nPtr->food.getTotalCarbs();
      }
    }
  }
  return itemCarbs;
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
