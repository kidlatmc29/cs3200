// customer.h
// Isabel Ovalles

class customer
{
  private:
    uint accountNum;
    double currentBalance;

  // behaviors
  // customers can buy entrees from vendors
  // customers can add money to their account

  public:
    Customer();

    ~Customer();

    void addMoney(double amount = 0.0);

    void buyEntree(Vendor market = nullptr, string entreeName = "");

};
