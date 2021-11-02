using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            stack.AddRange(new string[] { "aa", "bb", "DD", "GG" });
            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
