// P2.cpp 
// Isabel Ovalles
// Oct 2, 2021


#include <iostream>
#include "Entree.h"
using namespace std; 

int main()
{
  string cookieName = "Grandma's Chocolate Chip Cookies";
  string* cookieNutr = new string[11]; // 2	200	10	4	0	0	125	25	1	12	2
  cookieNutr[0] = "2";
  cookieNutr[1] = "200";
  cookieNutr[2] = "10";
  cookieNutr[3] = "4";
  cookieNutr[4] = "0";
  cookieNutr[5] = "0";
  cookieNutr[6] = "125";
  cookieNutr[7] = "25";
  cookieNutr[8] = "1";
  cookieNutr[9] = "12";
  cookieNutr[10] = "2";
  string cookieIng = "Enriched flour(bleached wheat flour, niacin, reduced iron, thiamin mononitrate, roboflavin, folic acid)$vegetable shortening (palm and canola oil [with TBHQ to preserve freshness])$ semi-sweet chocolate chips (sugar, chocolate liquor, cocoa butter, dextrose, milk fat, soy lecithin, natural and artificial flavors)$sugar$high fructose corn syrup$dairy product solids$less 2% of$molasses$fructose$modified corn starch$polydextrose$leavening (baking soda, ammonium bicarbonate)$propylene glycol mono- and diesters of fats and fatty acides, mono- and diglycerides$soy lecithin$salt$eggs$caramel color$natural and artificial flavors";
  string cookieContains = "egg$milk$soy$wheat";
  
  Entree cookie(cookieName, cookieIng,cookieNutr,cookieContains, "5/1/2028", false, false);
  cout << "Welcome to P2" << endl << endl;
  cout << "Creating an Entree..." << endl;

}
