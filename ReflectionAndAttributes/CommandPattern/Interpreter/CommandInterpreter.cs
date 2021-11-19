using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Interpreter
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] splitted = args.Split(" ",StringSplitOptions.RemoveEmptyEntries);
            string command = splitted[0] + "Command";
            string[] arguments = splitted.Skip(1).ToArray();
            Type type = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name == command).FirstOrDefault();
            if (type != null)
            {
                ICommand current = (ICommand)Activator.CreateInstance(type);
                return current.Execute(arguments);
            }
            else
            {
                throw new InvalidOperationException("Invalid command");
            }
            
        }
    }
}
