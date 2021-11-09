// p4.cpp
// Isabel Ovalles

#include <iostream>
#include <vector>
#include <memory>
#include "vendor.h"
#include "customer.h"

using namespace std;

void createCustomers(vector<Customer> &clients);

int main()
{
  shared_ptr<Vendor> bakery;
  vector<Customer> clients;
  cout << endl << "Welcome to P4" << endl << endl;

  cout << endl << "End of P4" << endl << endl;
  return 0;
}

void createCustomers(vector<Customer> &clients)
{
  cout << "Creating various Customers..." << endl;
}
