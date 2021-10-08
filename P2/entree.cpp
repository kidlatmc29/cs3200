// Isabel Ovalles
// entree.cpp

#include <iostream>
#include "entree.h"

Entree::Entree(string name, string ingredients, string *nutrionStats,
	string contains, string expirationDate, bool needsRefridge, bool refrigerated)
{
	this->name = name;
	this->ingredients = ingredients;
	this->nutritionStats = nutrionStats;
	this->contains = contains;

	this->expirationDate = expirationDate;
	this->needsRefridge = needsRefridge;
	this->refrigerated = refrigerated;
}

Entree::~Entree()
{
	delete[] nutritionStats;
	// sets pointers to null
	nutritionStats = nullptr;
}

Entree::Entree(const Entree& orginal)
{

}

string Entree::getName()
{
	return name;
}

bool Entree::getSpoiled()
{
	return ((needsRefridge && !refrigerated) || getExpired());
}

bool Entree::getIsRefridge()
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
