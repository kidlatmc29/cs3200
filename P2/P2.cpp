// Isabel Ovalles
// Oct 2, 2021

#include <iostream>
#include "vendor.h"

using namespace std;

void makeCookieEntree();
void loadVendingMachine();

int main()
{
  cout << endl << "Welcome to P2" << endl << endl;

  // makeCookieEntree();
  loadVendingMachine();

  cout << endl << "End of P2" << endl << endl;
  return 0;
}

void makeCookieEntree()
{
  string cookieName = "Grandma's Chocolate Chip Cookies";
  string cookieNutr = "2 200 10 4 0 0 125 25 1 12 2";

  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";

  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "10/10/28",
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
  if(cookie.isExpired() == true)
  {
    cout << "YES" << endl;
  }
  else
  {
    cout << "NO" << endl;
  }

  cout << "Is cookie spoiled?" << endl;
  if(cookie.isSpoiled() == true)
  {
    cout << "YES" << endl;
  }
  else
  {
    cout << "NO" << endl;
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
Entree pie(pieName, pieIng, pieNutr pieContains, "11/12/30", true, true);
**/
