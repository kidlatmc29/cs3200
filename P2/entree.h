// Isabel Ovalles
// entree.h

#include<string>
#include<ctime>
using namespace std;

class Entree {
  //Class and Interface invarients:
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

    void setNutritionStats(string stats);

  	string getName();

  	string getExpirationDate();

  	// getters for nutr stats
    string getNumOfServings();

    string getCalories();

    string getTotalFat();

    string getSatFat();

    string getTransFat();

    string getCholest();

    string getSodium();

    string getTotalSugar();

    string getProtein();

  	void powerOut();

    bool isExpired();

    bool isSpoiled();

  	bool hasIngredient(string target);

  // Implementation Invarients:
};
