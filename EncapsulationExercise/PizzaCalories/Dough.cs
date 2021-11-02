using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        private Dictionary<string, double> modifiers = new Dictionary<string, double>();
       
                           
        public Dough(string flourType, string bakingTechnique,int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            modifiers.Add("White",1.5);
            modifiers.Add("Wholegrain",1.0);
            modifiers.Add("Crispy",0.9);
            modifiers.Add("Chewy",1.1);
            modifiers.Add("Homemade",1.0);
        }

        private string  FlourType
        {
            get => flourType;
            set 
            {
                value = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                switch (value)
                {
                    case "White":
                    case "Wholegrain":
                        flourType = value;
                        break;
                    default:
                        throw new Exception("Invalid type of dough.");
                        
                }
            }
        }
        private string  BakingTechnique 
        {
            get => bakingTechnique;
            set
            {
                value = char.ToUpper(value[0]) + value.Substring(1).ToLower();
                switch (value)
                {
                    case "Crispy":
                    case "Chewy":
                    case "Homemade":
                        bakingTechnique = value;
                        break;
                    default:
                        throw new Exception("Invalid type of dough.");
                        
                }
            }
        }
        private int Weight
        {
            get => weight;
            set
            {
                if (value<1||value>200)
                {
                    throw new Exception("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public string GetCalories()
        {
            return $"{(weight * 2) * modifiers[flourType] * modifiers[bakingTechnique] :f2}";
        }
    }
}
