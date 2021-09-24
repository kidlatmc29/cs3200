// Isabel Ovalles
// CPSC 3200

using System;
using PA1;
    class P1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to PA 1");

            string cookieName = "Oreo"; 
            Entree cookie = new Entree(cookieName);

            Console.WriteLine(cookie.getName());

            Console.WriteLine("End of PA 1");

        }
    }
