using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;
        private Dictionary<string, double> modifiers = new Dictionary<string, double>();

        public Topping(string type,int weight)
        {
            Type = type;
            Weight = weight;
            modifiers.Add("Meat", 1.2);
            modifiers.Add("Veggies", 0.8);
            modifiers.Add("Cheese", 1.1);
            modifiers.Add("Sauce", 0.9);
        }
        private string Type
        {
            get => type;
            set
            {
                value = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                switch (value)
                {
                    case "Meat":
                    case "Veggies":
                    case "Cheese":
                    case "Sauce":
                        type = value;
                        break;
                    default:
                        throw new Exception($"Cannot place {value} on top of your pizza.");

                }
            }
        }
        private int Weight 
        { 
            get => weight; 
            set
            {
                if (value<1 || value >50)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                weight = value;
            } 
        }
        public string GetCalories()
        {
            return $"{(Weight * 2) * modifiers[type]}";
        }
    }
}
