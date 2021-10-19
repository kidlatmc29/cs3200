// Isabel Ovalles
// entree.h

#include <string>
#include <ctime>
#include <sstream>
#include <iostream>
#include <iomanip>

using namespace std;

// Class invarients:
// -An Entree object holds a list of ingredients, nutrition facts,
//    contains of allergens, an expiration date, as well as if it needs
//    refridgeration and if it is refrigerated.
// -Entree object will be in a valid state when instantiated with the
//    parameterized ctor.
// -Cannot get any member variable unless Entree is initalized.

// Interface invarients:
//  -When instantiating an Entree object, the client is responsible for:
//    1.) The expiration date must be in MM/DD/YY for expected results.
//    2.) All nutritional facts must be passed to the ctor and be in the correct
//          order.
//    3.) The ingredients list and contains must have the $ as the delimiter
//        between ingredients.

// Implementation invarients:
// -Client cannot get nutritional stats if the Entree's nutritionalStat is
//    nullptr
// -isExpired and isSpoiled is not saved as internal states, Client
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

  	// deconstructor
  	~Entree();

    // PRE: N/A
    // POST: N/A
    void setNutritionStats(string stats);

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
    bool isExpired();

    // PRE: N/A
    // POST: N/A
    bool isSpoiled();

    // PRE: target is given exactly as it's written in the ingredients list
    // POST: N/A
  	bool hasIngredient(string target);
};
