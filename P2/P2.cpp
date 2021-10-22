// p2.cpp
// Isabel Ovalles

#include <iostream>
#include <vector>
#include <memory>
#include "vendor.h"
#include "customer.h"

using namespace std;

void creatingVendors(vector<shared_ptr<Vendor>> &cStreet);
void loadEntreesInVendor(vector<shared_ptr<Vendor>> &cStreet);
void getEntreeNutrFacts(vector<shared_ptr<Vendor>> cStreet);
void isStockedFanta(vector<shared_ptr<Vendor>> cStreet);

void creatingCustomers(vector<Customer> &students);
void sellInStockItem(vector<shared_ptr<Vendor>> &cStreet,
                     vector<Customer> &students);
void sellExpiredItem(vector<shared_ptr<Vendor>> &cStreet,
                     vector<Customer> &students);

void poweroutageDrinks(vector<shared_ptr<Vendor>> &cStreet);
void sellSpoiledItem(vector<shared_ptr<Vendor>> &cStreet);
void cleanStockFreezer(vector<shared_ptr<Vendor>> &cStreet);
void removeVendorsFromCStreet(vector<shared_ptr<Vendor>> &cStreet);

int main()
{
  vector<shared_ptr<Vendor>> cStreet;
  vector<Customer> students;

  cout << endl << "Welcome to P2" << endl << endl;

  creatingVendors(cStreet);
  creatingCustomers(students);

  loadEntreesInVendor(cStreet);
  getEntreeNutrFacts(cStreet);
  isStockedFanta(cStreet);

  sellInStockItem(cStreet, students);
  sellExpiredItem(cStreet, students);

  cout << endl << "End of P2" << endl << endl;
  return 0;
}

void creatingVendors(vector<shared_ptr<Vendor>> &cStreet)
{
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
}

void loadEntreesInVendor(vector<shared_ptr<Vendor>> &cStreet)
{
  // NumberOfServings	Calories	TotalFat(g)	SatFat(g)	TransFat(g)	Cholest(mg)	Sodium(mg)	TotCarb(g)	Fiber(g)	TotSugars(g)	Protein(g)
  cout << endl<<  "Loading drinks into Soda Machine..." << endl;

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

  cout << "Number of items in Soda Machine: "
       << cStreet.at(0)->getSize() << endl;

  cStreet.at(0)->load(soda1, 10, 2.00);
  cStreet.at(0)->load(soda2, 11, 2.00);
  cStreet.at(0)->load(soda3, 2, 2.50);

  cout << "Number of items in Soda Machine: "
       << cStreet.at(0)->getSize() << endl;

  cout << endl << "Loading items in Snack Counter...." << endl;
  cout << "Number of items in Snack Counter: "
       << cStreet.at(1)->getSize() << endl;

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

  cStreet.at(1)->load(cookie, 12, 1.50);
  cStreet.at(1)->load(chips, 5, 2.00);
  cStreet.at(1)->load(nuts, 2, 0.50);
  cStreet.at(1)->load(popcorn, 19, 1.00);

  cout << "Number of items in Snack Counter: "
       << cStreet.at(1)->getSize() << endl;
}

void getEntreeNutrFacts(vector<shared_ptr<Vendor>> cStreet)
{
  cout << endl << "Fanta Nutrition Facts===========" << endl;
  cout << cStreet.at(0)->getItemNutrFacts("Fanta");
  cout << "================================" << endl;

  cout << endl << "Skinny Pop Popcorn Nutrition Facts===========" << endl;
  cout << cStreet.at(1)->getItemNutrFacts("Skinny Pop Popcorn");
  cout << "=============================================" << endl;
}

void isStockedFanta(vector<shared_ptr<Vendor>> cStreet)
{
  string itemName = "Fanta";
  string vendorName;
  bool inStock;
  bool found;

  cout << endl << "Checking if Fanta is inStock in any Vendor...." << endl;
  for(int i = 0; i < (int) cStreet.size(); i++)
  {
    inStock = cStreet.at(i)->isStocked(itemName);
    if(inStock)
    {
      found = true;
      vendorName = cStreet.at(i)->getName();
    }
  }

  if(found) {
    cout << "Fanta is in stock at the " << vendorName << endl;
  } else {
    cout << "Sorry, Fanta is not in stock at any Vendor..." << endl;
  }
}

void creatingCustomers(vector<Customer> &students)
{
  cout << endl << "Creating Customers...." << endl;
  Customer student1(1, 14.00);
  Customer student2(2, 10.00);
  Customer student3(3, 1.00);

  students.push_back(student1);
  students.push_back(student2);
  students.push_back(student3);

  for(int i = 0; i < (int) students.size(); i++)
  {
    cout << "Account #: " << students.at(i).getAccountNum()
         << "   Balance: " << students.at(i).getCurrentBalance() << endl;
  }
}

void sellInStockItem(vector<shared_ptr<Vendor>> &cStreet,
                    vector<Customer> &students)
{
  string itemName1 = "Fanta";
  string itemName2 = "Skinny Pop Popcorn";

  cout << endl <<  "Trying to sell in stock items..." << endl;
  if(students.at(0).buyEntree(cStreet.at(0), itemName1))
  {
    cout << itemName1 << " was purchased..." << endl;
  } else {
    cout << "Sorry, that item was not instock or insufficent balance..."
         << endl;
  }

  if(students.at(1).buyEntree(cStreet.at(1), itemName2))
  {
    cout << itemName2 << " was purchased..." << endl;
  } else {
    cout << "Sorry, that item was not instock or insufficent balance..."
         << endl;
  }
}

void sellExpiredItem(vector<shared_ptr<Vendor>> &cStreet,
                     vector<Customer> &students)
{
  string itemName1 = "Coca-Cola";
  string itemName2 = "Sprite";

  cout << endl << "Trying to sell expired items..." << endl;
  if(students.at(0).buyEntree(cStreet.at(0), itemName1))
  {
    cout << itemName1 << " was purchased..." << endl;
  } else {
    cout << "Sorry, that item was not instock..."
         << endl;
  }

  if(students.at(0).buyEntree(cStreet.at(0), itemName2))
  {
    cout << itemName2 << " was purchased..." << endl;
  } else {
    cout << "Sorry, that item was not instock..."
         << endl;
  }
}
