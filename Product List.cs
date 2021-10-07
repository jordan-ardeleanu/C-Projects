using System;
using System.IO;
using System.Collections.Generic;

namespace CPSC1012_Ex07_JordanArdeleanu
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> myProduct = new List<Product>();
            AddProduct(myProduct);
            DisplayProducts(myProduct);
        }
        static int AddProduct(List<Product> products)
        {
            int productAmount;
            int productCount = 1;
            string productName;
            string productDescription;
            double productPrice;

            productAmount = GetInt("Hey! Please input how many products you wish to create!!\n");
            for (int list = 0; list < productAmount; list++)
            {
                Console.WriteLine($"------ Product #{productCount} ------");
                productName = GetString($"Product #{productCount} Name: ");
                productDescription = GetString($"Product #{productCount} Description: ");
                productPrice = GetDouble($"Product #{productCount} Price: ");
                products.Add(new Product
                {
                    Name = productName,
                    Description = productDescription,
                    Price = productPrice
                });
                productCount++;
            }
            return 0;
        } // end of AddProduct

        static void DisplayProducts(List<Product> products)
        {
            Console.WriteLine("\n------- Current Products Listed -------");
            foreach(var Product in products)
            {
                Console.WriteLine("Name: " + Product.Name);
                Console.WriteLine("Description: " + Product.Description);
                Console.WriteLine("Price: {0:c}" , Product.Price + "\n");
            }
        } // end of DisplayProducts

        static int GetInt(string prompt)
        {
            int safeInt = 0;
            Console.Write(prompt);
            try
            {
                safeInt = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid! Please try again!");
            }
            return safeInt;
        }

        static double GetDouble(string prompt)
        {
            double safeDouble = 0;
            Console.Write(prompt);
            try
            {
                safeDouble = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid! Please try again!");
            }
            return safeDouble;
        }

        static string GetString(string prompt)
        {
            string userInput;
            Console.Write(prompt);
            userInput = Console.ReadLine();
            return userInput;
        }
    }
}
