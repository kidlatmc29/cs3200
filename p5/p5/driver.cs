using System;
using System.Collections.Generic;
using System.IO;

namespace p5
{
    class driver
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            Vendor cStreet = new Vendor("cStreet", true);
            List<ICustomer> students = new List<ICustomer>();
            List<Entree> fallStock = new List<Entree>();

            Console.WriteLine("Welcome to P5\n");

            loadEntrees("EntreesTabDelimited.txt", fallStock, generator);
            loadVendor(cStreet, fallStock, generator);
            loadStudents(students, generator);
            addBalance(students);
            getAllBalances(students);

            buyAppleSlices(students, cStreet);
            buyManyItems(students, cStreet);

            getAllBalances(students);

            Console.WriteLine("End of P5");
        }

        static public bool getRandomBool(Random generator)
        {
            int range = 2;
            return (generator.Next(range) == 1);
        }

        static public DateTime getRandomDate(Random generator)
        {
            DateTime lowerBounds = new DateTime(2019, 1, 1); // oldest expiration date is Jan 1st, 2020
            DateTime upperBounds = new DateTime(2030, 1, 1); // latest expiration date is Jan 1st, 2030
            int range = (upperBounds - lowerBounds).Days;

            return lowerBounds.AddDays(generator.Next(range));
        }

        static public int getRandomDouble(Random generator)
        {
            int lower = 1;
            int upper = 100;
            int range = upper - lower;
            return generator.Next(range);
        }

        static public double getRandomPrice(Random generator)
        {
            double lower = 1.00;
            double upper = 15.00;
            double range = upper - lower;

            return generator.NextDouble() * (upper - lower) + lower;
        }

        static public void loadEntrees(string fileName, List<Entree> foods, Random generator)
        {
            string txtLine;
            int lineCount = 1; // used to skip the first line in the .txt file

            if (File.Exists(fileName))  // check if file exists
            {
                StreamReader file = new StreamReader(fileName); // if file exists open it
                while ((txtLine = file.ReadLine()) != null)  // need to write more specific parsing for members
                {
                    if (lineCount != 1)
                    {
                        foods.Add(new Entree(txtLine, getRandomDate(generator), getRandomBool(generator), getRandomBool(generator)));
                    }
                    lineCount++;
                }
                file.Close(); // close file
            }
            else
            {
                Console.WriteLine("File does not exists! :( \n");
            }
        }

        static public void loadVendor(Vendor market, List<Entree> foods, Random generator)
        {
            for (int i = 0; i < foods.Count; i++)
            {
                market.load(foods[i], getRandomDouble(generator), getRandomPrice(generator));
            }
        }

        static public void loadStudents(List<ICustomer> students, Random generator)
        {
            // creating customers
            allergyCustomer isabel = new allergyCustomer(1, getRandomDouble(generator));
            allergyCustomer ben = new allergyCustomer(2, getRandomDouble(generator));
            isabel.addAllergen("peanuts");
            isabel.addAllergen("shellfish");
            ben.addAllergen("cashews");
            ben.addAllergen("fish");
            dbetCustomer kevin = new dbetCustomer(3, getRandomDouble(generator));
            dbetCustomer sammy = new dbetCustomer(4, getRandomDouble(generator));
            carbCustomer linda = new carbCustomer(5, getRandomDouble(generator));
            carbCustomer max = new carbCustomer(6, getRandomDouble(generator));
            EmployeeCustomer employee_isabel = new EmployeeCustomer("Isabel", "Ovalles", 1, "Whole Foods", isabel);
            EmployeeCustomer employee_sammy = new EmployeeCustomer("Sammy", "Wills", 3, "Trader Joe's", sammy);

            students.Add(isabel);
            students.Add(ben);
            students.Add(kevin);
            students.Add(sammy);
            students.Add(linda);
            students.Add(max);
            students.Add(employee_isabel);
            students.Add(employee_sammy);
        }

        static public void addBalance(List<ICustomer> students)
        {
            Console.WriteLine("Adding $5.00 to all Customers' Balances....\n");
            for (int i = 0; i < students.Count; i++)
            {
                students[i].addMoney(5.00);
            }
        }

        static public void getAllBalances(List<ICustomer> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                string balance = String.Format("{0:0.00}", students[i].getCurrentBalance());
                Console.WriteLine("Account " + students[i].getAccountNum() + " Balance: $" + balance);
            }
            Console.WriteLine("\n");
        }

        static public void buyAppleSlices(List<ICustomer> students, Vendor market)
        {
            string itemName = "Fresh Brand - Sliced Apples";
            bool valid;

            Console.WriteLine("Calling buyOne(Fresh Brand - Sliced Apples) on all Customers....");

            if (market.isStocked(itemName))
            {
                Console.WriteLine("Fresh Brand - Sliced Apples are in stock!");
                double itemPrice = market.getItemPrice("Fresh Brand - Sliced Apples");
                Console.WriteLine("The price of Fresh Brand - Sliced Apples is $" + String.Format("{0:0.00}", itemPrice));
            }
            else
            {
                Console.WriteLine("Fresh Brand - Sliced Apples are not in stock!");
            }

            for (int i = 0; i < students.Count; i++)
            {
                valid = students[i].buyOne(market, itemName);
                if (valid)
                {
                    Console.WriteLine("Account " + students[i].getAccountNum() + " made a purchase.");
                }
                else
                {
                    Console.WriteLine("Account " + students[i].getAccountNum() + " did not make a purchase.");
                }
            }
            Console.WriteLine("\n");
        }

        static public void buyManyItems(List<ICustomer> students, Vendor market)
        {
            bool valid;
            Console.WriteLine("Calling buy() on all Customers....");
            for (int i = 0; i < students.Count; i++)
            {
                valid = students[i].buy(market);
                if (valid)
                {
                    Console.WriteLine("Account " + students[i].getAccountNum() + " made purchase(s).");
                }
                else
                {
                    Console.WriteLine("Account " + students[i].getAccountNum() + " did not make a purchase.");
                }
            }
            Console.WriteLine("\n");
        }
    }
}
