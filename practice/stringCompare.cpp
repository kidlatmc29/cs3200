// string comparison testing
// Isabel Ovalles

#include <iostream>
#include <string>

using namespace std;

int main()
{
  string d1 = "12/10/21";
  string d2 = "12/11/21";

  int comparison = d1.compare(d2);

  if(comparison == 0) {
    cout << "d1 and d2 are the same";
  } else if(comparison > 0)
   {
     cout << "d1 is greater than d2" << endl;
   } else {
     cout << "d1 is less than d2" << endl;
   }
  return 0;
}
