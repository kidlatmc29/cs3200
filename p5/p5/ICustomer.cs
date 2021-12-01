using System;
using System.Collections.Generic;
using System.Text;

namespace p5
{
    public interface ICustomer
    {
        void addMoney(double amount);
        bool buyOne(Vendor market, string itemName);
        bool buy(Vendor market);
        double getCurrentBalance();
        uint getAccountNum();
        void setAccountNum(uint num);
    }
}
