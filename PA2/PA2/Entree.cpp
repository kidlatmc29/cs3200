// Entree.cpp
// Isabel Ovalles

#include <iostream>
#include <string>
#include <sstream>
#include <ctime>
#include "Entree.h"

using namespace std;

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
	setSpoiled();
	setExpired();
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

void Entree::setSpoiled() 
{
	if ((needsRefridge && !refrigerated) || getExpired()) {
		spoiled = true;
	}
}

void Entree::setExpired()
{

	// can we use a const???? 
}

string Entree::getName()
{
	return name;
}

bool Entree::getSpoiled() 
{
	return spoiled;
}

bool Entree::getIsRefridge()
{
	return getIsRefridge;
}

bool Entree::getExpired()
{
	return expired; 
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
