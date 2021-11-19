using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Object obj = Activator.CreateInstance(Type.GetType(className), new object[] { });
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            FieldInfo[] info = Type.GetType(className).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var field in info)
            {
                if (fieldNames.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(obj)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsInfo = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            foreach (var item in fieldsInfo)
            {
                if (item.IsPrivate == false)
                {
                    sb.AppendLine($"{item.Name} must be private!");
                }
            }

            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.Name.Contains("get") && method.IsPublic == false)
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }
                else if (method.Name.Contains("set") && method.IsPrivate == false)
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            MethodInfo[] methods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().TrimEnd();
        }
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sbSet = new StringBuilder();
            StringBuilder sbGet = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            foreach (var method in methods)
            {
                if (method.Name.Contains("get"))
                {
                    sbGet.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
                else if (method.Name.Contains("set"))
                {
                    sbSet.AppendLine($"{method.Name} will set field of {method.GetParameters().FirstOrDefault().ParameterType}");
                }
            }
            sb.Append(sbGet.ToString());
            sb.Append(sbSet.ToString());
            return sb.ToString().TrimEnd();
        }
    }
}
