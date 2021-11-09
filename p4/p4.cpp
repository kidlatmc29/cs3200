// p4.cpp
// Isabel Ovalles

#include <iostream>
#include <vector>
#include <memory>
#include "vendor.h"
#include "customer.h"
#include "dbetCustomer.h"

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
  clients.push_back(beck);
  clients.push_back(bobby);
  clients.push_back(ling);
  clients.push_back(nancy);
}

void printCustomers(vector<Customer*> clients)
{
  for(int i = 0; i < clients.size; i++)
  {
    cout << "Account Number: " << clients[i]->getAccountNum() << endl;
    cout << "Balance: " << clients[i]->getCurrentBalance() << endl << endl;
  }
}
