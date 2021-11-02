using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfo = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfo = Console.ReadLine().Split(";",StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            foreach (var pair in peopleInfo)
            {
                string[] personInfo = pair.Split("=",StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Person person = new Person(personInfo[0], decimal.Parse(personInfo[1]));
                    people.Add(person);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
               
            }
            foreach (var pair in productsInfo)
            {
                string[] productInfo = pair.Split("=",StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    Product product = new Product(productInfo[0], decimal.Parse(productInfo[1]));
                    products.Add(product);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
                
            }


            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] transactionInfo = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string personName = transactionInfo[0];
                string productName = transactionInfo[1];
                people[people.FindIndex(p => p.Name == personName)].BuyProduct(products[products.FindIndex(p => p.Name == productName)]);

                input = Console.ReadLine();
            }
            foreach (Person person in people)
            {
                Console.WriteLine(person.BoughtItems());
            }
        }
    }
}
