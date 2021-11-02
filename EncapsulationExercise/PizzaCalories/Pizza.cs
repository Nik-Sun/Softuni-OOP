using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name 
        { 
            get => name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            } 
        }
        public int ToppingsCount { get => toppings.Count; }
        public Dough Dough { get => dough; set => dough = value; }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count == 10)
            {
                throw new Exception("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
        public string GetCalories()
        {
            double calories = double.Parse(Dough.GetCalories());
            foreach (Topping topping in toppings)
            {
                calories += double.Parse(topping.GetCalories());
            }
            return $"{Name} - {calories :f2} Calories.";
        }

    }
}
