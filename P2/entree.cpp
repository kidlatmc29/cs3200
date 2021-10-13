// Isabel Ovalles
// entree.cpp

#include <iostream>
#include <sstream>
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

Entree& Entree::operator=(const Entree& original)
{
	if(&original != this)
	{
		name = original.name;
		ingredients = original.ingredients;
		string *newNutrStats = new string[NUM_OF_NUTR_STATS];
		for(int i = NUM_OF_NUTR_STATS; i < NUM_OF_NUTR_STATS; i++)
		{
			newNutrStats[i] = original.nutritionStats[i];
		}
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
	return nutritionStats[NUM_OF_SERVINGS];
}

string Entree::getCalories()
{
	return nutritionStats[CALORIES];
}

string Entree::getTotalFat()
{
	return nutritionStats[TOTAL_FAT];
}

string Entree::getSatFat()
{
	return nutritionStats[SAT_FAT];
}

string Entree::getTransFat()
{
	return nutritionStats[TRANS_FAT];
}

string Entree::getCholest()
{
	return nutritionStats[CHOLEST];
}

string Entree::getSodium()
{
	return nutritionStats[SODIUM];
}

string Entree::getTotalSugar()
{
	return nutritionStats[TOTAL_SUGAR];
}

string Entree::getProtein()
{
	return nutritionStats[PROTEIN];
}

void Entree::powerOut()
{
	isRefrigerated = false;
}

bool Entree::isExpired()
{
	bool isExpired;
	// create tm struct from expirationDate
	struct tm expDate;
	strptime(expirationDate.c_str(), "%D", &expDate);

	// get current date
	time_t today = time(0);
	tm *ltm = localtime(&today);

	//compares expDate with ltm
	if(expDate.tm_year > ltm->tm_year)
	{
		isExpired = false;
	}
	else if(expDate.tm_year < ltm->tm_year)
	{
		isExpired = true;
	}
	else {
		if(expDate.tm_mon == ltm->tm_mon &&
			expDate.tm_mday == ltm->tm_mday)
		{
			isExpired = true;
		}
		else
		{
			isExpired = false;
		}
	}
	return isExpired;
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
