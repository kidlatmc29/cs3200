// customer.h
// Isabel Ovalles

class Customer
{
  private:
    uint accountNum;
    double currentBalance;

  // behaviors
  // customers can buy entrees from vendors
  // customers can add money to their account

  public:
    Customer(int accountNum = 0000, double currentBalance = 0.0);

    ~Customer();

    void addMoney(double amount = 0.0);

    void buyEntree(Vendor market = nullptr, string entreeName = "");

};
