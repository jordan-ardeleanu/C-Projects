/*
Core Portfolio 2
- To create a costed Packing Slip reflecting the choices made in purchasing a new bike

  1. Select options from Menu (All are not Mandatory)
    a. Input your choice of brand
    b. Input your tire size
    c. Input your choice of metal
    d. Decide on inputing a donation
    e. The Program will print the Receipt
  2. You may Clear the program at any time, during the Menu Option

By: Jordan Ardeleanu
Created / Last Modified : 10/23/2020

*/
using System;

namespace Core_Portfolio_2_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Brand Section // Starting //
            string userName = "N/A", chosenBrand = "None", donationInput = "N/A";
            string donationAmount = "N/A", tireInput = "N/A"; // You asked me to comment here, for some reason this variable has unnessesary assignment??
            int menuChoice, tireInches = 0;
            char userChoice = 'z';
            double tireCost = 0, metalCost = 0, metalChoice = 0, donationCost = 0;
            bool programContinuing = true;
            do
            {
                menuChoice = GetMenuChoice();
                switch (menuChoice)
                {
                    case 1:
                        Console.Write("\nPlease enter your name: ");
                        userName = Console.ReadLine();
                        break;
                    case 2:
                        chosenBrand = ChooseBrand();
                        break;
                    case 3:
                        // Tire Section // Starting //
                        for (int counter = 0; counter < 1; counter++)
                        {
                            Console.Write("\nWhat is your preffered Tire size - 20 to 26 inches *Must be an integer*: ");
                            tireInput = Console.ReadLine();
                            tireInches = GetInt(tireInput);
                            if (tireInches < 20 || tireInches > 26) // Checks its within range
                            {
                                Console.WriteLine("\nTire inches entered are invalid. Please retry.");
                                counter = -1;
                            }
                            tireCost = tireInches * 17.50; // Calculates tire cost
                        // Tire Section // Ending //
                        }
                        break;
                    case 4:
                        // Metal Section // Starting
                        metalChoice = ChooseCompositeByValue();
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
                        break;
                    case 5:
                        // Donation Section // Starting //
                        // bool donationChoice = false;
                        Console.Write("\nMake a donation to the Green Earth Fund [y/n]: ");
                        donationInput = Console.ReadLine();
                        donationInput = donationInput.ToLower();
                        if (donationInput == "y")
                        {
                            for (int counter = 0; counter < 1; counter++)
                            {
                                // donationChoice = true;
                                Console.Write("Please enter desired donation. *Must be an integer*: ");
                                donationAmount = Console.ReadLine();
                                donationCost = GetDouble(donationAmount); // Converting the donation to a double variable
                                if (donationCost == -1)
                                {
                                    counter = -1;
                                }
                            }
                        }
                        else if (donationInput == "n")
                        {
                            // donationChoice = false;
                        }
                        else
                        {
                            Console.WriteLine("\nDonation Choice invalid, please reselect from menu.");
                        }
                        // Donation Section // Ending
                        break;
                    case 6:
                        DisplayCopy(userName, userChoice, tireInches, metalChoice, donationInput, donationCost, chosenBrand);
                        DisplayInvoice(metalCost, tireCost, donationCost);
                        break;
                    case 7:
                        Console.WriteLine("Clearing System...");
                        Console.WriteLine("Clearing System...");
                        Console.WriteLine("Clearing System...");
                        userName = "N/A";
                        tireInput = "N/A"; // Unnessesary Assignment
                        chosenBrand = "z";
                        donationInput = "N/A";
                        donationAmount = "N/A"; // Unnessesary Assignment 
                        tireInches = 0;
                        tireCost = 0;
                        metalCost = 0;
                        metalChoice = 0;
                        donationCost = 0;
                        Console.WriteLine("\nCleared all values!");
                        break;
                    case 8:
                        Console.WriteLine("Bye!");
                        programContinuing = false;
                        break;
                    default:
                        break;
                }
            } while (programContinuing);
            Console.WriteLine("\nProgram Closing...");



            static string ChooseBrand()
            {
                string userInput, chosenBrand = "";
                char userChoice = 'z';
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
                        Console.WriteLine("\nInvalid Option, please start again from menu option"); // If invalid input
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
                    case 'z':
                        chosenBrand = "None";
                        break;
                    default:
                        break;
                }
                return chosenBrand;
                // Brand Section // Ending //
            }

            static int GetMenuChoice()
            {
                string rawInput;
                int userInput = 0;
                Console.WriteLine
                    ("\nPlease enter one of options listed (E.g 1, 2, 3 or by Name)\n"
                    + "------------------------\n" +
                    "1. Enter Name\n" +
                    "2. Enter Brand\n" +
                    "3. Select Tire Size\n" +
                    "4. Select Metal Composite\n" +
                    "5. Add Donation\n" +
                    "6. Display Packing Slip / Invoice\n" +
                    "7. Clear\n" +
                    "8. Exit");
                Console.Write("Selection:  ");
                rawInput = Console.ReadLine();
                rawInput = rawInput.ToLower();
                switch (rawInput)
                {
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                        userInput = int.Parse(rawInput);
                        break;
                    case "name":
                    case "enter name":
                        userInput = 1;
                        break;
                    case "brand":
                    case "enter brand":
                        userInput = 2;
                        break;
                    case "tire":
                    case "size":
                    case "tire size":
                    case "select tize size":
                        userInput = 3;
                        break;
                    case "metal":
                    case "composite":
                    case "select metal composite":
                    case "metal composite":
                        userInput = 4;
                        break;
                    case "donation":
                    case "donate":
                    case "add donation":
                        userInput = 5;
                        break;
                    case "display packing slip / invoice":
                    case "display packing slip":
                    case "packing slip":
                    case "slip":
                    case "display invoice":
                    case "invoice":
                        userInput = 6;
                        break;
                    case "clear":
                        userInput = 7;
                        break;
                    case "exit":
                        userInput = 8;
                        break;
                    default:
                        break;
                }
                return userInput;
            }
            
            static int GetInt(string prompt) // gets valid int
            {
                int userOutput = 0;
                try
                {
                    userOutput = int.Parse(prompt);
                }
                catch
                {
                    Console.WriteLine("Invalid Input, please try again.");
                }
                return userOutput;
            }

            static double GetDouble(string prompt) // gets valid double
            {
                double userOutput = -1;
                try
                {
                    userOutput = double.Parse(prompt);
                }
                catch
                {
                    Console.WriteLine("Invalid Input, please try again.");
                }
                return userOutput;
            }

            static double ChooseCompositeByValue()
            {
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
                return metalChoice;
            }

            static void DisplayCopy(string userName, char userChoice, int tireInches, double metalChoice, string donationInput, double donationCost, string chosenBrand)
            {
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
            }

            static void DisplayInvoice(double metalCost, double tireCost, double donationCost)
            {
                int basePrice = 500;
                double totalCost = tireCost + metalCost + basePrice; // Calculating total price
                double gstCost = Math.Round((0.05 * totalCost), 2);
                double completeCost = donationCost + totalCost + gstCost;
                // Receipt // Starting //
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
}
