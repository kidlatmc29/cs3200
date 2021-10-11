// Isabel Ovalles
// Oct 2, 2021

#include <iostream>
#include "entree.h"

using namespace std;

void makeCookieEntree();

int main()
{
    cout << "Welcome to P2" << endl << endl;
    makeCookieEntree();
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
