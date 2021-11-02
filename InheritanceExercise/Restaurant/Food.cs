using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Food : Product
    {
        public Food(string name,decimal price,double gramms)
            :base(name,price)
        {
            Grams = gramms;
        }
        public double Grams  { get; set; }

    }
}
