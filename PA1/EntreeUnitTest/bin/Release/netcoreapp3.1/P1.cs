// Isabel Ovalles
// P1.cs
// 9/23/2021
// CPSC 3200

// Overview: 
// A list of Entrees is created from the given text file: EntreesTabDelimite.txt
// Series of tests are called on specific Entrees in the list.
// Results of each test function is printed out to console. 

using System;
using System.IO;
using System.Collections.Generic;
using PA1; 
    class P1
    {
        public const string FILE_NAME = "EntreesTabDelimited.txt";
        private static Random generator = new Random();
        public const int MILK_INDEX = 0;
        public const int COOKIE_INDEX = 2;
        public const int CHEEZIT_INDEX = 7;
        
        public static void Main(string[] args)
        {
            List<Entree> menu = new List<Entree>();
            

            Console.WriteLine("Welcome to PA 1 \n");

            readFile(menu);

            printEntreeNames(menu);
            getTotalSugar(menu, CHEEZIT_INDEX);
            isPeanutsAnIngredient(menu, MILK_INDEX);
            isEntreeExpired(menu, COOKIE_INDEX);

            Console.WriteLine("");
            isEntreeSpoiled(menu, MILK_INDEX); // testing power outage on an Entre
            powerOutageOnEntrees(menu);
            checkRefridgeration(menu, MILK_INDEX);
            isEntreeSpoiled(menu, MILK_INDEX);
            
            Console.WriteLine("\nEnd of PA 1\n");
        }

        public static void readFile(List<Entree> Entrees)
        {
            string txtLine;
            int lineCount = 1; // used to skip the first line in the .txt file
            

        /*
         * Entree File Fomatting: 
         *  entreeName, number of servings, 
         *  calories, total fat, sat fat, trans fat, cholesteral , sodium, fiber, total sugar, protien, 
         *  ingredients, contains
         */

            if (File.Exists(FILE_NAME))  // check if file exists
            {
                StreamReader file = new StreamReader(FILE_NAME); // if file exists open it
                while((txtLine = file.ReadLine()) != null)  // need to write more specific parsing for members
                {
                    if (lineCount != 1)
                    {
                        Entrees.Add(new Entree(txtLine));
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
        
        public static void printEntreeNames(List<Entree> Entrees)
        {
            Console.WriteLine("All Entrees:");
            for(int i = 0; i < Entrees.Count; i++)
            {
                Console.WriteLine(Entrees[i].getName());
            }

            Console.WriteLine("");
        }

        public static void getTotalSugar(List<Entree> Entrees, int index)
        {
            Console.WriteLine(Entrees[index].getName() + "\'s Total Sugar is: " + Entrees[index].getTotalSugar());
        }

        public static void isPeanutsAnIngredient(List<Entree> Entrees, int index)
        { 
            Console.Write(Entrees[index].getName() + " does ");
            if (Entrees[index].hasIngredient("Peanuts") == false)
            {
                Console.Write("not ");
            }
            Console.Write("have peanuts. \n");
        }
        
        public static void isEntreeExpired(List<Entree> Entrees, int index)
        {
            Console.WriteLine(Entrees[index].getName() + "'s expiration date is: " + Entrees[index].getExpirationDate());
            Console.Write(Entrees[index].getName() + " is ");
            if(Entrees[index].isExpired() == false)
            {
            Console.Write("not ");
            }
            Console.Write("expired.");
            Console.WriteLine("");
        }

        public static void isEntreeSpoiled(List<Entree> Entrees, int index)
        {
            if ((Entrees[index].isSpoiled()) == true)
            {
            Console.WriteLine(Entrees[index].getName() + " is spoiled!");
            } else
            {
            Console.WriteLine(Entrees[index].getName() + " is not spoiled!");
            }
        }

        public static void powerOutageOnEntrees(List<Entree> Entrees)
        {
            Console.WriteLine("A long power outage has occured!");
            for(int i = 0; i < Entrees.Count; i++)
            {
                Entrees[i].powerOut();
            }
        }

        public static void checkRefridgeration(List<Entree> Entrees, int index)
        {
            Console.Write(Entrees[index].getName() + " does ");
            if(Entrees[index].getNeedsRefrigeration() == false)
            {
            Console.Write("not ");
            }
            Console.Write("need refrigeration.\n");
        }
    }
