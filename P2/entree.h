// Isabel Ovalles
// entree.h

#include<string>
using namespace std;

class Entree {
  //Class and Interface invarients:
  	private:
      const int NUM_OF_NUTR_STATS = 11;
  		string name;
  		string ingredients;
  		string nutritionStats[NUM_OF_NUTR_STATS];
  		string contains;

  		string expirationDate;

  		bool needsRefridge;
  		bool refrigerated;

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
  		Entree(string name, string ingredients, string nutrionStats,
  						string contains, string expirationDate, bool needsRefridge,
              bool refrigerated);

  		// copy constrtor
  		Entree(const Entree& original);

  		// deconstructor
  		~Entree();

      void setNutritionStats(string stats);

  		bool getSpoiled();

  		bool getIsRefridge();

  		string getName();

  		bool getExpired();

  		string getExpirationDate();

  		// getters for nutrionStats
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

  		bool hasIngredient(string target);

  // Implementation Invarients:

};
