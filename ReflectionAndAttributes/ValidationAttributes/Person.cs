using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }
        [MyRequired]
        public string FullName { get; set; }
        [MyRange(1,99)]
        public int Age { get; set; }

    }
}
