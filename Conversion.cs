/*
CPSC1012-Exercise03

  Conversion Calculator
  1. Input your selected Option
  2. Input your desired amount of units
  3. The Program will awnser
  4. *If you select (y) for Reversion, continue from step 2 again.*

By: Jordan Ardeleanu
Created / Last Modified : 9/30/2020
*/
using System;

namespace CPSC1012_Excercise03_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Defining Variables //
            string userConv;
            string userReverse;
            double userInput = 0;
            char userSelection = 'a';
            double programAwnser = 0;
            Console.WriteLine("Conversion Options");
            Console.WriteLine("A. Ounces > Grams");
            Console.WriteLine("B. Pounds > Kilograms");
            Console.WriteLine("C. Tons > Kilograms");
            Console.Write("Please input your option: ");
            userConv = Console.ReadLine();
            userConv = userConv.ToUpper();
            switch (userConv) // Checking the user input //
            {
                case "A":
                case "B":
                case "C":
                    userSelection = char.Parse(userConv); // Converting the choice to an int variable //
                    break;
                case "OUNCES":
                    userSelection = 'A';
                    break;
                case "POUNDS":
                    userSelection = 'B';
                    break;
                case "TONS":
                    userSelection = 'C';
                    break;
                default:
                    Console.WriteLine("Invalid Input, please restart the program."); // Invalid Input depending on Response //
                    break;
            }
            Console.Write("Excellent! Please input the desired amount for Selection {0}: ", userSelection);
            userInput = double.Parse(Console.ReadLine());
            if (userInput < 0)
            {
                Console.WriteLine("Invalid Input, please restart the program.");
            }
            switch (userSelection)
            {
                // Providing awnsers, based on mathematical equations //
                case 'A':
                    programAwnser = (userInput / 0.035274);
                    Console.WriteLine(userInput + " Ounces = " + Math.Round(programAwnser, 2) + " Grams");
                    break;
                case 'B':
                    programAwnser = (userInput / 0.39370);
                    Console.WriteLine(userInput + " Pounds = " + Math.Round(programAwnser, 2) + " Kilograms");
                    break;
                case 'C':
                    programAwnser = (userInput / 0.001);
                    Console.WriteLine(userInput + " Tons = " + Math.Round(programAwnser, 2) + " Kilograms");
                    break;
                default:
                    Console.WriteLine("Invalid Input, please restart the program.");
                    break;
            }
            // Bonus Content //
            Console.Write("Would you like to reverse the conversion? (y/n): ");
            userReverse = Console.ReadLine();
            userReverse = userReverse.ToLower();
            if (userReverse == "y")
            {
                Console.Write("Excellent! Please input the desired amount for Selection {0} Reverse: ", userSelection);
                userInput = double.Parse(Console.ReadLine());
                if (userInput < 0)
                {
                    Console.WriteLine("Invalid Input, please restart the program.");
                }
                switch (userSelection)
                {
                    case 'A':
                        programAwnser = (userInput * 0.035274);
                        Console.WriteLine(userInput + " Grams = " + Math.Round(programAwnser, 2) + " Ounces");
                        break;
                    case 'B':
                        programAwnser = (userInput * 0.39370);
                        Console.WriteLine(userInput + " Kilograms = " + Math.Round(programAwnser, 2) + " Pounds");
                        break;
                    case 'C':
                        programAwnser = (userInput * 0.001);
                        Console.WriteLine(userInput + " Kilograms = " + Math.Round(programAwnser, 2) + " Tons");
                        break;
                    default:
                        Console.WriteLine("Invalid Input, please restart the program.");
                        break;
                }

            }
            // Goodbye / Ending //
            Console.WriteLine("Thank you very much for using my program! Goodbye!");
        }
    }
}
