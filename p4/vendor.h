// vendor.h
// Isabel Ovalles

#ifndef VENDOR_H
#define VENDOR_H

#include <string>
#include <iostream>
#include "entree.h"

using namespace std;

// Class invarients:
// -Vendor contains a list of items that represent the Vendor's stock.
// -It also holds the name of the Vendor and if the Vendor's stock is a
//    refridgerator
// -Vendor is instantiated with 0 items to begin with

// Interface invarients:
//  - Entree objects must be instantiated before loading them into a Vendor
// - When instantiating a Vendor object, must provide a name and if it's a
//    refrigerator in the parameterized ctor for a valid state

// Implementation invarients:
//  - the list of Items in Vendor is implemented using a linked list
//   - vendorNode consists of the Entree, the quantity of the Entree and the
//      price
//  -sell is called from the Customer object, see Customer class for checking
//    validity of purchase

class Vendor
{
  private:
    const int NUM_OF_NUTR_STATS = 11;
    string name;
    bool isRefrigerator;
    int size;
    double *totalNutrStats;

   // utility function
   bool isEmpty();
   void addNutrStats(Entree food);

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

    Vendor(string name, bool isRefrigerator);

    Vendor(Vendor &original);

    Vendor& operator=(const Vendor &original);

    ~Vendor();

    // PRE: Entree food is already been instatiated and it assumed to be valid
    // POST: One vendorNode is added to the linked list, size is incremented by
    //        one
    void Load(Entree food, int qty, double price);

    // PRE: N/A
    // POST: If there is any spoiled or expired items, they are removed from
    //      the linked list
    void CleanStock();

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    bool IsStocked(string itemName);

    // PRE: N/A
    // POST: All Entree's isRefrigered is set to false
    void PowerOutage();

    // PRE: isStocked has returned true and the Customer has enough money to
    //      purchase item
    // POST: The item sold's qty is decremented by 1
    void Sell(string entreeName);

    // PRE: N/A
    // POST: N/A
    string getName();

    // PRE: N/A
    // POST: N/A
    int getSize();

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    int findIndex(string itemName);

    // PRE: itemName is exactly what is saved in Entree's name
    // POST: N/A
    bool hasIngredient(string itemName, string allergen);

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    float getItemPrice(string itemName);

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    string getItemName(int index);

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    string getItemSugar(string itemName);

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    string getItemCarbs(string itemName);

    // PRE: itemName must be exactly as what is saved in Entree's name
    // POST: N/A
    string getItemNutrFacts(string itemName);

    // PRE: N/A
    // POST: returns a string that contains all the nutrition facts summed from
    //        all purchases
    double* getTotalNutrStatsSold();
};

#endif
