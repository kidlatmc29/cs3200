p4: p4.o entree.o vendor.o customer.o
	g++ -o p4 p4.o entree.o vendor.o customer.o

p4.o: p4.cpp
	g++ -c -pedantic -Wall -Werror p4.cpp

entree.o: entree.cpp
	g++ -c -pedantic -Wall -Werror entree.cpp

vendor.o: vendor.cpp
	g++ -c -pedantic -Wall -Werror vendor.cpp

customer.o: customer.cpp
	g++ -c -pedantic -Wall -Werror customer.cpp
