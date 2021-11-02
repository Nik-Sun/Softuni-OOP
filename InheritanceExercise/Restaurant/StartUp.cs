namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Cake cake = new Cake("Sunday");
            System.Console.WriteLine($"Name: {cake.Name}|| Grams: {cake.Grams} || Price: {cake.Price} || Calories: {cake.Calories}");
        }
    }
}