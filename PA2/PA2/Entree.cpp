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
	spoiled = isSpoiled();
}

Entree::~Entree()
{
	ingredients->clear();
	nutritionStats->clear();
	contains->clear();
}

Entree::Entree(const Entree& orginal)
{

}


bool Entree::isSpoiled() 
{

}
