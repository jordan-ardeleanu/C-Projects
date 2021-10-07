/*
CPSC1012 - Excersie 5 - Jordan Ardeleanu
- A program which displays a square box on the screen of a length and contents specified by the user.

  1. Choose a Fancy or a Regular Box
  2. Input Required Integers/Content Character
  3. The Program will respond with a Box as Specified

  E.g ( INT : 5, CHAR : ?)
      -----
      |???|
      |???|
      |???|
      -----

By: Jordan Ardeleanu
Created / Last Modified : 10/29/2020

*/
using System;

namespace CPSC1012_Exercise5_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello! Would you like to make a Fancy Box, or a Regular Box?? (F/R): ");
            string userChoice = Console.ReadLine();
            int userNum = 0;
            if (userChoice == "F")
            {
                Console.Write("\nHello again! Please input your chosen character!!!: ");
                string userInput = Console.ReadLine();
                char userChar = char.Parse(userInput);
                userNum = GetLength("Hello Again Again! Please enter a Valid Integer for Box Size: ");
                DisplayBox(userNum, userChar);
            }
            else if(userChoice == "R")
            {
                userNum = GetLength("Hello! Please enter a Valid Integer for Box Size: ");
                DisplayBox(userNum);
            }
        }

        static int GetLength(string prompt)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();
            int userReturn = 0;
            try
            {
                userReturn = int.Parse(userInput);
            }
            catch
            {
                Console.WriteLine("Invalid Length Entered! Restart the Program");
            }
            return userReturn;
        }

        static void DisplayBox(int length)
        {
            Console.WriteLine($"Inputed Length is {length}");
            for (int index = 0; index < length; index++)
            {
                Console.Write("-"); // Looping through the Top of the Box "Dashes"
            }
            Console.WriteLine("");
            for (int index = 3; index <= length; index++)
            {
                Console.Write("|" ); // Looping in the Side of the Box "Pipes"
                for (int spaces = 1; spaces <= length-2; spaces++)
                {
                    Console.Write(" "); // Looping in the Spaces within the Box
                }
                Console.Write("|\n");
            }
            for (int index = 0; index < length; index++)
            {
                Console.Write("-");// Looping through the Bottom of the Box "Dashes"
            }
            Console.WriteLine("");
        }

        static void DisplayBox(int length, char fillChar)
        {
            {
                Console.WriteLine($"Inputed Length is {length}");
                for (int index = 0; index < length; index++)
                {
                    Console.Write("-"); // Looping through the Top of the Box "Dashes"
                }
                Console.WriteLine(""); 
                for (int index = 3; index <= length; index++)
                {
                    Console.Write("|"); // Looping in the Side of the Box "Pipes"
                    for (int spaces = 1; spaces <= length - 2; spaces++)
                    {
                        Console.Write($"{fillChar}"); // Looping in the Characters within the Box "Content"
                    }
                    Console.Write("|\n");
                }
                for (int index = 0; index < length; index++)
                {
                    Console.Write("-"); // Looping through the Bottom of the Box "Dashes"
                }
                Console.WriteLine("");
            }
        }
    }
}
