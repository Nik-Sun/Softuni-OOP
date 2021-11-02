using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private List<Product> shoppingBag;
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            shoppingBag = new List<Product>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Money 
        { 
            get => money; 
            private set
            {
                if (value <0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value;
            }
        }
        public IReadOnlyList<Product> ShoppingBag { get => shoppingBag; }

        public void BuyProduct(Product product)
        {
            if (product.Cost <= Money)
            {
                shoppingBag.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
                Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public string BoughtItems()
        {
            if (shoppingBag.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }
            else
            {
                return $"{Name} - {string.Join(", ", shoppingBag)}";
            }
        }

    }
}
