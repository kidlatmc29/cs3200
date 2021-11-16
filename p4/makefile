P4driver: P4driver.o entree.o vendor.o customer.o dbetCustomer.o carbCustomer.o allergyCustomer.o
	g++ -o p4 P4driver.o entree.o vendor.o customer.o dbetCustomer.o carbCustomer.o allergyCustomer.o

P4driver.o: P4driver.cpp
	g++ -c -pedantic -Wall -Werror P4driver.cpp

entree.o: entree.cpp
	g++ -c -pedantic -Wall -Werror entree.cpp

vendor.o: vendor.cpp
	g++ -c -pedantic -Wall -Werror vendor.cpp

customer.o: customer.cpp
	g++ -c -pedantic -Wall -Werror customer.cpp

dbetCustomer.o : dbetCustomer.cpp
	g++ -c -pedantic -Wall -Werror dbetCustomer.cpp

carbCustomer.o : carbCustomer.cpp
	g++ -c -pedantic -Wall -Werror carbCustomer.cpp

allergyCustomer.o : allergyCustomer.cpp
		g++ -c -pedantic -Wall -Werror allergyCustomer.cpp

clean:
	rm *.o
