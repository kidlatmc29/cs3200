// Entree.h 
// Isabel Ovalles

#include <vector>
#include <ctime>

class Entree {
	//Class and Interface invarients: 

	private:
		string name;
		vector<string> *ingredients; 
		vector<string> *nutritionStats;
		vector<string> *contains;

		string experiationDate; 
		
		bool needsRefridge;
		bool refrigerated; 
		bool spoiled;
		
		
	public:
		// constructor
		Entree(string name, vector<string> *ingredients, vector<string> *nutrionStats, 
						vector<string> *contains, bool needsRefridge, bool refrigerated);

		// copy constrtor
		Entree(const Entree& original);
		
		// deconstructor
		~Entree();

		bool isSpoiled();
};
