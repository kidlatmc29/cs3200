// allergyCustomer.h
// Isabel Ovalles

#include <memory>
#include <string>
#include "vendor.h"
#include "customer.h"

using namespace std;

// Class invarients:
// - allergyCustomer has allergens that are saved
// - - all allergens must be unique
// - upon instatiation the allergen list does not have any allergens in it
// - allergyCustomer can buyOne() or buy() as long as the item does not contain
//    any of the allergens provided in the allergen list
// - inherits customer attributes

// Interface invarients:
//  - all getters and mutators are inherited from Customer class
//  - client is responsible for adding allergens to the allergyCustomer once it
//     has been instantiated
// - For buyOne and buy the client should be responsible for passing in an
//    instatiated vendor or customer's will not buy anything
// - Client is not expected to save the boolean returned from buyOne or buy,
//    but can use this result as necessary
// - Both buyOne will work as expected as long as the itemName the client give
//    is exactly as it is saved in the Entree

// Implementation invarients:
//  - allergens is saved using a dynamic array

class allergyCustomer : public Customer {
  private:
    const int INITIAL_SIZE = 3;
    string* allergens;
    int currentSize;
    int numOfAllergens;

    void resize();

  public:
    allergyCustomer(unsigned int accountNum = 0, float currentBalance = 0,
      string* allergens = nullptr, int numOfAllergens = 0, int size = 0);

    // PRE: allergen is written exactly as it is in the ingredient list list
    // POST: adds 1 allergen to allergens list unless it's already in the list
    //    increments numOfAllergens by 1
    void addAllergen(string allergen);

    // PRE: itemname is written the same way as it is saved in Vendor
    // POST: One item's price has been subtracted from the carbCustomer's balance
    // or the purchase was not made because item contained allergen so no change
    //   to the balance
    bool buyOne(shared_ptr<Vendor> market, string itemName) override;

    // PRE: N/A
    // POST: One item's price has been subtracted from the carbCustomer's balance
    // or the purchase was not made because item contained allergen so no change
    //    to the balance
    bool buy(shared_ptr<Vendor> market) override;

};
