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
    // some container for Entrees needs to be dynamic, var number
    // each item in stock has a quanity, price and characteristics of that entree?
      // possibily make an array corresponding with those attributes?
    // ex.) Oreos qty:10 price: $1.00
    Entree *stock;
    int *quanties;
    double *prices;

    int totalItems;
    int currentSize;

    // is stored in refridge
    bool isRefrigerator;

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

      // isStocked checks if current item is available for sail and is not spoiled
      // or expired

      // deep copying must be supported

      // resize arrays
      void resize();
};
