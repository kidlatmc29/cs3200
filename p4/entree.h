// Isabel Ovalles
// entree.h

#include <string>
#include <algorithm>
#include <ctime>
#include <sstream>
#include <iostream>
#include <iomanip>

using namespace std;

// Class invarients:
// -An Entree object holds a list of ingredients, nutrition facts,
//    contains of allergens, an expiration date, as well as if it needs
//    refrigeration and if it is refrigerated.
// -Entree object will be in a valid state when instantiated with the
//    parameterized ctor.
// -Cannot get any member variable unless Entree is initialized.
// - No overloading of any arithmatic, comparison, or logical operators. These
//    functionalities are not expected by the client.
// - The << operator is overloaded so clients can be able to view the contents
//    of an Entree easily
// - The == and != operator is overloaded so clients are able to compare
//    Entrees if they are same batch of Entrees

// Interface invarients:
//  -When instantiating an Entree object, the client is responsible for:
//    1.) The expiration date must be in MM/DD/YY for expected results.
//    2.) All nutritional facts must be passed to the ctor and be in the correct
//          order.

// Implementation invarients:
// -isExpired and isSpoiled is not saved as internal states, client
//    must request for states

class Entree {
  private:
    const int NUM_OF_NUTR_STATS = 11;
  	string name;
  	string ingredients;
  	string *nutritionStats;
  	string contains;
  	string expirationDate;
  	bool needsRefridge;
  	bool isRefrigerated;

  	enum nutritionStatIndex
  	{
			NUM_OF_SERVINGS = 0,
      CALORIES,
  		TOTAL_FAT,
  		SAT_FAT,
  		TRANS_FAT,
  		CHOLEST,
  		SODIUM,
      TOTAL_CARBS,
      FIBER,
  		TOTAL_SUGAR,
  		PROTEIN
  	};

  public:
  	// constructor
  	Entree(string name, string ingredients, string nutritionStats,
  				 string contains, string expirationDate, bool needsRefridge,
           bool isRefrigerated);

    // no param constructor
    Entree();

    // deep copy ctor
    Entree(const Entree &original);

    // deep copy assignment operator
    Entree& operator=(const Entree& original);

  	// move constructor
  	Entree(Entree&& original);

    // move assignment
    Entree& operator=(const Entree&& original);

    friend ostream& operator<<(ostream& os, const Entree& food);

    friend bool operator==(const Entree& a, const Entree& b);

    friend bool operator!=(const Entree& a, const Entree& b);

  	// deconstructor
  	~Entree();

    // PRE: N/A
    // POST: N/A
    void setNutritionStats(string stats);

    // PRE: N/A
    // POST: N/A
    string* getNutritionStats();

    // PRE: N/A
    // POST: N/A
  	string getName();

    // PRE: N/A
    // POST: N/A
  	string getExpirationDate();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getNumOfServings();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getCalories();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getTotalFat();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getSatFat();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getTransFat();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getCholest();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getSodium();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getTotalCarbs();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getFiber();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getTotalSugar();

    // PRE: nutritionStats is not nullptr to return value
    // POST: N/A
    string getProtein();

    // PRE: N/A
    // POST: isRefrigerated is set to false
  	void powerOut();

    // PRE: N/A
    // POST: N/A
    // Note: isExpired has a known issue where difftime() sometimes returns
    //  different values when the program is run. This can cause issues with
    //  other functions such as isSpoiled or cleanStock which could return
    //  an incorrect results.
    bool isExpired();

    // PRE: N/A
    // POST: N/A
    bool isSpoiled();

    // PRE: target is given exactly as it's written in the ingredients list
    // POST: N/A
  	bool hasIngredient(string target);
};
