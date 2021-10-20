// p2.cpp
// Isabel Ovalles

#include <iostream>
#include <vector>
#include <memory>
#include "vendor.h"
#include "customer.h"

using namespace std;

int main()
{
  vector<shared_ptr<Vendor>> cStreet;

  cout << endl << "Welcome to P2" << endl << endl;

  cout << "Creating list of vendors..." << endl;

  shared_ptr<Vendor> drinks(new Vendor("Soda Machine", true));
  shared_ptr<Vendor> snacks(new Vendor("Snack Counter", false));
  shared_ptr<Vendor> freezer(new Vendor("Frozen Deserts", true));

  cStreet.push_back(drinks);
  cStreet.push_back(snacks);
  cStreet.push_back(freezer);

  cout << "Vendors in cStreet:" << endl;
  for(int i = 0; i < (int) cStreet.size(); i++)
  {
    cout << cStreet.at(i)->getName() << endl;
  }

  cout << endl << "End of P2" << endl << endl;
  return 0;
}
