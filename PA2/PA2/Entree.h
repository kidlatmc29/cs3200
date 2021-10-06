// Entree.h 
// Isabel Ovalles

#include <vector>
#include <ctime>

class Entree {
	//Class and Interface invarients: 

	private:
		string name;
		string ingredients; 
		string *nutritionStats;
		string contains;

		string expirationDate; 
		
		bool needsRefridge;
		bool refrigerated; 
		bool expired; 
		bool spoiled;
		
		enum nutritionStatIndex
		{
			numOfServings = 0,
			calories,
			totalFat,
			satFat,
			transFat,
			cholest,
			sodium,
			totalSugar,
			protein
		};
		
	public:
		// constructor
		Entree(string name, string ingredients, string *nutrionStats, 
						string contains, string expirationDate, bool needsRefridge, bool refrigerated);

		// copy constrtor
		Entree(const Entree& original);
		
		// deconstructor
		~Entree();

		void setSpoiled();

		void setExpired();

		bool getSpoiled();

		bool getIsRefridge();

		string getName();

		bool getExpired();

		// need to add getters for nutritional facts

		void powerOut();

		bool hasIngredient(string target);

// Implementation Invarients:

};
