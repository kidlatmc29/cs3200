// vendor.h
// Isabel Ovalles

#include <string>
#include "entree.h"

class Vendor
{
  private:
    const int INITIAL_SIZE = 10;
    // members:
    string name;
    struct Item
    {
      Entree food;
      unsigned int qty;
      double price;
    };

    Item *stock;

    int totalItems;
    int currentSize;
    bool isRefrigerator;

    // utility functions
    // resize array
    void resize();

  public:
    // behaviors
    Vendor(string name = "New_Vendor", bool isRefrigerator = false);

    ~Vendor();

    void load(Entree newItem, int qty, double price);
    // adds specific num of Entrees

    // sells sells ONE of the items to a specific customer IF they can pay for it
      // NO SELLING SPOILED OR EXPIERED Entrees

      // poweroutage() vendor loses power, and food req refridge is SPOILED

      // cleanStock() based on current date, items that are expired or spoiled are
      // removed from stock

      // isStocked checks if current item is available for sale and is not
      // spoiled or expired

      // deep copying must be supported
};
