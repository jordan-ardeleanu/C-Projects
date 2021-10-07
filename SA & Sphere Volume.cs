/*
Surface Area & Volume of any Sphere

1. Run the program
2. Enter the Radius (Make sure the Radius is a valid number and >0)
3. The program will provide the awnser

By: Jordan Ardeleanu
Created / Last Modified : 9/8/2020

*/
using System;

namespace CPSC1012_Exercise02_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to the Sphere SA & V Calculator. Please follow the given steps to receive your awnser! /n");
            Console.WriteLine("Please enter the radius of your sphere");
            string rawInput = Console.ReadLine();  // Console Reads User Input
            double Radius = double.Parse(rawInput); // Converts from a String into a Double Value
            if (Radius < 0)
            {
                Console.WriteLine("This number is invalid, please try again.");
                return;
            }
            double sidesurface = (4 * 3.14 * Math.Pow(Radius, 2)); // Preforms SideSurfaceArea Calculation
            double volume = (4 * 3.14 * (Math.Pow(Radius, 3) / 3)); // Preforms Volume Calculation
            Console.WriteLine("Your SideSurfaceArea is {0}, and your Volume is {1}!", Math.Round(sidesurface, 2), Math.Round(volume, 2)); // Awnser is displayed
        }
    }
}
