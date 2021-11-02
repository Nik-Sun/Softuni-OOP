using System;
namespace Person
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string name = System.Console.ReadLine();
            int age = int.Parse(System.Console.ReadLine());
            Child child = new Child(name,age);
            Console.WriteLine(child);
        }
    }
}