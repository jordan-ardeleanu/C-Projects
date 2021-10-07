/*
Core Portfolio 1
- To create a costed Packing Slip reflecting the choices made in purchasing a new bike

  1. Input your choice of brand
  2. Input your tire size
  3. Input your choice of metal
  4. Decide on inputing a donation
  5. The Program will print the Receipt

By: Jordan Ardeleanu
Created / Last Modified : 9/30/2020

*/
using System;

namespace Core_Portfolio_1_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Brand Section // Starting //
            string userName;
            string userInput;
            string chosenBrand = "a";
            char userChoice = 'a';
            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();
            Console.WriteLine("Please choose a brand of bike:\n a) Trek \n b) Giant \n c) Specialized \n d) Raleigh");
            Console.Write("What is your choice?: ");
            userInput = Console.ReadLine();
            userInput = userInput.ToLower();
            switch (userInput) // Determining what the inputed response is..
            {
                case "a":
                case "b":
                case "c":
                case "d":
                    userChoice = char.Parse(userInput); // Converting the choice to a char variable
                    break;
                case "trek":
                    userChoice = 'a';
                    break;
                case "giant":
                    userChoice = 'b';
                    break;
                case "specialized":
                    userChoice = 'c';
                    break;
                case "raleigh":
                    userChoice = 'd';
                    break;
                default:
                    Console.WriteLine("Invalid Option, please restart the program"); // If invalid input
                    break;
            }
            switch (userChoice) // Assigning the brand to print on Receipt
            {
                case 'a':
                    chosenBrand = "Trek";
                    break;
                case 'b':
                    chosenBrand = "Giant";
                    break;
                case 'c':
                    chosenBrand = "Specialized";
                    break;
                case 'd':
                    chosenBrand = "Raleigh";
                    break;
                default:
                    break;
            }
            // Brand Section // Ending //

            // Tire Section // Starting //
            double tireCost;
            string tireInput;
            int tireInches;
            Console.Write("\nWhat is your preffered Tire size - 20 to 26 inches *Must be an integer*: ");
            tireInput = Console.ReadLine();
            tireInches = int.Parse(tireInput);
            if (tireInches < 20 || tireInches > 26) // Checks its within range
            {
                Console.WriteLine("Tire inches entered are invalid. Please restart the program");
                return;
            }
            tireCost = tireInches * 17.50; // Calculates tire cost
            // Tire Section // Ending //

            // Metal Section // Starting
            double metalCost = 0;
            string metalInput;
            int metalChoice = 0;
            Console.WriteLine("Please choose the metal alloy of the frame:\n 1) Steel \n 2) Aluminium \n 3) Titanium \n 4) Carbon Fiber");
            Console.Write("What is your choice?: ");
            metalInput = Console.ReadLine();
            metalInput = metalInput.ToUpper();
            switch (metalInput)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                    metalChoice = int.Parse(metalInput); // Converting the choice to a int variable
                    break;
                case "STEEL":
                    metalChoice = 1;
                    break;
                case "ALUMINIUM":
                    metalChoice = 2;
                    break;
                case "TITANIUM":
                    metalChoice = 3;
                    break;
                case "CARBON FIBER":
                case "CARBONFIBER":
                    metalChoice = 4;
                    break;
                default:
                    Console.WriteLine("Invalid Option"); //If invalid input
                    break;
            }
            switch (metalChoice) // Assigning costs per material
            {
                case 1:
                    metalCost = 0;
                    break;
                case 2:
                    metalCost = 175;
                    break;
                case 3:
                    metalCost = 425;
                    break;
                case 4:
                    metalCost = 615;
                    break;

                default:
                    break;
            }
            // Metal Section // Ending //

            // Donation Section // Starting //
            string donationInput;
            string donationAmount;
            // bool donationChoice = false;
            int donationCost = 0;
            Console.Write("Make a donation to the Green Earth Fund [y/n]: ");
            donationInput = Console.ReadLine();
            donationInput = donationInput.ToLower();
            if (donationInput == "y")
            {
                // donationChoice = true;
                Console.Write("Please enter desired donation. *Must be an integer*: ");
                donationAmount = Console.ReadLine();
                donationCost = int.Parse(donationAmount); // Converting the donation to a int variable
            }
            else if (donationInput == "n")
            {
                // donationChoice = false;
            }
            else
            {
                Console.WriteLine("Donation Choice invalid, please restart the program.");
                return;
            }
            // Donation Section // Ending
            int basePrice = 500;
            double totalCost = tireCost + metalCost + basePrice; // Calculating total price
            double gstCost = Math.Round((0.05 * totalCost), 2);
            double completeCost = donationCost + totalCost + gstCost;


            // Receipt // Starting //
            Console.WriteLine("    The Right Speed Bike Shop\n" +
                "    *************************\n" +
                "Enter your name >> " + userName + "\n" +
                "Brand \n" +
                "      a) Trek \n" +
                "      b) Giant \n" +
                "      c) Specialized \n" +
                "      d) Raleigh \n" +
                "Make a selection [a,b,c,d] >> " + userChoice + "\n" +
                "Choose a tire size [20-26] @ 17.50 per inch >> " + tireInches + "\n" +
                "Enter the corresponding choice of metal. \n" +
                "      1. Steel [$0] \n" +
                "      2. Aluminium [$175] \n" +
                "      3. Titanium [$425] \n" +
                "      4. Carbon Fiber [$615] \n" +
                "Choice [1-4] >> " + metalChoice + "\n" +
                "Would you like to make a donation to the Green Earth Fund [y/n]" + donationInput + "\n" +
                "Amount >> " + donationCost + "\n" +
                "\n" +
                "\n" +
                "Invoice and Packing Slip \n" +
                "\n" +
                " Customer:            " + userName + "\n" +
                " Brand:               " + chosenBrand + "\n");
            Console.WriteLine(" Base Price:                 ${0,10:c}\t", basePrice);
            Console.WriteLine(" Tire Size Premium:          ${0,10:c}\t", tireCost);
            Console.WriteLine(" Metal Selection Premium:    ${0,10:c}\t", metalCost);
            Console.WriteLine("                           -------");
            Console.WriteLine(" Sub Total:                  ${0,10:c}\t", totalCost);
            Console.WriteLine(" GST:                        ${0,10:c}\t", gstCost);
            Console.WriteLine("                           -------");
            Console.WriteLine(" Donation to Green Earth:    ${0,10:c}\t", donationCost);
            Console.WriteLine(" Total:                      ${0,10:c}\t", completeCost);
        }
    }
}
