using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();
            var propInfo = type.GetProperties();
            foreach (PropertyInfo item in propInfo)
            {
                var attributes = item.GetCustomAttributes<MyValidationAttribute>();
                foreach (MyValidationAttribute att in attributes)
                {
                    if (att.IsValid(item.GetValue(obj)) == false)
                    {
                        return false;
                    }
                    
                }
            }
            return true;
        }
    }
}
