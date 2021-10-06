// Entree.cpp
// Isabel Ovalles

#include <iostream>
#include <string>
#include <sstream>
#include <ctime>
#include "Entree.h"

using namespace std;

Entree::Entree(string name, vector<string> *ingredients, vector<string> *nutrionStats,
	vector<string> *contains, string expirationDate, bool needsRefridge, bool refrigerated)
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
	// clears contents of vectors
	ingredients->clear();
	nutritionStats->clear();
	contains->clear();

	// removes memory allocated for vectors
	ingredients->resize(0);
	nutritionStats->resize(0);
	contains->resize(0);

	// sets pointers to null
	ingredients = nullptr;
	nutritionStats = nullptr;
	contains = nullptr;
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

void Entree::powerOut()
{

}

bool Entree::hasIngredient(string target)
{
	return false;
}
