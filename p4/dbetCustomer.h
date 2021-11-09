//dbetCustomer.h
// Isabel Ovalles

#ifndef DBETCUSTOMER_H
#define DBETCUSTOMER_H

#include <memory>
#include <string>
#include "vendor.h"
#include "customer.h"

using namespace std;

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
