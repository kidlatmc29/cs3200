// p4.cpp
// Isabel Ovalles

#include <iostream>
#include <ctime>
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
void loadingVendor(shared_ptr<Vendor> store);
void customersBuyOneCookie(vector<Customer*> clients,shared_ptr<Vendor> store);

int main()
{
  shared_ptr<Vendor> store(new Vendor("The Corner Store", true));
  vector<Customer*> shoppers;
  cout << endl << "Welcome to P4" << endl << endl;

  createCustomers(shoppers);
  printCustomers(shoppers);
  loadingVendor(store);
  customersBuyOneCookie(shoppers, store);
  printCustomers(shoppers);

  cout << endl << "End of P4" << endl << endl;
  return 0;
}

void createCustomers(vector<Customer*> &clients)
{
  cout << "Creating various Customers..." << endl;

  Customer* beck = new dbetCustomer(1, 10.01);
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

void loadingVendor(shared_ptr<Vendor> store)
{
  cout << endl << "Loading a vendor..." << endl;
  string soda1Name = "Coca-Cola";
  string soda1Nutr = "1 240 0 0 0 0 75 65 0 65 0";
  string soda1Ing = "CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CARAMEL COLOR$PHOSPHORIC ACID$NATURAL FLAVORS$CAFFEINE";
  string soda1Contains = "";
  Entree soda1(soda1Name, soda1Ing, soda1Nutr, soda1Contains, "12/20/20", true, true);

  string soda2Name = "Sprite";
  string soda2Nutr = "1 140 0 0 0 0 75 65 0 65 0";
  string soda2Ing = "CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$NATURAL FLAVORS$SODIUM CITRATE$SODIUM BENZOATE ";
  string soda2Contains = "";
  Entree soda2(soda2Name, soda2Ing, soda2Nutr, soda2Contains, "12/20/19", true, true);

  string soda3Name = "Fanta";
  string soda3Nutr = "1 270 0 0 0 0 75 73 0 73 0";
  string soda3Ing = "CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$SODIUM BENZOATE (TO PROTECT TASTE)$NATURAL FLAVORS$MODIFIED FOOD STARCH$SODIUM POLYPHOSPHATES$GLYCEROL ESTER OF ROSIN$YELLOW 6$RED 40";
  string soda3Contains = "";
  Entree soda3(soda3Name, soda3Ing, soda3Nutr, soda3Contains, "12/20/21", true, true);

  string cookieName = "Grandma's Chocolate Chip Cookies";
  string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";
  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";
  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/21", false, false);

  string chipsName = "Lay's Classic Potato Chips";
  string chipsNutr = "2 160 10 2 0 0 170 15 1 0 2";
  string chipsIng = "Potatoes$Vegetable Oil(Sunflower, Corn and/or Canola Oil)$Salt";
  string chipsContains = "";
  Entree chips(chipsName, chipsIng, chipsNutr, chipsContains, "12/1/20", false, false);

  string nutsName = "Planters Nuts on the Go Salted Peanuts";
  string nutsNutr = "1 170 14 2 0 0 95 5 2 1 7";
  string nutsIng = "Peanuts$Peanut and/or Cottonseed oil$sea salt";
  string nutsContains ="peanuts";
  Entree nuts(nutsName, nutsIng, nutsNutr, nutsContains, "11/31/22", false, false);

  string popName = "Skinny Pop Popcorn";
  string popNutr = "1	100	6	0.5	0	9	45	9	9	0	2";
  string popIng = "Popcorn$Sunflower oil$salt";
  string popContains = "";
  Entree popcorn(popName, popIng, popNutr, popContains, "4/10/22", false, false);

  store->Load(soda1, 3, 1.00);
  store->Load(soda2, 5, 1.40);
  store->Load(soda3, 12, .99);
  store->Load(cookie, 32, 1.50);
  store->Load(chips, 14, 2.50);
  store->Load(nuts, 35, .50);
  store->Load(popcorn, 8, 3.45);

  cout << store->getName() << " has " << store->getSize() << " items" << endl;
}

void printCustomers(vector<Customer*> clients)
{
  for(int i = 0; i < (int) clients.size(); i++)
  {
    cout << "Account Number: " << clients[i]->getAccountNum() << endl;
    cout << "Customer Type: ";
    if(clients[i]->whoami() == 1)
    {
      cout << "dbetCustomer" << endl;
    } else if(clients[i]->whoami() == 2) {
      cout << "carbCustomer" << endl;
    } else if(clients[i]->whoami() == 3) {
      cout << "allergyCustomer" << endl;
    } else {
      cout << "Customer" << endl;
    }
    cout << "Balance: " << clients[i]->getCurrentBalance() << endl;
  }
}

void customersBuyOneCookie(vector<Customer*> clients,shared_ptr<Vendor> store)
{
  string itemName = "Grandma's Chocolate Chip Cookies";

  cout << endl << "Attempting to purchase Grandma's Chocolate Chip Cookies - $"
       << store->getItemPrice(itemName) << endl;
  for(int i = 0; i < (int) clients.size(); i++)
  {
    if(clients[i]->buyOne(store.get(), itemName))
    {
      cout << "Account " << clients[i]->getAccountNum()
           << " completed a purchase" << endl;
    }
  }
}

bool getRandomBool()
{
  bool b = false;

  return b;
}

string getRandomDate()
{
  string date = "";
  return date;
}
