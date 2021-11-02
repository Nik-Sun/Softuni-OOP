﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name,double caffeine)
            :base(name,3.50m,50)
        {
            Caffeine = caffeine;
        }
        public double CoffeeMililiters { get; set; } = 50;
        public decimal CoffeePrice { get; set; } = 3.50M;
        public double  Caffeine { get; set; }

    }
}
