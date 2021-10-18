// vendor.h
// Isabel Ovalles

#ifndef VENDOR_H
#define VENDOR_H

#include <string>
#include <iostream>
#include "entree.h"

using namespace std;

// Class invarients:
// Interface invarients:
// Implementation invarients:

class Vendor
{
  private:
    string name;
    bool isRefrigerator;
    int size;

    // utility functions
  //  void copy();
  bool isEmpty();

  public:
    class vendorNode{
      public:
        vendorNode(Entree food, int qty, float price);
        Entree food;
        int qty;
        float price;
        vendorNode *next;

        float getItemPrice() {return price;}
    };

    vendorNode *head;

    // behaviors
    Vendor(string name, bool isRefrigerator);

    Vendor(Vendor &original);

    Vendor& operator=(const Vendor &original);

    ~Vendor();

    void load(Entree food, int qty, double price);
    // adds specific num of Entrees

    void cleanStock();
      //based on current date, items that are expired or spoiled are
      // removed from stock

    bool isStocked(string itemName);
      // checks if current item is available for sale and is not spoiled

    // sells sells ONE of the items to a specific customer IF they can pay for it
      // NO SELLING SPOILED OR EXPIERED Entrees

    void poweroutage();
    // vendor loses power, and food req refridge is SPOILED

    void sell(string entreeName);

    string getName();

    int getSize();
};

#endif
