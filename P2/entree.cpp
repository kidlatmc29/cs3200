// Isabel Ovalles
// entree.cpp

#include <iostream>
#include <sstream>
#include "entree.h"

Entree::Entree(string name, string ingredients, string nutritionStats,
	string contains, string expirationDate, bool needsRefridge, bool refrigerated)
{
	this->name = name;
	this->ingredients = ingredients;
	setNutritionStats(nutritionStats);
	this->contains = contains;

	this->expirationDate = expirationDate;
	this->needsRefridge = needsRefridge;
	this->refrigerated = refrigerated;
}

Entree::~Entree()
{
}

Entree::Entree(const Entree& orginal)
{

}

void Entree::setNutritionStats(string stats)
{
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
	return ((needsRefridge && !refrigerated) || getExpired());
}

bool Entree::isRefrigerated()
{
	return refrigerated;
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

void Entree::powerOut()
{

}

bool Entree::hasIngredient(string target)
{
	return false;
}
