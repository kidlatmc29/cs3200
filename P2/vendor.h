// vendor.h
// Isabel Ovalles

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

  public:
    class vendorNode{
      public:
        vendorNode(Entree food, int qty, float price);
        Entree food;
        int qty;
        float price;
        vendorNode *next;
    };

    vendorNode *head;

    // behaviors
    Vendor(string name, bool isRefrigerator);

    Vendor(Vendor &original);

    Vendor& operator=(const Vendor &original);

    ~Vendor();

    void load(Entree food, int qty, double price);
    // adds specific num of Entrees

    // sells sells ONE of the items to a specific customer IF they can pay for it
      // NO SELLING SPOILED OR EXPIERED Entrees

      // poweroutage() vendor loses power, and food req refridge is SPOILED

      // cleanStock() based on current date, items that are expired or spoiled are
      // removed from stock

      // isStocked(string itemName) checks if current item is available for sale and is not
      // spoiled or expired

      string getName();

      int getSize();
};
