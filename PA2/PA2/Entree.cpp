// Entree.cpp
// Isabel Ovalles

#include <iostream>
#include "Entree.h"

using namespace std;

Entree::Entree(string name, vector<string> *ingredients, vector<string> *nutrionStats,
	vector<string> *contains, bool needsRefridge, bool refrigerated)
{
	this->name = name;
	this->ingredients = ingredients;
	this->nutritionStats = nutrionStats;
	this->contains = contains;

	this->needsRefridge = needsRefridge;
	this->refrigerated = refrigerated;
	spoiled = setIsSpoiled();
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

bool Entree::setIsSpoiled() 
{
	if ((needsRefridge && !refrigerated) || isExpired()) {
		spoiled = true;
	}
}

bool Entree::getIsSpoiled() 
{
	return spoiled;
}


