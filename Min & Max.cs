/*
CPSC1012-Exercise04
- Write a program that will read a sequence of numbers from the keyboard, and display the
  minimum, maximum, average, and range (the difference between the largest and smallest 

  1. Input your number
  2. The Program will display the average, minimum, maximum, and range
  3. Choose to add another number (if so repeat steps 1 -2), or don't and it will close the program.

By: Jordan Ardeleanu
Created / Last Modified : 10/16/2020

*/

using System;

namespace CPSC1012_Excersie04_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            double userChoice = 0, minimum = 0, maximum = 0, range = 0, allNumbers = 0, numAmount = 1, average;
            char onceMore = 'n';
            do
            {
                Console.WriteLine("Hello! Please submit your Number#{0}:", numAmount);
                try
                {
                    userChoice = double.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Incorrect syntax, please input a integer.");
                    userChoice = -1;
                }
                if (userChoice != -1)
                {
                    if (userChoice < minimum || numAmount == 1)
                    {
                        minimum = userChoice;
                    }
                    if (userChoice > maximum)
                    {
                        maximum = userChoice;
                    }
                    average = Math.Round(((userChoice + allNumbers) / numAmount), 2);
                    range = maximum - minimum;
                    allNumbers = allNumbers + userChoice;
                    numAmount++;
                    Console.WriteLine("     Output      \n" +
                        "----------------\n" +
                        "Maximum = " + maximum + "\n" +
                        "Minimum = " + minimum + "\n" +
                        "Average = " + average + "\n" +
                        "Range   = " + range + "\n");
                }
                Console.Write("Would you like to submit another number? (y/n)");
                try
                {
                    onceMore = char.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Neither Yes or No submitted");
                }
            } while (onceMore == 'y');
            Console.WriteLine("Closing Program...");
        }
    }
}
