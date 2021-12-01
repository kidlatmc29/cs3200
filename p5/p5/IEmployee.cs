using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
   interface IEmployee
    {
        int getPayLvl();
        void setPayLvl(int payLvl);
        double getAccountBalance();
        string getEmployer();
        void setEmployer(string e);
        void weeklyPay();
        string getFName();
        string getLName();
        void setFName(string fName);
        void setLName(string lName);
    }
}
