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

	this->expirationDate = expirationDate;
	this->needsRefridge = needsRefridge;
	this->isRefrigerated = isRefrigerated;
}

Entree::~Entree()
{
}

Entree::Entree(const Entree& orginal)
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

bool Entree::getSpoiled()
{
	return ((needsRefridge && !isRefrigerated) || getExpired());
}

bool Entree::getExpired()
{
	// if date is less than today's day, return true
	return false;
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

}

bool Entree::hasIngredient(string target)
{
	return false;
}
