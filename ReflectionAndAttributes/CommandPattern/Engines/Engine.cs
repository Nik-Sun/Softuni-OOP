using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Engines
{
    public class Engine :IEngine
    {
        private ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(commandInterpreter.Read(input)); 
            }
        }
    }
}
