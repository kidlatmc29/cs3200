// vendor.h
// Isabel Ovalles

class vendor
{
  private:
  // members:
  // vendors have a name!!!
  // some container for Entrees needs to be dynamic, var number
  // each item in stock has a quanity, price and characteristics of that entree?
    // possibily make an array corresponding with those attributes?
    // ex.) Oreos qty:10 price: $1.00
  Entree *stock;
  // is stored in refridge
  bool isRefrigerator;

  // behaviors
  Vendor();
  // load() adds specific num of Entrees
  // sells sells ONE of the items to a specific customer IF they can pay for it
    // NO SELLING SPOILED OR EXPIERED Entrees

  // poweroutage() vendor loses power, and food req refridge is SPOILED

  // cleanStock() based on current date, items that are expired or spoiled are
  // removed from stock

  // isStocked checks if current item is available for sail and is not spoiled
  // or expired

  // deep copying must be supported

};
