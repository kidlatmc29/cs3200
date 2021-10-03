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
	spoiled = setSpoiled();
	expired = setExpired();
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

bool Entree::setSpoiled() 
{
	if ((needsRefridge && !refrigerated) || getExpired()) {
		spoiled = true;
	}
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
string Entree::getName()
{
	return name;
}

bool Entree::setExpired()
{
	time_t today = time(0);
	char* todayChar = ctime(&today);

	char* parseExp = strtok(expirationDate, "/");

	return false;
}

void Entree::powerOut()
{
}

bool Entree::hasIngredient(string target)
{
	return false;
}
