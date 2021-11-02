using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Pizza pizza = null;
            while (input != "END")
            {
                string[] arguments = input.Split(" ");
                try
                {
                    switch (arguments[0])
                    {
                        case "Pizza":
                            pizza = new Pizza(arguments[1]);
                            break;
                        case "Dough":
                            Dough dough = new Dough(arguments[1], arguments[2], int.Parse(arguments[3]));
                            pizza.Dough = dough;
                            break;
                        case "Topping":
                            Topping topping = new Topping(arguments[1], int.Parse(arguments[2]));
                            pizza.AddTopping(topping);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
               
                input = Console.ReadLine();
            }
            Console.WriteLine(pizza.GetCalories()); 
        }
    }
}
