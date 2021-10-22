// Isabel Ovalles
// entree.cpp

#include "entree.h"

Entree::Entree(string name, string ingredients, string nutritionStats,
							 string contains, string expirationDate, bool needsRefridge,
							 bool isRefrigerated)
{
	this->name = name;
	this->ingredients = ingredients;
	setNutritionStats(nutritionStats);
	this->contains = contains;

	this->expirationDate = expirationDate; // assuming MM/DD/YY format
	this->needsRefridge = needsRefridge;
	this->isRefrigerated = isRefrigerated;
}

Entree::Entree()
{
	name = "";
	ingredients = "";
	nutritionStats = nullptr;
	contains = "";
	expirationDate = "";
	needsRefridge = false;
	isRefrigerated = false;
}

Entree::Entree(const Entree &original)
{
	name = original.name;
	ingredients = original.ingredients;
	string *newNutrStats = new string[NUM_OF_NUTR_STATS];
	for(int i = 0; i < NUM_OF_NUTR_STATS; i++)
	{
		newNutrStats[i] = original.nutritionStats[i];
	}

	nutritionStats = newNutrStats;

	contains = original.contains;
	expirationDate = original.expirationDate;
	needsRefridge = original.needsRefridge;
	isRefrigerated = original.isRefrigerated;
}

Entree& Entree::operator=(const Entree& original)
{
	if(&original != this)
	{
		name = original.name;
		ingredients = original.ingredients;
		string *newNutrStats = new string[NUM_OF_NUTR_STATS];
		for(int i = 0; i < NUM_OF_NUTR_STATS; i++)
		{
			newNutrStats[i] = original.nutritionStats[i];
		}

		nutritionStats = newNutrStats;

		contains = original.contains;
		expirationDate = original.expirationDate;
		needsRefridge = original.needsRefridge;
		isRefrigerated = original.isRefrigerated;
	}
	return *this;
}

Entree::Entree(Entree&& original)
{
	name = original.name;
	ingredients = original.ingredients;
	nutritionStats = original.nutritionStats;
	contains = original.contains;
	expirationDate = original.expirationDate;
	needsRefridge = original.needsRefridge;
	isRefrigerated = original.isRefrigerated;

	original.name = "";
	original.ingredients = "";
	original.nutritionStats = nullptr;
	original.contains = "";
	original.expirationDate = "";
	original.needsRefridge = false;
	original.isRefrigerated = false;
}

Entree& Entree::operator=(const Entree&& original)
{
	if(&original != this)
	{
		name = original.name;
		ingredients = original.ingredients;
		nutritionStats = original.nutritionStats;
		contains = original.contains;
		expirationDate = original.expirationDate;
		needsRefridge = original.needsRefridge;
		isRefrigerated = original.isRefrigerated;
	}
	return *this;
}

Entree::~Entree()
{
	delete[] nutritionStats;
	nutritionStats = nullptr;
}

void Entree::setNutritionStats(string stats)
{
	nutritionStats = new string[NUM_OF_NUTR_STATS];

	stringstream ss(stats);
	string stat;
	int count = 0;

	while (ss >> stat)
	{
		nutritionStats[count] = stat;
		count++;
	}
}

string Entree::getName()
{
	return name;
}

string Entree::getExpirationDate()
{
	return expirationDate;
}

string Entree::getNumOfServings()
{
	string servings = "";
	if(nutritionStats != nullptr) {
		servings = nutritionStats[NUM_OF_SERVINGS];
	}

	return servings;
}

string Entree::getCalories()
{
	string calories = "";
	if(nutritionStats != nullptr) {
		calories = nutritionStats[CALORIES];
	}
	return calories;
}

string Entree::getTotalFat()
{
	string totalFat = "";
	if(nutritionStats != nullptr) {
		totalFat = nutritionStats[TOTAL_FAT];
	}
	return totalFat;
}

string Entree::getSatFat()
{
	string satFat = "";
	if(nutritionStats != nullptr) {
		satFat = nutritionStats[SAT_FAT];
	}
	return satFat;
}

string Entree::getTransFat()
{
	string transFat = "";
	if(nutritionStats != nullptr) {
		transFat = nutritionStats[TRANS_FAT];
	}
	return transFat;
}

string Entree::getCholest()
{
	string cholest = "";
	if(nutritionStats != nullptr) {
		cholest = nutritionStats[CHOLEST];
	}
	return cholest;
}

string Entree::getSodium()
{
	string sodium = "";
	if(nutritionStats != nullptr) {
		sodium = nutritionStats[SODIUM];
	}
	return sodium;
}

string Entree::getTotalCarbs()
{
	string totalCarbs = "";
	if(nutritionStats != nullptr) {
		totalCarbs = nutritionStats[TOTAL_CARBS];
	}
	return totalCarbs;
}

string Entree::getFiber()
{
	string fiber = "";
	if(nutritionStats != nullptr) {
		fiber = nutritionStats[FIBER];
	}
	return fiber;
}

string Entree::getTotalSugar()
{
	string totalSugar = "";
	if(nutritionStats != nullptr) {
		totalSugar = nutritionStats[TOTAL_SUGAR];
	}
	return totalSugar;
}

string Entree::getProtein()
{
	string protein = "";
	if(nutritionStats != nullptr) {
		protein = nutritionStats[PROTEIN];
	}
	return protein;
}

void Entree::powerOut()
{
	isRefrigerated = false;
}

bool Entree::isExpired()
{
	//get today's Date
	time_t today = time(0);

	// convert expirationDate into time_t
	struct tm tm;
	istringstream inputss(expirationDate);
	inputss >> get_time(&tm, "m%/d%/y%");
	time_t expDate = mktime(&tm);

	// find diff of between today and exp date
	double diff = difftime(expDate, today);
	// cout << "diff = " << diff << endl;
	// if diff is negative or = to 0, expDate has occurred
	return diff <= 0.0;
}

bool Entree::isSpoiled()
{
	return ((needsRefridge && !isRefrigerated) || isExpired());
}

bool Entree::hasIngredient(string target)
{
	bool foundIngredient = false;
	if(target != "") {
		size_t found = ingredients.find(target);
		if(found != string::npos)
		{
			foundIngredient = true;
		}
	}
	return foundIngredient;
}
