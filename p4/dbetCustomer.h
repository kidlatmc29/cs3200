//dbetCustomer.h
// Isabel Ovalles

#ifndef DBETCUSTOMER_H
#define DBETCUSTOMER_H

#include <memory>
#include <string>
#include "vendor.h"
#include "customer.h"

using namespace std;

// Class invarients:
//  - dbetCustomer has a daily max sugar of 50 g
//  - -inherits customer attributes
//  - When buying one item, total sugar of item must be less than or equal to
//      10 g
//  - When buying mutiple items, the total sugar of those items combined must be
//     less than or equal to 25 g

// Interface invarients:
//  - all getters and mutators are inherited from Customer class
// - For buyOne and buy the client should be responsible for passing in an
//    instatiated vendor or customer's will not buy anything
// - Client is not expected to save the boolean returned from buyOne or buy,
//    but can use this result as necessary
// - Both buyOne will work as expected as long as the itemName the client give
//    is exactly as it is saved in the Entree

// Implementation invarients:
//  - when a dbetCustomer is created, the dailySugar's value starts at 0
//  - dailySugar can be only modified using the buy() or buyOne() fxns
//  - max daily sugar, sugar limit for one item, and the sugar limit for
//    multiple items are all consts and client cannot change them

class dbetCustomer : public Customer {
  private:
    const double MAX_SUGAR = 50;
    const double SINGLE_SUGAR = 10;
    const double MULTI_SUGAR = 25;
    double dailySugar;

  public:
    dbetCustomer(unsigned int accountNum = 0, float currentBalance = 0)
      : Customer(accountNum, currentBalance) { dailySugar = 0; };

    // PRE: itemname is written the same way as it is saved in Vendor
    // POST: One item's price has been subtracted from the dbetCustomer's
    //  balance or the purchase was not made so no change to the balance
    bool buyOne(shared_ptr<Vendor> market, string entreeName = "") override;

    // PRE: itemname is written the same way as it is saved in Vendor
    // POST: Multiple items' prices have been subtracted from dbetCustomer's
    //   balance or no items were purchased so no change to the balance
    bool buy(shared_ptr<Vendor> market) override;
};

#endif
