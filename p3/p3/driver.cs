using System;
using System.IO;
using System.Collections.Generic;

namespace p3
{
    class driver
    {
        static void Main(string[] args)
        {
            Random generator = new Random();
            Vendor cStreet = new Vendor("cStreet", true);
            List<Customer> students = new List<Customer>();
            List<Entree> fallStock = new List<Entree>();

            Console.WriteLine("Welcome to P3");
            loadEntrees("EntreesTabDelimited.txt", fallStock, generator);
            Console.WriteLine("Num of Entrees in fallStock = " + fallStock.Count);
            loadVendor(cStreet, fallStock, generator);
            Console.WriteLine("Num of Items in cStreet = " + cStreet.getSize());

            Console.WriteLine("End of P3");
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

        static public int getRandomQty(Random generator)
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
            for(int i = 0; i < foods.Count; i++)
            {
                market.load(foods[i], getRandomQty(generator), getRandomPrice(generator));
            }
        }
    }
}
