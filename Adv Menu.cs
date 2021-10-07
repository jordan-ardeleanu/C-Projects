/*
Advanced Portfolio
- To create a costed Packing Slip reflecting the choices made in purchasing a new bike, then Saving / Writing from a File

  1. Select options from Menu (All are not Mandatory)
    a. Input your Name
    a. Input your choice of brand
    b. Input your tire size
    c. Input your choice of metal
    d. Decide on inputing a donation
    e. Display packing slip / invoice
    f. Clear and Save your Invoice
    g. Read your Invoice from a file
    h. Write your Invoice to a file
    i. Display all Invoices
    j. Exit
  2. You may Clear the program at any time, during the Menu Option

By: Jordan Ardeleanu
Created / Last Modified : 12/17/2020

*/

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace Advanced_Portfolio
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = "N/A", chosenBrand = "None";
            int menuChoice, tireInches = 0;
            double metalCost = 0, donationCost = 0;
            bool programContinuing = true;
            string filePath = "../../../CPSC/sales.txt";
            List<CustomerList> customerList = new List<CustomerList>();
            CustomerList currentList = new CustomerList();
            do
            {
                menuChoice = GetMenuChoice();
                switch (menuChoice)
                {
                    case 1:
                        currentList.Name = GetString("\nPlease enter customer name: ");
                        break;
                    case 2:
                        chosenBrand = ChooseBrand();
                        break;
                    case 3:
                        tireInches = TireInches();
                        break;
                    case 4:
                        metalCost = ChooseCompositeByValue();
                        break;
                    case 5:
                        donationCost = CustomerDonation();
                        break;
                    case 6:
                        DisplayInvoice(metalCost, tireInches, donationCost);
                        break;
                    case 7:
                        customerList.Add(new CustomerList // Assigning each variable from the Product Class within a single function
                        {
                            Name = userName,
                            Brand = chosenBrand,
                            Tire = tireInches.ToString(),
                            Metal = metalCost.ToString(),
                            Donation = donationCost.ToString()
                        });
                        for (int sleep = 0; sleep < 3; sleep++)
                        {
                            Console.WriteLine("Clearing all values...");
                            Thread.Sleep(2000);
                        }
                        userName = "N/A";
                        chosenBrand = "z";
                        tireInches = 0;
                        metalCost = 0;
                        donationCost = 0;
                        Console.WriteLine("\nCleared all values! Added Sale to Current List!");
                        break;
                    case 8:
                        ReadFromFile(customerList, filePath);
                        break;
                    case 9:
                        WriteToFile(customerList, filePath);
                        break;
                    case 10:
                        DisplayAllInvoices(customerList);
                        break;
                    case 11:
                        Console.WriteLine("Bye!");
                        programContinuing = false;
                        break;
                    default:
                        break;
                }
            } while (programContinuing);
            Console.WriteLine("\nProgram Closing...");

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
                    "7. Save Invoice (Clear)\n" +
                    "8. Read Invoices from File\n" +
                    "9. Write Invoices to File\n" +
                    "10. Display All Invoices\n" +
                    "11. Exit\n");
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
                    case "9":
                    case "10":
                    case "11":
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
                    case "save" :
                        userInput = 7;
                        break;
                    case "read":
                    case "read sales":
                        userInput = 8;
                        break;
                    case "write":
                    case "write sales":
                        userInput = 9;
                        break;
                    case "display all":
                    case "all":
                    case "display all invoice" :
                        userInput = 10;
                        break;
                    case "exit":
                        userInput = 11;
                        break;
                    default:
                        break;
                }
                return userInput;
            }

            static double GetDouble(string prompt) // gets valid double
            {
                double safeDouble = 0;
                char messedUp = 'n';
                do
                {
                    messedUp = 'n';
                    Console.Write(prompt);
                    try
                    {
                        safeDouble = double.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        messedUp = 'y';
                        Console.WriteLine("Invalid! Please try again!");
                    }
                } while (messedUp == 'y');
                return safeDouble;
            }

            static char GetChar(string prompt)
            {
                char safeChar = 'n';
                char messedUp = 'n';
                do
                {
                    messedUp = 'n';
                    Console.Write(prompt);
                    try
                    {
                        safeChar = char.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        messedUp = 'y';
                        Console.WriteLine("Invalid! Please try again!");
                    }
                } while (messedUp == 'y');
                return safeChar;
            }

            static int GetInt(string prompt)
            {
                char messedUp = 'n';
                int safeInt = 0;
                do
                {
                    messedUp = 'n';
                    Console.Write(prompt);
                    try
                    {
                        safeInt = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        messedUp = 'y';
                        Console.WriteLine("Invalid! Please try again!");
                    }
                } while (messedUp == 'y');
                return safeInt;
            }

            static string GetString(string prompt)
            {
                string userInput;
                Console.Write(prompt);
                userInput = Console.ReadLine();
                return userInput;
            }

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

            static int TireInches()
            {
                int tireInches = 0;
                // Tire Section // Starting //
                for (int counter = 0; counter < 1; counter++)
                {
                    tireInches = GetInt("\nWhat is your preffered Tire size - 20 to 26 inches *Must be an integer*: ");
                    if (tireInches < 20 || tireInches > 26) // Checks its within range
                    {
                        Console.WriteLine("\nTire inches entered are invalid. Please retry.");
                        counter = -1;
                    }
                                                   // Tire Section // Ending //
                }
                return tireInches;
            }

            static double ChooseCompositeByValue()
            {
                string metalInput;
                int metalChoice = 0;
                double metalCost = 0;
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
                return metalCost;
            }

            static double CustomerDonation()
            {
                double donationCost = 0;
                // Donation Section // Starting //
                    for (int counter = 0; counter < 1; counter++)
                    {
                        // donationChoice = true;
                        donationCost = GetDouble("Please enter desired donation. *Must be an integer*: ");
                        if (donationCost < 0)
                        {
                            Console.WriteLine("You cannot put a negative donation.");
                            counter = -1;
                        }
                    }
                // Donation Section // Ending
                return donationCost;
            }

            static void DisplayInvoice(double metalCost, int tireInches, double donationCost)
            {
                double tireCost = tireInches * 17.50;
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

            static void ReadFromFile(List<CustomerList> customerList, string filePath)
            {
                StreamReader myReader = new StreamReader(filePath);
                Console.WriteLine("\n\n-----------------------------");
                Console.WriteLine("Reading all lines from File");
                for (int sleep = 0; sleep < 3; sleep++)
                {
                    Console.WriteLine("Reading from File...");
                    Thread.Sleep(2000);
                }

                List<string> lines = File.ReadAllLines(filePath).ToList();

                try
                {
                    foreach (string line in lines)
                    {
                        string[] perLine = line.Split(',');

                        CustomerList registeredCustomer = new CustomerList();

                        registeredCustomer.Name = perLine[0];
                        registeredCustomer.Brand = perLine[1];
                        registeredCustomer.Tire = perLine[2];
                        registeredCustomer.Metal = perLine[3];
                        registeredCustomer.Donation = perLine[4];

                        customerList.Add(registeredCustomer);
                    }
                }
                catch
                {
                    Console.WriteLine("You have attempted to break the FILE! HOW DARE YOU");
                    return;
                }
                Console.WriteLine("All lines read & added from file");
                Console.WriteLine("-----------------------------\n\n");
                myReader.Close();
            }

            static void WriteToFile(List<CustomerList> customerList, string filePath)
            {
                StreamWriter writer = new StreamWriter(filePath, true);
                Console.WriteLine("\n\n-----------------------------");
                Console.WriteLine("Writing all lines to File");
                for (int sleep = 0; sleep < 3; sleep++)
                {
                    Console.WriteLine("Writing to File...");
                    Thread.Sleep(2000);
                }
                foreach (CustomerList CustomerList in customerList)
                {
                    writer.WriteLine($"{CustomerList.Name},{CustomerList.Brand},{CustomerList.Tire},{CustomerList.Metal},{CustomerList.Donation}");
                }
                Console.WriteLine("All lines written to file");
                Console.WriteLine("-----------------------------\n\n");

                writer.Close();
            }

            static void DisplayAllInvoices(List<CustomerList> customerList)
            {
                try
                {
                    Console.WriteLine(String.Format("{0,-35} {1,-25} {2, -20} {3, -15} {4, -10}",
                    "Name", "Brand", "Tires", "Metal", "Donation"));
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                    foreach (CustomerList CustomerList in customerList)
                    {
                        Console.Write(String.Format("{0,-35} {1,-25} {2, -20} {3, -15:00.00} {4, -10:00.00}\n",
                        CustomerList.Name, CustomerList.Brand, Convert.ToDouble(CustomerList.Tire), Convert.ToDouble(CustomerList.Metal), Convert.ToDouble(CustomerList.Donation)));
                    }
                }
                catch
                {
                    Console.WriteLine("You have attempted to break the FORMATTING! HOW DARE YOU");
                    return;
                }
            }
        }
    }
}
