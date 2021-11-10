// carbCustomer.h
// Isabel Ovalles

// Class invarients:
//  - carbCustomer has a daily max carbs intake of 30 g
//  - when buying one or multiple items, the current item's carbs cannot make
//      the dailyCarbs over 30 g
//  - inherits customer attributes

// Interface invarients:
//  - all getters and mutators are inherited from Customer class
// - For buyOne and buy the client should be responsible for passing in an
//    instatiated vendor or customer's will not buy anything
// - Client is not expected to save the boolean returned from buyOne or buy,
//     but can use this result as necessary
// - Both buyOne will work as expected as long as the itemName the client give
//    is exactly as it is saved in the Entree

// Implementation invarients:
//  - when a carbCustomer is created, the dailyCarbs's value starts at 0
//  - dailyCarbs is a const and cannot be modified by the client

#include <memory>
#include <string>
#include "vendor.h"
#include "customer.h"

using namespace std;

class carbCustomer : public Customer {
  private:
    const double MAX_CARBS = 30;
    double dailyCarbs;

  public:
    carbCustomer(unsigned int accountNum = 0, float currentBalance = 0);

    // PRE: itemname is written the same way as it is saved in Vendor
    // POST: One item's price has been subtracted from the carbCustomer's balance
    // or the purchase was not made so no change to the balance
    bool buyOne(shared_ptr<Vendor> market, string itemName = "") override;

    // PRE: itemname is written the same way as it is saved in Vendor
    // POST: Multiple items' prices have been subtracted from carbCustomer's balance
    // or no items were purchased so no change to the balance
    bool buy(shared_ptr<Vendor> market) override;

    // PRE: N/A
    // POST: N/A
    double getDailyCarbs();

    // PRE: N/A
    // POST: dailySugar is set to 0
    void restDailyCarbs();
};
