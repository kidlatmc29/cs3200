// dateTest.cpp

#include <iostream>
#include <ctime>
#include <sstream>

using namespace std;

int main()
{
  stringstream ss;
  string userDate;
  string todayDate;

  // get current date
  time_t today = time(0);
  tm *ltm = localtime(&today);
  todayDate = &(1 + ltm->tm_mon) + "/" + &(ltm->tm_mday) + "/" + &(1900 + ltm->tm_year);

  cout << "Today's Date is: " << 1 + ltm->tm_mon
       << "/" << ltm->tm_mday << "/" << 1900 + ltm->tm_year << endl;



  cout << "Please enter a date in MM/DD/YYYY format: ";
  cin >> userDate;
  cout << endl;

  return 0;
}
