using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Dessert : Food
    {
        public Dessert(string name,decimal price,double gramms,double calories)
            :base(name,price,gramms)
        {
            Calories = calories;
        }
        public double Calories { get; set; }
    }
}
