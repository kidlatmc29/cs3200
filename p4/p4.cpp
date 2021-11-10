// p4.cpp
// Isabel Ovalles

#include <iostream>
#include <vector>
#include <memory>
#include "vendor.h"
#include "customer.h"
#include "dbetCustomer.h"
#include "carbCustomer.h"
#include "allergyCustomer.h"

using namespace std;

void createCustomers(vector<Customer*> &clients);
void printCustomers(vector<Customer*> clients);

int main()
{
  shared_ptr<Vendor> bakery;
  vector<Customer*> clients;
  cout << endl << "Welcome to P4" << endl << endl;

  createCustomers(clients);
  printCustomers(clients);

  cout << endl << "End of P4" << endl << endl;
  return 0;
}

void createCustomers(vector<Customer*> &clients)
{
  cout << "Creating various Customers..." << endl;

  Customer* beck = new dbetCustomer(1, 10.00);
  Customer* bobby = new dbetCustomer(2, 13.23);
  Customer* ling = new carbCustomer(3, 45.52);
  Customer *nancy = new carbCustomer(4, 21.62);

  string* iAllergies = new string[2];
  iAllergies[0] = "peanuts";
  iAllergies[1] = "fish";

  string *aAllergies = new string[1];
  iAllergies[0] = "milk";

  Customer *isabel = new allergyCustomer(5, 6.29, iAllergies, 2, 2);
  Customer *ali = new allergyCustomer(6, 8.57, aAllergies, 1, 1);

  clients.push_back(beck);
  clients.push_back(bobby);
  clients.push_back(ling);
  clients.push_back(nancy);
  clients.push_back(isabel);
  clients.push_back(ali);
}

void printCustomers(vector<Customer*> clients)
{
  for(int i = 0; i < (int) clients.size(); i++)
  {
    cout << "Account Number: " << clients[i]->getAccountNum() << endl;
    cout << "Balance: " << clients[i]->getCurrentBalance() << endl << endl;
  }
}
