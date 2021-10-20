// p2.cpp
// Isabel Ovalles

#include <iostream>
#include "vendor.h"
#include "customer.h"
#include <vector>

using namespace std;

int main()
{
  vector<Vendor> cStreet;
  shared_ptr<Vendor> drinks;
  shared_ptr<Vendor> snacks;
  shared_ptr<Vendor> freezer;

  cout << endl << "Welcome to P2" << endl << endl;

  cout << "Creating list of vendors..." << endl;
  drinks = new Vendor("Soda Machine", true);
  snacks = new Vendor("Snack Counter", false);
  freezer = new Vendor("Frozen Deserts", true);

  cStreet.push_back(drinks);
  cStreet.push_back(snacks);
  cStreet.push_back(freezer);

  cout << "Vendors in cStreet:" << endl;
  for(int i = 0; i < cStreet.size(); i++)
  {
    cout << cStreet[i].getName() << endl;
  }

  cout << endl << "End of P2" << endl << endl;
  return 0;
}
