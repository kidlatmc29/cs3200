// Isabel Ovalles
// CPSC 3200

// document your driver:
// ProgrammingByContract NOT used for drivers
//DO NOT assume that the reader has access to this assignment specification
// provide an overview of your program
// explicitly state ALL assumptions

using System;
using System.IO;
using System.Collections.Generic;
using PA1; 
    class P1
    {
        public const string FILE_NAME = "EntreesTabDelimited.txt";
        private static Random generator = new Random();

        public static void Main(string[] args)
        {
            List<Entree> menu = new List<Entree>();
            
            Console.WriteLine("Welcome to PA 1 \n");

            readFile(menu);

            printEntreeNames(menu);
            getTotalSugar(menu);
            isPeanutsAnIngredient(menu);


            
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
            for(int i = 0; i < Entrees.Count; i++)
            {
                Console.WriteLine(Entrees[i].getName());
            }

            Console.WriteLine("");
        }

        public static void getTotalSugar(List<Entree> Entrees)
        {
            int index = getRandomEntreeIndex(Entrees);
            Console.WriteLine(Entrees[index].getName() + "\'s Total Sugar is: " + Entrees[index].getTotalSugar());
        }
        public static void isPeanutsAnIngredient(List<Entree> Entrees)
        {
            int index = getRandomEntreeIndex(Entrees); 

            Console.Write(Entrees[index].getName() + " does ");
            if (Entrees[index].hasIngredient("Peanuts") == false)
            {
                Console.Write("not ");
            }
            Console.Write("have peanuts \n");
        }

        public static int getRandomEntreeIndex(List<Entree> Entrees)
        {
            int lowerBounds = 0;
            int upperBounds = Entrees.Count - 1;
            int range = (upperBounds - lowerBounds);

            return generator.Next(range);
        }

    }
