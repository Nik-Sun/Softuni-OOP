using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("Pesho");
            list.Add("Gosho");
            list.Add("Misho");
            Console.WriteLine(list.RandomString());
        }
    }
}
