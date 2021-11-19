using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        
        public override bool IsValid(object obj)
        {
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
