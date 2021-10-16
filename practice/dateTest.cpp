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

  cout << "Today's Date is: " << 1 + ltm->tm_mon
       << "/" << ltm->tm_mday << "/" << 1900 + ltm->tm_year << endl;

  // creating date from a string
  // time_t birthday;
  struct tm birthdayStruct;
  strptime("12/25/01", "%D", &birthdayStruct);

  cout << "My birthday is: " << birthdayStruct.tm_mon + 1 << "/"
       << birthdayStruct.tm_mday << "/"
       << 1900 + birthdayStruct.tm_year << endl;

  cout << "Have I had my birthday?" << endl;
  if(birthdayStruct.tm_mon == ltm->tm_mon)
  {
    if(birthdayStruct.tm_mday == ltm->tm_mday)
    {
      cout << "Today is my birthday!" << endl;
    } else if(birthdayStruct.tm_mday > ltm->tm_mday)
    {
      cout << "My birthday is later this month." << endl;
    } else {
      cout << "My birthday was earlier this month." << endl;
    }
  }
  else if(birthdayStruct.tm_mon > ltm->tm_mon)
  {
    cout << "My birthday is later this year." << endl;
  }
  else
  {
    cout << "My birthday was earlier this year." << endl;
  }
  cout << endl;

  return 0;
}
