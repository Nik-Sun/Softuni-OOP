namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Animal animal = new Animal("pesho the animal");
            Reptile reptile = new Reptile("gosho the reptile");
            Snake snake = new Snake("kiro the snake");
            Lizard lizard = new Lizard("stefcho the lizard");
            Mammal mammal = new Mammal("stamat the mammal");
            Gorilla gorilla = new Gorilla("niki the gorilla");
            Bear bear = new Bear("ivan the bear");
            System.Console.WriteLine($"{animal.Name}, {reptile.Name}, { snake.Name}, {lizard.Name}, {mammal.Name}, {gorilla.Name}, {bear.Name}");
        }
    }
}