// Isabel Ovalles
// CPSC 3200

using System;
using System.IO;
using System.Collections.Generic;
using PA1; 
    class P1
    {
        public const string FILE_NAME = "EntreesTabDelimited.txt";

        public static void Main(string[] args)
        {
            List<Entree> menu = new List<Entree>();
            
            Console.WriteLine("Welcome to PA 1 \n");

            readFile(menu);

            Console.WriteLine(menu[0].getName() + "\n");
            menu[0].printIngredients();

            Console.WriteLine("End of PA 1 \n");

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

            Console.WriteLine("menu length is " + Entrees.Count + "\n");
        }
    }
