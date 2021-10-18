// Isabel Ovalles
// Oct 2, 2021

#include <iostream>
#include "vendor.h"

using namespace std;

void makeCookieEntree();
void loadVendingMachine();
void cleanStockOnVendingMachine();
void findInStockItem();
void buyAndSell();

int main()
{
  cout << endl << "Welcome to P2" << endl << endl;

  // makeCookieEntree();
  // loadVendingMachine();
  // cleanStockOnVendingMachine();
  findInStockItem();
  cout << endl << "End of P2" << endl << endl;
  return 0;
}

void makeCookieEntree()
{
  string cookieName = "Grandma's Chocolate Chip Cookies";
  string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";

  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";

  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/22",
                  false, false);

  cout << "Creating an Entree..." << endl << endl;

  cout << "Entree Name: " << cookie.getName() << endl;
  cout << "Entree Expiration Date: " << cookie.getExpirationDate() << endl;
  cout << "Entree Nutrition Facts ========================================="
       << endl;
  cout << "Num Of Servings: " << cookie.getNumOfServings() << endl;
  cout << "Calories: " << cookie.getCalories() << endl;
  cout << "Total Fat: " << cookie.getTotalFat() << endl;
  cout << "Saturated Fat: " << cookie.getSatFat() << endl;
  cout << "Trans Fat: " << cookie.getTransFat() << endl;
  cout << "Cholestorol: " << cookie.getCholest() << endl;
  cout << "Sodium: " << cookie.getSodium() << endl;
  cout << "Total Sugar: " << cookie.getTotalSugar() << endl;
  cout << "Protein: " << cookie.getProtein() << endl;
  cout << "================================================================="
       << endl;

  cout << "Does cookie contain peanuts? ";
  if(cookie.hasIngredient("peanuts")) {
    cout << "YES" << endl;
  }
  else
  {
    cout << "NO" << endl;
  }

  cout << "Does cookie contain Enriched flour? ";
  if(cookie.hasIngredient("Enriched flour")) {
    cout << "YES" << endl;
  }
  else
  {
    cout << "NO" << endl;
  }

  cout << "Does cookie contain \"\"? ";
  if(cookie.hasIngredient("")) {
    cout << "YES";
  }
  else
  {
    cout << "NO" << endl;
  }

  cout << "Is Cookie expired?" << endl;
  if(cookie.isExpired())
  {
    cout << "YES";
  } else {
    cout << "NO";
  }
}

void loadVendingMachine()
{
  Vendor snacks("Snaccc", true);
  cout << "This vendor's name is: " << snacks.getName() << endl;

  string pieName = "Apple Pie";
  string pieNutr = "3 100 12 1 0 0 126 28 1 19 0";
  string pieIng = "Apples (Apples, Ascorbic Acid, Salt, Citric Acid), Enriched Flour (Bleached Wheat Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Sugar, Palm Oil, Water, Apple Juice Concentrate, Modified Food Starch, Invert Syrup, Contains 2% or Less: Yeast, Salt, Cinnamon, Sunflower Lecithin, L-cysteine (Dough Conditioner), Yeast Extract, Enzyme, Beta-carotene (Color)";
  string pieContains = "wheat";
  Entree pie(pieName, pieIng, pieNutr, pieContains, "11/12/30", true, true);

  string cookieName = "Grandma's Chocolate Chip Cookies";
  string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";
  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";
  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/28",
                  false, false);

  snacks.load(pie, 11, 4.00);
  snacks.load(cookie, 5, 1.00);

  int s = snacks.getSize();
  cout << "Size of snacks is " << s << endl;

  Vendor librarySnacks("Byte Cafe", true);

  librarySnacks = snacks;

  cout << "The number of items in librarySnacks is " << librarySnacks.getSize()
       << endl;
}

void cleanStockOnVendingMachine()
{
  string cookieName = "Grandma's Chocolate Chip Cookies";
  string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";
  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";
  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/21",
                  false, false);

  string pieName = "Apple Pie";
  string pieNutr = "3 100 12 1 0 0 126 28 1 19 0";
  string pieIng = "Apples (Apples, Ascorbic Acid, Salt, Citric Acid), Enriched Flour (Bleached Wheat Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Sugar, Palm Oil, Water, Apple Juice Concentrate, Modified Food Starch, Invert Syrup, Contains 2% or Less: Yeast, Salt, Cinnamon, Sunflower Lecithin, L-cysteine (Dough Conditioner), Yeast Extract, Enzyme, Beta-carotene (Color)";
  string pieContains = "wheat";
  Entree pie(pieName, pieIng, pieNutr, pieContains, "11/12/30", true, true);

  string carrotName = "Carrot Sticks";
  string carrotNutr = "1 50 1 0 0 0 84 12 0 6 1";
  string carrotIng = "Carrots";
  string carrotContains = "";
  Entree carrotSticks(carrotName, carrotIng, carrotNutr, carrotContains, "10/13/21", true, false);

  Vendor cStreet("Quik Foods", true);

  cStreet.load(pie, 11, 4.00);
  cStreet.load(cookie, 5, 1.00);
  cStreet.load(carrotSticks, 20, .50);

  cout << "Size of Quik Food: " << cStreet.getSize() << endl;
  cout << "Cleaning Stock...." << endl;
  cStreet.cleanStock();

  cout << "Size of Quik Food is now: " << cStreet.getSize() << endl;
}

void findInStockItem()
{
  string itemName = "Apple Pie";

  string cookieName = "Grandma's Chocolate Chip Cookies";
  string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";
  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";
  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/28",
                  false, false);

  string pieName = "Apple Pie";
  string pieNutr = "3 100 12 1 0 0 126 28 1 19 0";
  string pieIng = "Apples (Apples, Ascorbic Acid, Salt, Citric Acid), Enriched Flour (Bleached Wheat Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Sugar, Palm Oil, Water, Apple Juice Concentrate, Modified Food Starch, Invert Syrup, Contains 2% or Less: Yeast, Salt, Cinnamon, Sunflower Lecithin, L-cysteine (Dough Conditioner), Yeast Extract, Enzyme, Beta-carotene (Color)";
  string pieContains = "wheat";
  Entree pie(pieName, pieIng, pieNutr, pieContains, "10/12/21", true, false);

  Vendor snacks("Snacc", true);
  snacks.load(pie, 11, 4.00);
  snacks.load(cookie, 5, 1.00);

  bool inStock = snacks.isStocked(itemName);

  if(inStock)
  {
    cout << "Apple Pie is instock" << endl;
  } else {
    cout << "sorry, " << itemName << " is not in stock" << endl;
  }
}

void buyAndSell()
{
    Vendor drinks("Soda Machine", true);

    string soda1Name = "Coca-Cola";
    string soda1Nutr = "1 240 0 0 0 0 75 65 0 65 0";
    string soda1Ing = "CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CARAMEL COLOR$PHOSPHORIC ACID$NATURAL FLAVORS$CAFFEINE";
    string soda1Contains = "";
    Entree soda1(soda1Name, soda1Ing, soda1Nutr, soda1Contains, "12/20/20", true, true);

    string soda2Name = "Sprite";
    string soda2Nutr = "1 140 0 0 0 0 75 65 0 65 0";
    string soda2Ing = "CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$NATURAL FLAVORS$SODIUM CITRATE$SODIUM BENZOATE ";
    string soda2Contains = "";
    Entree soda2(soda2Name, soda2Ing, soda2Nutr, soda2Contains, "12/20/21", true, true);

    string soda3Name = "Fanta";
    string soda3Nutr = "1 270 0 0 0 0 75 73 0 73 0";
    string soda3Ing = "CARBONATED WATER$HIGH FRUCTOSE CORN SYRUP$CITRIC ACID$SODIUM BENZOATE (TO PROTECT TASTE)$NATURAL FLAVORS$MODIFIED FOOD STARCH$SODIUM POLYPHOSPHATES$GLYCEROL ESTER OF ROSIN$YELLOW 6$RED 40";
    string soda3Contains = "";
    Entree soda3(soda3Name, soda3Ing, soda3Nutr, soda3Contains, "12/20/21", true, true);

    drinks.load(soda1, 3, 2.00);
    drinks.load(soda2, 10, 2.00);
    drinks.load(soda3, 10, 2.00);

    Customer student(1000, 10.00);

    student.buyEntree(load, "Sprite");
}


// testing Entrees
/**
string cookieName = "Grandma's Chocolate Chip Cookies";
string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";
string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
string cookieContains = "egg$milk$soy$wheat";
Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/28",
                false, false);

string pieName = "Apple Pie";
string pieNutr = "3 100 12 1 0 0 126 28 1 19 0";
string pieIng = "Apples (Apples, Ascorbic Acid, Salt, Citric Acid), Enriched Flour (Bleached Wheat Flour, Niacin, Reduced Iron, Thiamine Mononitrate, Riboflavin, Folic Acid), Sugar, Palm Oil, Water, Apple Juice Concentrate, Modified Food Starch, Invert Syrup, Contains 2% or Less: Yeast, Salt, Cinnamon, Sunflower Lecithin, L-cysteine (Dough Conditioner), Yeast Extract, Enzyme, Beta-carotene (Color)";
string pieContains = "wheat";
Entree pie(pieName, pieIng, pieNutr, pieContains, "11/12/30", true, true);
**/
