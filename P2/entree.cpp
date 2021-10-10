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
	delete[] nutritionStats;
	nutritionStats = nullptr;
}

Entree::Entree(const Entree& orginal)
{
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
	time_t today = time(0);
	char *todayChar = ctime(&today);

	// convert char array into string to compare
	cout << "Today's Date: " << 

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
	isRefrigerated = false;
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
