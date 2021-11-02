using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class MainDish : Food
    {
        public MainDish(string name,decimal price ,double gramms)
            :base(name,price,gramms)
        {
            
        }
    }
}
