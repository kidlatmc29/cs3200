// Isabel Ovalles
// CPSC 3200

using System;
using System.IO;
using System.Collections.Generic; 
    class P1
    {
        public const string FILE_NAME = "EntreesTabDelimited.txt";

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to PA 1 \n");

            readFile();

            Console.WriteLine("End of PA 1 \n");

        }

        public static void readFile()
        {
            string txtLine;
            int lineCount = 1; // used to skip the first line in the .txt file
        /*
         * Entree File Fomatting: 
         *  entreeName, number of servings, 
         *  calories, total fat, sat fat, trans fat, cholesteral , sodium, fiber, total sugar, protien, 
         *  ingredients
         */

            if (File.Exists(FILE_NAME))  // check if file exists
            {
                Console.WriteLine(FILE_NAME + " exists! \n");
                StreamReader file = new StreamReader(FILE_NAME); // if file exists open it
                while((txtLine = file.ReadLine()) != null) 
                {
                    if (lineCount != 1)
                    {
                        Console.WriteLine(txtLine + "\n");
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
    }
