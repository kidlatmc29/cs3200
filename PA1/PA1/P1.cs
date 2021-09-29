﻿// Isabel Ovalles
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

        public static void Main(string[] args)
        {
            List<Entree> menu = new List<Entree>();
            
            Console.WriteLine("Welcome to PA 1 \n");

            readFile(menu);

            // printEntreeNames(menu);

            getTotalSugar(menu);

            

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
        }
        
        public static void printEntreeNames(List<Entree> Entrees)
        {
            for(int i = 0; i < Entrees.Count; i++)
            {
                Console.WriteLine(Entrees[i].getName() + "\n");
            }
        }

        public static void getTotalSugar(List<Entree> Entrees)
        {
            Random generator = new Random();
            int lowerBounds = 0;
            int upperBounds = Entrees.Count - 1;
            int range = (upperBounds - lowerBounds);

            int randomEntreeIndex = generator.Next(range);
           
            Console.WriteLine(Entrees[randomEntreeIndex].getName() + "\'s Total Sugar is: " + Entrees[randomEntreeIndex].getTotalSugar());
        }
    }
